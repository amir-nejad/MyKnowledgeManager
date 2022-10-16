using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.Web.Models;

namespace MyKnowledgeManager.Web.Pages.MyKnowledges
{
    public class DeleteModel : PageModel
    {
        private readonly IKnowledgeService _knowledgeService;
        private readonly IMapper _mapper;

        public DeleteModel(IKnowledgeService knowledgeService, IMapper mapper)
        {
            _knowledgeService = knowledgeService;
            _mapper = mapper;
        }

        public KnowledgeRecord KnowledgeRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id is null) return NotFound();

            Knowledge knowledge = await _knowledgeService.GetKnowledgeByIdAsync(id, true);

            KnowledgeRecord = _mapper.Map<KnowledgeRecord>(knowledge);

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id is null)
            {
                return NotFound();
            }

            // Moving to trash codes will go here.

            return RedirectToPage("./Index");
        }
    }
}
