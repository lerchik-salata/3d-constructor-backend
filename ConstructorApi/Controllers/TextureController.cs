using ConstructorApi.Models;
using ConstructorApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ConstructorApi.DTOs.Texture;

namespace ConstructorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextureController : ControllerBase
    {
        private readonly ITextureService _service;

        public TextureController(ITextureService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var textures = await _service.GetAllAsync();
            return Ok(textures);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] TextureCreateDto dto)
        {
            var name = dto.Name;
            var image = dto.Image;
        {
            var tex = await _service.CreateAsync(name, image);
            return Ok(tex);
        }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int id, [FromForm] TextureUpdateDto dto)
        {
            var name = dto.Name;
            var image = dto.Image;  
            
        {
            var tex = await _service.UpdateAsync(id, name, image);
            if (tex == null) return NotFound();
            return Ok(tex);
        }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? Ok() : NotFound();
        }
    }
}
