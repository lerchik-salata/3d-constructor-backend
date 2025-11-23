using ConstructorApi.Data;
using ConstructorApi.Models;
using ConstructorApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConstructorApi.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)  {}
        
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetByUserIdAsync(string userId)
        {
            return await _context.Projects
                .Where(p => p.UserId == userId)
                .Include(p => p.Scenes)
                .Include(p => p.Settings)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Settings)
                .Include(p => p.Scenes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }

    public interface IProjectRepository : IRepository<Project>
    {
            Task<bool> ExistsAsync(int id);
            Task<IEnumerable<Project>> GetByUserIdAsync(string userId);
    }
}