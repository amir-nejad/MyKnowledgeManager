using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.WebApi.ApiModels;
using MyKnowledgeManager.WebApi.Utilities;
using Newtonsoft.Json;

namespace MyKnowledgeManager.WebApi.Controllers
{
    /// <summary>
    /// This controller is used as the "Knowledge" and its' children API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgesController : ControllerBase
    {
        private readonly IKnowledgeService _knowledgeService;
        private readonly IKnowledgeTagService _knowledgeTagService;
        private readonly IKnowledgeTagRelationService _knowledgeTagRelationService;
        private readonly IMapper _mapper;
        private const string GeneralProblemMessage = "Something went wrong. Please try again.";

        public KnowledgesController(
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

        // GET: api/Knowledges
        [HttpGet("{includeTags?}")]
        public async Task<ActionResult<List<KnowledgeDTO>>> GetKnowledges(bool includeTags = false)
        {
            List<Knowledge> knowledges = await _knowledgeService.GetKnowledgesAsync(includeTags);

            return _mapper.Map<List<KnowledgeDTO>>(knowledges);
        }

        // GET: api/Knowledges/<GUID>
        [HttpGet("{id}/{includeTags?}")]
        public async Task<ActionResult<KnowledgeDTO>> GetKnowledge(string id, bool includeTags = false)
        {
            if (id is null) return BadRequest();

            Knowledge knowledge = await _knowledgeService.GetKnowledgeByIdAsync(id);

            if (knowledge is null) return Problem();

            return _mapper.Map<KnowledgeDTO>(knowledge);
        }

        // PUT: api/Knowledges/<GUID>
        //[HttpPut("{id}")]
        //public async Task<ActionResult<KnowledgeDTO>> PutKnowledge(string id, KnowledgeDTO knowledgeDTO)
        //{
        //    // Checking if the request is valid.
        //    if (id is null || id != knowledgeDTO.Id) return BadRequest();

        //    // Converting KnowledgeDTO object to Knowledge object.
        //    Knowledge knowledge = _mapper.Map<Knowledge>(knowledgeDTO);

        //    if (knowledge is null) return Problem();

        //    // Updating Knowledge
        //    var updateResult = await _knowledgeService.UpdateKnowledgeAsync(knowledge);

        //    if (updateResult.IsSuccess)
        //    {
        //        knowledge = updateResult.Value;
        //        knowledgeDTO = _mapper.Map<KnowledgeDTO>(knowledge);

        //        return knowledgeDTO;
        //    }
        //    else
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        // POST: api/Knowledges
        [HttpPost]
        [HttpPut]
        public async Task<ActionResult<KnowledgeDTO>> PostKnowledge(KnowledgeDTO knowledgeDTO)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            // Converting KnowledgeDTO object to Knowledge object.
            Knowledge knowledge = _mapper.Map<Knowledge>(knowledgeDTO);

            if (knowledge is null)
            {
                return Problem(GeneralProblemMessage);
            }

            #region Create or Update Tags
            var updatedTagsResult = await UpdateDatabaseTagsAsync(knowledgeDTO.KnowledgeTags);

            if (!updatedTagsResult.Item1) return Problem(GeneralProblemMessage);
            #endregion

            #region Create or Update Knowledge
            Result<Knowledge> result = null;

            if (Request.Method == HttpMethods.Put)
            {
                // Updating Knowledge
                result = await _knowledgeService.UpdateKnowledgeAsync(knowledge);
            }
            else if(Request.Method == HttpMethods.Post)
            {
                // Adding knowledge to the database
                result = await _knowledgeService.AddKnowledgeAsync(knowledge);
            }
            else
            {
                return BadRequest();
            }

            if (!result.IsSuccess) return Problem(GeneralProblemMessage);

            knowledge = result.Value;
            #endregion


            #region Create or Update Relations
            // Adding knowledge relations
            bool addRelationsResult = await AddKnowledgeTagRelationsAsync(
                updatedTagsResult.Item2
                .Select(x => x.Id)
                .ToList(),
                knowledge.Id);

            // Checking if operation was successful.
            if (!addRelationsResult)
            {
                await DeleteKnowledge(knowledge.Id);

                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            #endregion

            knowledgeDTO = _mapper.Map<KnowledgeDTO>(knowledge);

            return knowledgeDTO;
        }

        // DELETE: api/Knowledges/<GUID>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnowledge(string id)
        {
            if (id is null) return BadRequest();

            // Removing the knowledge from the database.
            var knowledge = await _knowledgeService.RemoveKnowledgeAsync(id);

            if (!knowledge.IsSuccess) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }


        [NonAction]
        private async Task<(bool, List<KnowledgeTag>)> UpdateDatabaseTagsAsync(string[] tags)
        {
            if (tags is null || tags.Count() is 0) return (true, null);

            // Considering two lists, one list for old tags that exist on the database,
            // and one list of new tags we must add to the database.
            List<KnowledgeTag> dbTags = new();
            List<KnowledgeTag> newTags = new();

            #region Detecting previous and new tags
            // Iterate over all tags input items
            for (int i = 0; i < tags.Count(); i++)
            {
                var finalizedValue = KnowledgesTagHelper.FinalizeTagString(tags[i]);
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
            #endregion

            #region Adding new tags to the database
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
            #endregion

            // Since the operation was successful; we must combine tag lists.
            dbTags.AddRange(newTags);

            return (true, dbTags);
        }

        [NonAction]
        private async Task<bool> AddKnowledgeTagRelationsAsync(List<string> tagIds, string knowledgeId)
        {
            #region Removing Old Relations
            // Getting old relations if exist.
            List<KnowledgeTagRelation> oldRelations = (List<KnowledgeTagRelation>)await _knowledgeTagRelationService.GetKnowledgeTagRelationsByKnowledgeIdAsync(knowledgeId);

            if (oldRelations is not null && oldRelations.Count() is not 0)
            {
                bool result = await _knowledgeTagRelationService.RemoveRangeTagsAsync(oldRelations);

                if (!result)
                {
                    return false;
                }

                oldRelations = null;
            }
            #endregion

            #region Creating New Relations
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
                var result = await _knowledgeTagRelationService.AddRangeKnowledgeTagRelationAsync(knowledgeTagRelations);

                if (!result.IsSuccess) return false;
            }
            #endregion

            return true;
        }
    }
}
