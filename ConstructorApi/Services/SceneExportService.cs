using ConstructorApi.Models;
using ConstructorApi.DTOs.Scene;
using ConstructorApi.Builders;
using System.Text.Json;

namespace ConstructorApi.Services
{
    public interface ISceneExportService
    {
        SceneExportDto ExportScene(Scene scene);
        SceneExportDto ImportScene(string json);
    }

    public class SceneExportService : ISceneExportService
    {
        public SceneExportDto ExportScene(Scene scene)
        {
            var builder = new SceneBuilder();
            var director = new SceneDirector(builder);
            return director.Construct(scene);
        }

        public SceneExportDto ImportScene(string json)
        {
            var dto = JsonSerializer.Deserialize<SceneExportDto>(json)
                      ?? throw new InvalidOperationException("Invalid JSON for scene import");
            return dto;
        }
    }
}
