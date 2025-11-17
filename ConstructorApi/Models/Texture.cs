using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConstructorApi.Models
{
    public class Texture
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<SceneObject> SceneObjects { get; set; } = new List<SceneObject>();
    }
}