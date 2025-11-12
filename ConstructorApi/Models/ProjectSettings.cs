using System.Text.Json.Serialization;

namespace ConstructorApi.Models
{
    public class ProjectSetting 
    {
        public int Id { get; set; }
        
        public int ProjectId { get; set; } 
        
        public string BackgroundColor { get; set; } = "#FFFFFF";
        public float LightIntensity { get; set; } = 1.0f;

        [JsonIgnore]
        public Project? Project { get; set; } 
    }
}
