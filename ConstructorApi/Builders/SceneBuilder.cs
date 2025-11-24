using ConstructorApi.Models;
using ConstructorApi.DTOs.Scene;
using System.Text.Json;

namespace ConstructorApi.Builders
{
    public class SceneBuilder
    {
        private readonly SceneExportDto _sceneDto = new();

        public SceneBuilder SetSceneName(string name)
        {
            _sceneDto.SceneName = name;
            return this;
        }

        public SceneBuilder AddObjects(IEnumerable<SceneObject> objects)
        {
            foreach (var o in objects)
            {
                _sceneDto.Objects.Add(BuildSceneObjectDto(o));
            }
            return this;
        }

        private SceneObjectDto BuildSceneObjectDto(SceneObject o)
        {
            return new SceneObjectDto
            {
                Id = o.Id,
                Type = o.Type ?? string.Empty,
                PositionX = o.PositionX,
                PositionY = o.PositionY,
                PositionZ = o.PositionZ,
                RotationX = o.RotationX,
                RotationY = o.RotationY,
                RotationZ = o.RotationZ,
                ScaleX = o.ScaleX,
                ScaleY = o.ScaleY,
                ScaleZ = o.ScaleZ,
                Color = o.Color ?? "#ffffff",
                TextureId = o.TextureId?.ToString(),
                Params = string.IsNullOrEmpty(o.Params) ? "{}" : o.Params
            };
        }

        public SceneExportDto Build() => _sceneDto;
    }
}
