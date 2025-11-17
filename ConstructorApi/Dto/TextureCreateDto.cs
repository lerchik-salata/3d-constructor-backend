using System.Collections.Generic;

namespace ConstructorApi.DTOs.Texture
{

    public class TextureCreateDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }

    public class TextureUpdateDto
    {
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
    }

}