using System;
using System.Collections.Generic;

namespace ConstructorApi.DTOs.Project
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProjectSettingDto? Settings { get; set; }

        public IEnumerable<Scene.SceneDto>? Scenes { get; set; }
    }

    public class ProjectCreateDto
    {
        public string Name { get; set; } = "Untitled Project";
        public string? Description { get; set; }
        public ProjectSettingDto? Settings { get; set; }
    }

    public class ProjectUpdateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProjectSettingDto? Settings { get; set; }
    }

    public class ProjectSettingDto
    {
        public string? Preset { get; set; }
        public float PresetBlur { get; set; }
        public string BackgroundColor { get; set; }
        public string SceneColor { get; set; }
        public float LightIntensity { get; set; }
        public float[] DirectionalLightPosition { get; set; }
    }
}
