using ConstructorApi.Data;
using ConstructorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructorApi.Repositories
{
    public class SceneRepository : ISceneRepository
    {
        private readonly ApplicationDbContext _context;

        public SceneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> ProjectExistsAsync(int projectId)
        {
            return await _context.Projects.AnyAsync(p => p.Id == projectId);
        }

        public async Task<IEnumerable<Scene>> GetScenesByProjectIdAsync(int projectId)
        {
            return await _context.Scenes
                .Where(s => s.ProjectId == projectId)
                .Include(s => s.Objects)
                .ToListAsync();
        }

        public async Task<Scene?> GetSceneWithObjectsAsync(int projectId, int sceneId)
        {
            return await _context.Scenes
                .Where(s => s.Id == sceneId && s.ProjectId == projectId)
                .Include(s => s.Objects) 
                .FirstOrDefaultAsync();
        }

        public async Task<Scene> AddSceneAsync(Scene scene)
        {
            _context.Scenes.Add(scene);
            await _context.SaveChangesAsync();
            return scene;
        }

        public async Task<Scene> UpdateSceneAsync(Scene scene)
        {
            await _context.SaveChangesAsync();
            return scene;
        }

        public async Task DeleteSceneAsync(Scene scene)
        {
            _context.Scenes.Remove(scene);
            await _context.SaveChangesAsync();
        }
    }

    public interface ISceneRepository
    {
        Task<Scene?> GetSceneWithObjectsAsync(int projectId, int sceneId);
        Task<IEnumerable<Scene>> GetScenesByProjectIdAsync(int projectId);
        Task<Scene> AddSceneAsync(Scene scene);
        Task<Scene> UpdateSceneAsync(Scene scene);
        Task DeleteSceneAsync(Scene scene);
        Task<bool> ProjectExistsAsync(int projectId);
    }
}