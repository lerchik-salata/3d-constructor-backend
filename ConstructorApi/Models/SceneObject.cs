using System.Text.Json.Serialization; 
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace ConstructorApi.Models
{
    public class SceneObject : BaseEntity
    {
        public string? Type { get; set; }
        
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        
        public float RotationX { get; set; }
        public float RotationY { get; set; }
        public float RotationZ { get; set; }
        
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float ScaleZ { get; set; }
        
        public string? Color { get; set; } 
        public int? TextureId { get; set; }
        
        public int SceneId { get; set; }

        [Column(TypeName = "jsonb")]
        public string? Params { get; set; } = "{}";

        [NotMapped]
        public Dictionary<string, float>? ParamsDict
        {
            get => string.IsNullOrEmpty(Params)
                ? null
                : JsonSerializer.Deserialize<Dictionary<string, float>>(Params);
            set => Params = value == null ? null : JsonSerializer.Serialize(value);
        }
        
        [JsonIgnore] 
        public Scene? Scene { get; set; } 
        public Texture? Texture { get; set; } 
    }
}
