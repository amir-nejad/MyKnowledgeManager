using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.SharedKernel.Interfaces;
using MyKnowledgeManager.Web.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyKnowledgeManager.Web.Pages.MyKnowledges
{
    public class AddModel : PageModel
    {
        private readonly IRepository<Knowledge> _knowledgeRepository;
        private readonly IRepository<KnowledgeTagRelation> _knowledgeTagRelationRepository;
        private readonly IRepository<KnowledgeTag> _knowledgeTagRepository;
        public AddModel(
            IRepository<Knowledge> knowledgeRepository, 
            IRepository<KnowledgeTagRelation> knowledgeTagRelationRepository, 
            IRepository<KnowledgeTag> knowledgeTagRepository)
        {
            _knowledgeRepository = knowledgeRepository;
            _knowledgeTagRelationRepository = knowledgeTagRelationRepository;
            _knowledgeTagRepository = knowledgeTagRepository;
        }

        public SelectList KnowledgeLevelSelectList { get; set; }

        public SelectList KnowledgeImportanceSelectList { get; set; }

        public string[] TagsWhitelist { get; set; }

        public void OnGet()
        {
            TagsWhitelist = new string[] { "Amirhossein", "Mahdis" };
        }


        [BindProperty]
        public KnowledgeRecord Knowledge { get; set; }

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

            List<KnowledgeTagJsonRecord> tagsDeserializedJson = JsonConvert.DeserializeObject<List<KnowledgeTagJsonRecord>>(TagsJson);

            return RedirectToPage("./Index");
        }
    }
}
