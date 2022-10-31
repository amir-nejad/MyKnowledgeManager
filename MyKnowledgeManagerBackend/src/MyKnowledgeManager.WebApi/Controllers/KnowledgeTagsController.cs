using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.WebApi.ApiModels;

namespace MyKnowledgeManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KnowledgeTagsController : ControllerBase
    {
        private readonly IKnowledgeTagService _knowledgeTagService;
        private readonly ITrashManager<KnowledgeTag> _trashManager;
        private readonly IMapper _mapper;
        private const string GeneralProblemMessage = "Something went wrong. Please try again.";
        private readonly string _userId;

        public KnowledgeTagsController(
            IKnowledgeTagService knowledgeTagService,
            ITrashManager<KnowledgeTag> trashManager,
            IMapper mapper)
        {
            _knowledgeTagService = knowledgeTagService;
            _trashManager = trashManager;
            _mapper = mapper;

            _userId = User.FindFirst("sub").Value;
        }

        // GET: api/KnowledgeTags
        [HttpGet("{includeKnowledges?}")]
        public async Task<ActionResult<IEnumerable<KnowledgeTagDTO>>> GetKnowledgeTags(bool includeKnowledges = false)
        {
            // Getting all tags from the database.
            var getKnowledgeTagsResult = await _knowledgeTagService.GetKnowledgeTagsAsync(_userId ,includeKnowledges);

            // Checking if the operation was successful or not.
            if (!getKnowledgeTagsResult.IsSuccess) return Problem(GeneralProblemMessage);

            // Checking if the Value property (tags list) has any member.
            if (getKnowledgeTagsResult.Value is null || getKnowledgeTagsResult.Value.Count() is 0) return NoContent();

            // Converting the list of KnowledgeTag objects to the list of KnowledgeTagDTO objects.
            List<KnowledgeTagDTO> knowledgeTagDTOs = _mapper.Map<List<KnowledgeTagDTO>>(getKnowledgeTagsResult.Value.ToList());

            return knowledgeTagDTOs;
        }

        // GET: api/KnowledgeTags/<GUID>
        [HttpGet("getKnowledgeTagById/{id?}/{includeKnowledges?}")]
        public async Task<ActionResult<KnowledgeTagDTO>> GetKnowledgeTagById(string id, bool includeKnowledges = false)
        {
            if (id is null) return BadRequest();

            KnowledgeTag knowledgeTag = await _knowledgeTagService.GetKnowledgeTagByIdAsync(id, includeKnowledges);

            if (knowledgeTag is null) return NotFound();

            if (knowledgeTag.UserId != _userId) return Unauthorized();

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // GET: api/KnowledgeTags/<name>
        [HttpGet("getKnowledgeTagByName/{name?}/{includeKnowledges?}")]
        public async Task<ActionResult<KnowledgeTagDTO>> GetKnowledgeTagByName(string name, bool includeKnowledges = false)
        {
            if (name is null) return BadRequest();

            KnowledgeTag knowledgeTag = await _knowledgeTagService.GetKnowledgeTagByNameAsync(name, _userId, includeKnowledges); ;

            if (knowledgeTag is null) return NotFound();

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // GET: api/KnowledgeTags/getTrashKnowledgeTags
        [HttpGet("getTrashKnowledgeTags")]
        public async Task<ActionResult<List<KnowledgeTagDTO>>> GetTrashKnowledgeTags()
        {
            var trashKnowledgeTags = await _trashManager.GetTrashItemsAsync(_userId);

            if (trashKnowledgeTags.Value is null || trashKnowledgeTags.Value.Count() is 0) return NoContent();

            return _mapper.Map<List<KnowledgeTagDTO>>(trashKnowledgeTags);
        }

        // PUT: api/knowledgeTags
        [HttpPut("{id?}")]
        public async Task<ActionResult<KnowledgeTagDTO>> UpdateKnowledgeTag(string id, KnowledgeTagDTO knowledgeTagDTO)
        {
            if (id is null || id != knowledgeTagDTO.Id) return BadRequest();

            KnowledgeTag knowledgeTag = _mapper.Map<KnowledgeTag>(knowledgeTagDTO);

            // Updating the KnowledgeTag
            knowledgeTag = await _knowledgeTagService.UpdateKnowledgeTagAsync(knowledgeTag);

            if (knowledgeTag is null) return Problem(GeneralProblemMessage);

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // POST: api/KnowledgeTag
        [HttpPost]
        public async Task<ActionResult<KnowledgeTagDTO>> PostKnowledgeTag(KnowledgeTagDTO knowledgeTagDTO)
        {
            if (!ModelState.IsValid) return ValidationProblem();

            KnowledgeTag knowledgeTag = _mapper.Map<KnowledgeTag>(knowledgeTagDTO);

            knowledgeTag = await _knowledgeTagService.AddKnowledgeTagAsync(knowledgeTag);

            if (knowledgeTag is null) return Problem(GeneralProblemMessage);

            knowledgeTagDTO = _mapper.Map<KnowledgeTagDTO>(knowledgeTag);

            return knowledgeTagDTO;
        }

        // PUT: api/knowledgeTags/moveKnowledgeTagToTrash/<GUID>
        [HttpPut("moveKnowledgeTagToTrash/{id}")]
        public async Task<ActionResult> MoveToTrashKnowledgeTag(string id)
        {
            if (id is null) return BadRequest();

            // Moving input item to the trash
            var result = await _trashManager.MoveItemToTrashAsync(id, _userId);

            if (!result.IsSuccess)
            {
                return Problem(GeneralProblemMessage);
            }

            return Ok();
        }

        // PUT: api/knowledgeTags/restoreKnowledgeTag/<GUID>
        [HttpPut("restoreKnowledgeTag/{id}")]
        public async Task<IActionResult> RestoreKnowledgeTag(string id)
        {
            if (id is null) return BadRequest();

            // Moving out input item from the trash
            var result = await _trashManager.RestoreTrashItemAsync(id, _userId);

            if (!result.IsSuccess)
            {
                return Problem(GeneralProblemMessage);
            }

            return Ok();
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> DeleteKnowledgeTag(string id)
        {
            if (id is null) return BadRequest();

            var result = await _knowledgeTagService.RemoveKnowledgeTagAsync(id, _userId);

            if (!result.IsSuccess) return Problem(GeneralProblemMessage);

            return Ok();
        }
    }
}
