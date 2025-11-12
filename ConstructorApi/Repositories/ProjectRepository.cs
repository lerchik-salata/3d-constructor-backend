using ConstructorApi.Data;
using ConstructorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstructorApi.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Scenes)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project?> UpdateAsync(Project project)
        {
            var existingProject = await _context.Projects.FindAsync(project.Id);
            if (existingProject == null) return null;

            _context.Entry(existingProject).CurrentValues.SetValues(project);
            await _context.SaveChangesAsync();
            return existingProject;
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
        
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
    }

    public interface IProjectRepository
    {
            Task<IEnumerable<Project>> GetAllAsync();
            Task<Project?> GetByIdAsync(int id);
            Task<Project> AddAsync(Project project);
            Task<Project?> UpdateAsync(Project project);
            Task DeleteAsync(int id);
            Task<bool> ExistsAsync(int id);
            Task<IEnumerable<Project>> GetByUserIdAsync(string userId);
    }
}