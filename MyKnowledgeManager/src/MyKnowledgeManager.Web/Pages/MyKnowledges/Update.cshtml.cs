using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.Web.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyKnowledgeManager.Web.Pages.MyKnowledges
{
    public class UpdateModel : PageModel
    {
        private readonly IKnowledgeService _knowledgeService;
        private readonly IKnowledgeTagService _knowledgeTagService;
        private readonly IKnowledgeTagRelationService _knowledgeTagRelationService;
        private readonly IMapper _mapper;

        public UpdateModel(
            IKnowledgeService knowledgeService,
            IKnowledgeTagService knowledgeTagService,
            IKnowledgeTagRelationService knowledgeTagRelationService,
            IMapper mapper)
        {
            _knowledgeService = knowledgeService;
            _knowledgeTagService = knowledgeTagService;
            _knowledgeTagRelationService = knowledgeTagRelationService;
            _mapper = mapper;
        }

        public SelectList KnowledgeLevelSelectList { get; set; }

        public SelectList KnowledgeImportanceSelectList { get; set; }

        public string[] TagsWhitelist { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id is null) return NotFound();

            // Getting the knowledge from the database by input id.
            Knowledge knowledge = await _knowledgeService.GetKnowledgeByIdAsync(id, true);

            if (knowledge is null) return NotFound();

            KnowledgeRecord = _mapper.Map<KnowledgeRecord>(knowledge);

            // Getting all tags from the database for prediction list.
            var tags = await _knowledgeTagService.GetKnowledgeTagsAsync();
            TagsWhitelist = tags.Value.Select(x => x.TagName).ToArray();

            // If any relation exits, we should show tag values.
            if (knowledge.KnowledgeTagRelations is not null && knowledge.KnowledgeTagRelations.Count() is not 0)
            {
                List<KnowledgeTagJsonRecord> knowledgeTagJsonRecords = new();

                // Iterate over all relations to map the "KnowledgeTag" object to the JSON record.
                foreach (var item in knowledge.KnowledgeTagRelations)
                {
                    KnowledgeTagJsonRecord knowledgeTagJsonRecord = _mapper.Map<KnowledgeTagJsonRecord>(item.KnowledgeTag);
                    knowledgeTagJsonRecords.Add(knowledgeTagJsonRecord);
                }

                TagsJson = string.Join(",", knowledgeTagJsonRecords.Select(x => x.Value).ToList());
            }

            return Page();
        }


        [BindProperty]
        public KnowledgeRecord KnowledgeRecord { get; set; }

        [BindProperty]
        [Display(Name = "Tags")]
        public string TagsJson { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please fill the form correctly.");

                return Page();
            }

            // Considering a list of string for all of tag Id properties.
            List<string> tagIds = new List<string>();

            // Checking and Updating all database tags.
            var updateDatabaseTagsResult = await UpdateDatabaseTagsAsync(tagIds);

            if (!updateDatabaseTagsResult.Item1)
            {
                ModelState.AddModelError(string.Empty, "An error has been occurred. Cannot add the entered tags.");
                await this.OnGetAsync(KnowledgeRecord.Id);
                return Page();
            }

            tagIds = updateDatabaseTagsResult.Item2;

            // Mapping KnowledgeRecord object to the Knowledge object for database.
            Knowledge knowledge = _mapper.Map<Knowledge>(KnowledgeRecord);

            try
            {
                // Adding the knowledge to the database.
                knowledge = await _knowledgeService.AddKnowledgeAsync(knowledge);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error has been occurred. Cannot add the knowledge.");
                await this.OnGetAsync(KnowledgeRecord.Id);
                return Page();
            }

            // Adding probable Knowledge and KnowledgeTag relations.
            await AddKnowledgeTagRelationsAsync(tagIds, knowledge.Id);


            return RedirectToPage("./Index");
        }


        [NonHandler]
        private async Task<(bool, List<string>)> UpdateDatabaseTagsAsync(List<string> tagIds)
        {
            // I used tagify.js for KnowledgeTags input, and the output of that component is a JSON like this:
            // [{"value": "example tag 1"}, {"value": "example tag 2"}]
            // So, I created an object called KnowledgeTagJsonRecord in the Models folder for Serialization and De-serialization.
            if (TagsJson is not null)
            {
                // De serializing the JSON input of Tags (If exists).
                List<KnowledgeTagJsonRecord> tagsDeserializedJsonList = JsonConvert.DeserializeObject<List<KnowledgeTagJsonRecord>>(TagsJson);

                // Considering two lists, one list for old tags that exist on the database,
                // and one list of new tags we must add to the database.
                List<KnowledgeTag> dbTags = new();
                List<KnowledgeTag> newTags = new();

                for (int i = 0; i < tagsDeserializedJsonList.Count; i++)
                {
                    var finalizedValue = KnowledgesTagHelper.FinalizeTagString(tagsDeserializedJsonList[i].Value);
                    // TagName is unique, So, if we can get the tag from the database if exists.
                    KnowledgeTag knowledgeTag = await _knowledgeTagService.GetKnowledgeTagByNameAsync(finalizedValue);

                    // Checking if the knwoledgeTag is null, then we should add it to the newTags list.
                    if (knowledgeTag is null)
                    {
                        knowledgeTag = new(finalizedValue);

                        newTags.Add(knowledgeTag);
                    }
                    else
                    {
                        dbTags.Add(knowledgeTag);
                    }
                }

                if (newTags.Count is not 0)
                {
                    try
                    {
                        // Adding all new tags to the database.
                        newTags = (List<KnowledgeTag>)await _knowledgeTagService.AddRangeKnowledgeTagAsync(newTags);
                    }
                    catch (Exception)
                    {
                        return (false, null);
                    }
                }

                // Since the operation was successful, we have to combine tag lists.
                dbTags.AddRange(newTags);

                // Adding all Id properties into the final list.
                tagIds = dbTags.Select(x => x.Id).ToList();

                // Assigning null to the dbTags and newTags to reduce memory allocation.
                dbTags = null;
                newTags = null;
            }

            return (true, tagIds);
        }

        [NonHandler]
        private async Task AddKnowledgeTagRelationsAsync(List<string> tagIds, string knowledgeId)
        {
            // Getting the knowledge from the database by input id.
            Knowledge knowledge = await _knowledgeService.GetKnowledgeByIdAsync(KnowledgeRecord.Id, true);

            if (knowledge == null) return;

            if (knowledge.KnowledgeTagRelations is not null && knowledge.KnowledgeTagRelations.Count() is not 0)
            {
                bool result = await _knowledgeTagRelationService.RemoveRangeTagsAsync(knowledge.KnowledgeTagRelations);

                if (!result)
                {
                    throw new Exception("Unexpected Error");
                }
            }

            // Checking if any tag Id exits for adding to the database.
            if (tagIds is not null && tagIds.Count is not 0)
            {
                // Initializing a list of relations for the database.
                List<KnowledgeTagRelation> knowledgeTagRelations = new();

                // Iterate over each Id in tagIds list to create a relationship object.
                for (int i = 0; i < tagIds.Count; i++)
                {
                    KnowledgeTagRelation knowledgeTagRelation = new(knowledgeId, tagIds[i]);
                    knowledgeTagRelations.Add(knowledgeTagRelation);
                }

                // Adding all KnowledgeTagRelation objects to the database.
                await _knowledgeTagRelationService.AddRangeKnowledgeTagRelationAsync(knowledgeTagRelations);
            }
        }
    }
}
