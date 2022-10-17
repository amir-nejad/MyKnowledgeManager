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
        private readonly ITrashManager<Knowledge> _trashManager;

        public DeleteModel(
            IKnowledgeService knowledgeService, 
            IMapper mapper, 
            ITrashManager<Knowledge> trashManager)
        {
            _knowledgeService = knowledgeService;
            _mapper = mapper;
            _trashManager = trashManager;
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
            if (id is null) return NotFound();

            Knowledge knowledge = await _knowledgeService.GetKnowledgeByIdAsync(id);

            if (knowledge is null) return NotFound();

            var moveToTrashResult = await _trashManager.MoveItemToTrashAsync(id);

            if (!moveToTrashResult.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, moveToTrashResult.Errors.FirstOrDefault());
            }

            return RedirectToPage("./Index");
        }
    }
}
