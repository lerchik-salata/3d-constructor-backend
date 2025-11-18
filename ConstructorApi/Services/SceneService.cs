using ConstructorApi.Models;
using ConstructorApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructorApi.Services
{

    public class SceneService : ISceneService
    {
        private readonly ISceneRepository _sceneRepository;
        private readonly IProjectRepository _projectRepository; 

        public SceneService(ISceneRepository sceneRepository, IProjectRepository projectRepository)
        {
            _sceneRepository = sceneRepository;
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Scene>?> GetScenesByProjectIdAsync(int projectId)
        {
            if (!await _projectRepository.ExistsAsync(projectId)) 
            {
                return null;
            }
            return await _sceneRepository.GetScenesByProjectIdAsync(projectId);
        }

        public async Task<Scene?> GetSceneByIdAsync(int projectId, int sceneId)
        {
            return await _sceneRepository.GetSceneWithObjectsAsync(projectId, sceneId);
        }

        public async Task<Scene?> CreateSceneAsync(int projectId, Scene newScene)
        {
            if (!await _projectRepository.ExistsAsync(projectId))
            {
                return null;
            }
            
            newScene.ProjectId = projectId;
            
            if (newScene.Objects != null)
            {
                foreach (var obj in newScene.Objects)
                {
                    obj.Id = 0; 
                }
            }
            
            return await _sceneRepository.AddAsync(newScene);
        }

        public async Task<Scene?> UpdateSceneAsync(int projectId, int sceneId, Scene updatedScene)
        {
            var existingScene = await _sceneRepository.GetSceneWithObjectsAsync(projectId, sceneId);
            
            if (existingScene == null)
            {
                return null; 
            }
            
            existingScene.Name = updatedScene.Name;

            if (existingScene.Objects != null)
            {
                existingScene.Objects ??= new List<SceneObject>();
                existingScene.Objects.Clear();
            }

            if (updatedScene.Objects != null)
            {
                foreach (var obj in updatedScene.Objects)
                {
                    obj.Id = 0; 
                    existingScene.Objects.Add(obj);
                }
            }

            return await _sceneRepository.UpdateAsync(existingScene);
        }

        public async Task<bool> DeleteSceneAsync(int projectId, int sceneId)
        {
            var scene = await _sceneRepository.GetSceneWithObjectsAsync(projectId, sceneId);
            
            if (scene == null)
            {
                return false;
            }

            await _sceneRepository.DeleteAsync(sceneId);
            return true;
        }
    }

    public interface ISceneService
    {
        Task<IEnumerable<Scene>?> GetScenesByProjectIdAsync(int projectId);
        Task<Scene?> GetSceneByIdAsync(int projectId, int sceneId);
        Task<Scene?> CreateSceneAsync(int projectId, Scene newScene);
        Task<Scene?> UpdateSceneAsync(int projectId, int sceneId, Scene updatedScene);
        Task<bool> DeleteSceneAsync(int projectId, int sceneId);
    }
}