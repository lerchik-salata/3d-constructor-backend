using ConstructorApi.Data;
using ConstructorApi.Models;
using ConstructorApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstructorApi.Repositories
{
    public class SceneRepository : Repository<Scene>, ISceneRepository
    {
        public SceneRepository(ApplicationDbContext context) : base(context)
        {
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
    }

    public interface ISceneRepository : IRepository<Scene>
    {
        Task<Scene?> GetSceneWithObjectsAsync(int projectId, int sceneId);
        Task<IEnumerable<Scene>> GetScenesByProjectIdAsync(int projectId);
    }
}