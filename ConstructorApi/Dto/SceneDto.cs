using System.Collections.Generic;

namespace ConstructorApi.DTOs.Scene
{
    public class SceneCreateDto
    {
        public string Name { get; set; } = "Untitled Scene";

        public List<SceneObjectCreateDto>? Objects { get; set; }
    }

    public class SceneUpdateDto
    {
        public string? Name { get; set; }

        public List<SceneObjectCreateDto>? Objects { get; set; }
    }

    public class SceneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ProjectId { get; set; }

        public IEnumerable<SceneObjectDto>? Objects { get; set; }
    }

    public class SceneObjectCreateDto
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
        public string? TextureId { get; set; }
        public string? Params { get; set; }
    }

    public class SceneObjectDto
    {
        public int Id { get; set; }
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
        public string? TextureId { get; set; }
        public string? Params { get; set; }
    }
}
