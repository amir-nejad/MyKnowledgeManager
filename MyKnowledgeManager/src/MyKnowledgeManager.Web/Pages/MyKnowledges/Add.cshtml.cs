using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyKnowledgeManager.Core.Aggregates.Knowledge.Entities;
using MyKnowledgeManager.SharedKernel.Interfaces;

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

        public void OnGet()
        {
        }


        [BindProperty]
        public Knowledge Knowledge { get; set; }

        [BindProperty]
        public IList<string> Tags { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please fill the form correctly.");

                return Page(); 
            }

            await _repository.AddAsync(Knowledge);

            return RedirectToPage("./Index");
        }
    }
}
