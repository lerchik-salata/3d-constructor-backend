using ConstructorApi.Models;
using ConstructorApi.DTOs.Scene;

namespace ConstructorApi.Builders
{
    public class SceneDirector
    {
        private readonly SceneBuilder _builder;

        public SceneDirector(SceneBuilder builder) => _builder = builder;

        public SceneExportDto Construct(Scene scene)
        {
            return _builder
                .SetSceneName(scene.Name)
                .AddObjects(scene.Objects)
                .Build();
        }
    }
}
