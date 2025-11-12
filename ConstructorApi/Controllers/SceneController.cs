using Microsoft.AspNetCore.Mvc;
using ConstructorApi.Services;
using ConstructorApi.Models;
using ConstructorApi.DTOs.Scene;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

[ApiController]
[Route("api/projects/{projectId}/[controller]")]
public class ScenesController : ControllerBase
{
    private readonly ISceneService _sceneService;
    private readonly IMapper _mapper;

    public ScenesController(ISceneService sceneService, IMapper mapper)
    {
        _sceneService = sceneService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SceneDto>>> GetScenes(int projectId)
    {
        var scenes = await _sceneService.GetScenesByProjectIdAsync(projectId);
        if (scenes == null) return NotFound();

        return Ok(_mapper.Map<IEnumerable<SceneDto>>(scenes));
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<SceneDto>> GetScene(int projectId, int id)
    {
        var scene = await _sceneService.GetSceneByIdAsync(projectId, id);
        if (scene == null) return NotFound();

        return Ok(_mapper.Map<SceneDto>(scene));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<SceneDto>> PostScene(int projectId, SceneCreateDto dto)
    {
        var scene = _mapper.Map<Scene>(dto);

        var created = await _sceneService.CreateSceneAsync(projectId, scene);
        if (created == null) return NotFound($"Project {projectId} not found.");

        var result = _mapper.Map<SceneDto>(created);

        return CreatedAtAction(nameof(GetScene),
            new { projectId = result.ProjectId, id = result.Id },
            result);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutScene(int projectId, int id, SceneUpdateDto dto)
    {
        var existing = await _sceneService.GetSceneByIdAsync(projectId, id);
        if (existing == null) return NotFound();

        var updated = _mapper.Map<Scene>(dto);

        var result = await _sceneService.UpdateSceneAsync(projectId, id, updated);

        return Ok(_mapper.Map<SceneDto>(result));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteScene(int projectId, int id)
    {
        var deleted = await _sceneService.DeleteSceneAsync(projectId, id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
