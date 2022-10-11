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
        private readonly IRepository<Knowledge> _repository;
        public AddModel(IRepository<Knowledge> repository)
        {
            _repository = repository;
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

            var tags = JsonConvert.DeserializeObject<KnowledgeTagJsonRecord>(TagsJson);

            //await _repository.AddAsync(Knowledge);

            return RedirectToPage("./Index");
        }
    }
}
