using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.Web.Models;

namespace MyKnowledgeManager.Web.Pages.MyKnowledges
{
    public class IndexModel : PageModel
    {
        private readonly IKnowledgeService _knowledgeService;
        private readonly IMapper _mapper;

        public IndexModel(IKnowledgeService knowledgeService, IMapper mapper)
        {
            _knowledgeService = knowledgeService;
            _mapper = mapper;
        }

        public PaginatedList<KnowledgeRecord> KnowledgeRecords { get; set; }

        public int? PageNumber { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            List<Knowledge> knowledges = await _knowledgeService.GetKnowledgesAsync(true);

            if (knowledges == null || knowledges.Count is 0) return Page();

            List<KnowledgeRecord> knowledgeRecords = _mapper.Map<List<KnowledgeRecord>>(knowledges);

            int pageSize = 10;

            KnowledgeRecords = PaginatedList<KnowledgeRecord>.Create(knowledgeRecords, PageNumber ?? 1, pageSize);

            return Page();
        }
    }
}
