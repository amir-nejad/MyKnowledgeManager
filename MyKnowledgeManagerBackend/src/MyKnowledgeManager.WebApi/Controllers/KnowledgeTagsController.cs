using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.SharedKernel.Utilities;
using MyKnowledgeManager.WebApi.ApiModels;
using MyKnowledgeManager.WebApi.Utilities;
using System.Security.Claims;

namespace MyKnowledgeManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = ConfigConstants.RequireApiScope)]
    public class KnowledgeTagsController : ControllerBase
    {
        private readonly IKnowledgeTagService _knowledgeTagService;
        private readonly ITrashManager<KnowledgeTag> _trashManager;
        private readonly IMapper _mapper;
        private const string GeneralProblemMessage = "Something went wrong. Please try again.";
        private string _userId;

        public KnowledgeTagsController(
            IKnowledgeTagService knowledgeTagService,
            ITrashManager<KnowledgeTag> trashManager,
            IMapper mapper)
        {
            _knowledgeTagService = knowledgeTagService;
            _trashManager = trashManager;
            _mapper = mapper;
        }

        // GET: api/KnowledgeTags
        [HttpGet("{includeKnowledges?}")]
        public async Task<ActionResult<IEnumerable<KnowledgeTagDTO>>> GetKnowledgeTags(bool includeKnowledges = false)
        {
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Getting all tags from the database.
            var getKnowledgeTagsResult = await _knowledgeTagService.GetKnowledgeTagsAsync(_userId, includeKnowledges);

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
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

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
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (name is null) return BadRequest();

            KnowledgeTag knowledgeTag = await _knowledgeTagService.GetKnowledgeTagByNameAsync(name, _userId, includeKnowledges); ;

            if (knowledgeTag is null) return NotFound();

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // GET: api/KnowledgeTags/getTrashKnowledgeTags
        [HttpGet("getTrashKnowledgeTags")]
        public async Task<ActionResult<List<KnowledgeTagDTO>>> GetTrashKnowledgeTags()
        {
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            var trashKnowledgeTags = await _trashManager.GetTrashItemsAsync(_userId);

            // Checking if the operation was successful or not.
            if (!trashKnowledgeTags.IsSuccess) return Problem(GeneralProblemMessage);

            if (trashKnowledgeTags.Value is null || trashKnowledgeTags.Value.Count() is 0) return NoContent();

            // Converting the list of KnowledgeTag objects to the list of KnowledgeTagDTO objects.
            List<KnowledgeTagDTO> knowledgeTagDTOs = _mapper.Map<List<KnowledgeTagDTO>>(trashKnowledgeTags.Value.ToList());

            return knowledgeTagDTOs;
        }

        // PUT: api/knowledgeTags
        [HttpPut("{id?}")]
        public async Task<ActionResult<KnowledgeTagDTO>> UpdateKnowledgeTag(string id, KnowledgeTagDTO knowledgeTagDTO)
        {
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (id is null || id != knowledgeTagDTO.Id) return BadRequest();

            if (string.IsNullOrEmpty(knowledgeTagDTO.TagName)) return ValidationProblem(detail: "Tag Name cannot be null.");

            KnowledgeTag knowledgeTag = _mapper.Map<KnowledgeTag>(knowledgeTagDTO);

            knowledgeTag.UpdateTagName(KnowledgeTagHelper.FinalizeTagString(knowledgeTag.TagName));

            // Updating the KnowledgeTag
            knowledgeTag = await _knowledgeTagService.UpdateKnowledgeTagAsync(knowledgeTag);

            if (knowledgeTag is null) return Problem(GeneralProblemMessage);

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // POST: api/KnowledgeTags
        [HttpPost]
        public async Task<ActionResult<KnowledgeTagDTO>> PostKnowledgeTag(KnowledgeTagDTO knowledgeTagDTO)
        {
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid) return ValidationProblem(detail: "Please fill the form correctly.");

            if (string.IsNullOrEmpty(knowledgeTagDTO.TagName)) return ValidationProblem(detail: "Tag Name cannot be null.");

            if (string.IsNullOrEmpty(knowledgeTagDTO.Id)) return ValidationProblem(detail: "Id Cannot be null");

            KnowledgeTag knowledgeTag = _mapper.Map<KnowledgeTag>(knowledgeTagDTO);

            knowledgeTag.UpdateTagName(KnowledgeTagHelper.FinalizeTagString(knowledgeTag.TagName));

            knowledgeTag = await _knowledgeTagService.AddKnowledgeTagAsync(knowledgeTag);

            if (knowledgeTag is null) return Problem(GeneralProblemMessage);

            knowledgeTagDTO = _mapper.Map<KnowledgeTagDTO>(knowledgeTag);

            return knowledgeTagDTO;
        }

        // PUT: api/knowledgeTags/moveKnowledgeTagToTrash/<GUID>
        [HttpPut("moveKnowledgeTagToTrash/{id}")]
        public async Task<ActionResult> MoveToTrashKnowledgeTag(string id)
        {
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

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
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (id is null) return BadRequest();

            // Moving out input item from the trash
            var result = await _trashManager.RestoreTrashItemAsync(id, _userId);

            if (!result.IsSuccess)
            {
                return Problem(GeneralProblemMessage);
            }

            return Ok();
        }

        // DELETE: api/knowledgeTags/<GUID>
        [HttpDelete("{id?}")]
        public async Task<IActionResult> DeleteKnowledgeTag(string id)
        {
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (id is null) return BadRequest();

            var result = await _knowledgeTagService.RemoveKnowledgeTagAsync(id, _userId);

            if (!result.IsSuccess) return Problem(GeneralProblemMessage);

            return Ok();
        }

        // DELETE: api/deleteTrashItems
        [HttpDelete("deleteTrashItems")]
        public async Task<IActionResult> DeleteTrashItems()
        {
            _userId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await _trashManager.DeleteTrashItemsAsync(_userId);

            if (!result.IsSuccess) return Problem(GeneralProblemMessage);

            return Ok();
        }
    }
}
