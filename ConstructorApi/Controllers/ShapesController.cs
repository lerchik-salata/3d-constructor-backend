using Microsoft.AspNetCore.Mvc;
using ConstructorApi.Models;
using ConstructorApi.Services;
using ConstructorApi.DTOs.CustomShape;
using ConstructorApi.Models.Shapes;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/shapes")]
public class ShapesController : ControllerBase
{
    private readonly ShapeService _service;

    public ShapesController(ShapeService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("basic")]
    public IActionResult GetBasicShape([FromQuery] string type)
    {
        try
        {
            var shape = _service.GetBasicShape(type);
            return Ok(shape);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("basic/all")]
    public IActionResult GetAllBasicShapes()
    {
        var shapes = _service.GetAllBasicShapes();
        return Ok(shapes);
    }

    [Authorize]
    [HttpGet("custom")]
    public async Task<IActionResult> GetCustomShapes()
    {
        var shapes = await _service.GetCustomShapes();
        return Ok(shapes);
    }

    [Authorize]
    [HttpGet("custom/{id}")]
    public async Task<IActionResult> GetCustomShape(int id)
    {
        var shape = await _service.GetCustomShape(id);
        return shape != null ? Ok(shape) : NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("custom")]
    public async Task<IActionResult> CreateCustomShape([FromBody] CustomShapeDto dto)
    {
        var shape = new CustomShape
        {
            Name = dto.Name,
            Type = dto.Type,
            Color = dto.Color,
            Params = dto.Params
        };

        var created = await _service.CreateCustomShape(shape);
        return CreatedAtAction(nameof(GetCustomShape), new { id = created.Id }, created);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("custom/{id}")]
    public async Task<IActionResult> UpdateCustomShape(int id, [FromBody] CustomShapeDto dto)
    {
        var shape = new CustomShape
        {
            Id = id,
            Name = dto.Name,
            Type = dto.Type,
            Color = dto.Color,
            Params = dto.Params
        };

        var updated = await _service.UpdateCustomShape(shape);
        return Ok(updated);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("custom/{id}")]
    public async Task<IActionResult> DeleteCustomShape(int id)
    {
        await _service.DeleteCustomShape(id);
        return NoContent();
    }
}
