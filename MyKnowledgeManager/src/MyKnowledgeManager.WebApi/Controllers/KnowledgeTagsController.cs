﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.WebApi.ApiModels;

namespace MyKnowledgeManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeTagsController : ControllerBase
    {
        private readonly IKnowledgeTagService _knowledgeTagService;
        private readonly IKnowledgeTagRelationService _knowledgeTagRelationService;
        private readonly IMapper _mapper;

        public KnowledgeTagsController(
            IKnowledgeTagService knowledgeTagService,
            IKnowledgeTagRelationService knowledgeTagRelationService,
            IMapper mapper)
        {
            _knowledgeTagService = knowledgeTagService;
            _knowledgeTagRelationService = knowledgeTagRelationService;
            _mapper = mapper;
        }

        // GET: api/KnowledgeTags
        [HttpGet("{includeKnowledges?}")]
        public async Task<ActionResult<IEnumerable<KnowledgeTagDTO>>> GetKnowledgeTags(bool includeKnowledges = false)
        {
            // Getting all tags from the database.
            var getKnowledgeTagsResult = await _knowledgeTagService.GetKnowledgeTagsAsync(includeKnowledges);

            // Checking if the operation was successful or not.
            if (!getKnowledgeTagsResult.IsSuccess) return StatusCode(StatusCodes.Status500InternalServerError);

            // Checking if the Value property (tags list) has any member.
            if (getKnowledgeTagsResult.Value is null || getKnowledgeTagsResult.Value.Count() is 0) return new EmptyResult();

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

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // GET: api/KnowledgeTags/<name>
        [HttpGet("getKnowledgeTagByName/{name?}/{includeKnowledges?}")]
        public async Task<ActionResult<KnowledgeTagDTO>> GetKnowledgeTagByName(string name, bool includeKnowledges = false)
        {
            if (name is null) return BadRequest();

            KnowledgeTag knowledgeTag = await _knowledgeTagService.GetKnowledgeTagByNameAsync(name, includeKnowledges);

            if (knowledgeTag is null) return NotFound();

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // PUT: api/knowledgeTags
        [HttpPut("{id?}")]
        public async Task<ActionResult<KnowledgeTagDTO>> UpdateKnowledgeTag(string id, KnowledgeTagDTO knowledgeTagDTO)
        {
            if (id is null || id != knowledgeTagDTO.Id) return BadRequest();

            KnowledgeTag knowledgeTag = _mapper.Map<KnowledgeTag>(knowledgeTagDTO);

            // Updating the KnowledgeTag
            knowledgeTag = await _knowledgeTagService.UpdateKnowledgeTagAsync(knowledgeTag);

            if (knowledgeTag is null) return StatusCode(StatusCodes.Status500InternalServerError);

            return _mapper.Map<KnowledgeTagDTO>(knowledgeTag);
        }

        // POST: api/KnowledgeTag
        [HttpPost]
        public async Task<ActionResult<KnowledgeTagDTO>> PostKnowledgeTag(KnowledgeTagDTO knowledgeTagDTO)
        {
            if (!ModelState.IsValid) return ValidationProblem();

            KnowledgeTag knowledgeTag = _mapper.Map<KnowledgeTag>(knowledgeTagDTO);

            knowledgeTag = await _knowledgeTagService.AddKnowledgeTagAsync(knowledgeTag);

            if (knowledgeTag is null) return StatusCode(StatusCodes.Status500InternalServerError);

            knowledgeTagDTO = _mapper.Map<KnowledgeTagDTO>(knowledgeTag);

            return knowledgeTagDTO;
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> DeleteKnowledgeTag(string id)
        {
            if (id is null) return BadRequest();

            var result = await _knowledgeTagService.RemoveKnowledgeTagAsync(id);

            if (!result.IsSuccess) return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok();
        }
    }
}