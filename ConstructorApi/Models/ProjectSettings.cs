using System.Text.Json.Serialization;

namespace ConstructorApi.Models
{
    public class ProjectSetting
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public string? Preset { get; set; } = "city";
        public float PresetBlur { get; set; } = 0.5f;

        public string BackgroundColor { get; set; } = "#222222";
        public string SceneColor { get; set; } = "#888888";

        public float LightIntensity { get; set; } = 0.7f;
        public float[] DirectionalLightPosition { get; set; } = new float[] { 10, 10, 5 };

        public Project? Project { get; set; }
    }
}
