using Microsoft.AspNetCore.Mvc;
using ConstructorApi.Services;
using ConstructorApi.Models;
using ConstructorApi.DTOs.Project;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public ProjectsController(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(_mapper.Map<IEnumerable<ProjectDto>>(projects));
    }

    [Authorize]
    [HttpGet("my")]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetMyProjects()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var projects = await _projectService.GetProjectsByUserIdAsync(userId);
        return Ok(_mapper.Map<IEnumerable<ProjectDto>>(projects));
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> GetProject(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);

        if (project == null)
            return NotFound();

        return Ok(_mapper.Map<ProjectDto>(project));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ProjectDto>> PostProject(ProjectCreateDto dto)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var project = _mapper.Map<Project>(dto);
        project.UserId = userId;

        var createdProject = await _projectService.CreateProjectAsync(project);
        var result = _mapper.Map<ProjectDto>(createdProject);

        return CreatedAtAction(nameof(GetProject), new { id = result.Id }, result);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProject(int id, ProjectUpdateDto dto)
    {
        var existing = await _projectService.GetProjectByIdAsync(id);
        if (existing == null) return NotFound();

        _mapper.Map(dto, existing);

        var updated = await _projectService.UpdateProjectAsync(id, existing);
        return Ok(_mapper.Map<ProjectDto>(updated));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var deleted = await _projectService.DeleteProjectAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
