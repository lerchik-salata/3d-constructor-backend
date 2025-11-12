using ConstructorApi.Models;
using ConstructorApi.Repositories;

namespace ConstructorApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            return await _projectRepository.AddAsync(project);
        }

        public async Task<Project?> UpdateProjectAsync(int id, Project updatedProject)
        {
            var existingProject = await _projectRepository.GetByIdAsync(id);
            
            if (existingProject == null)
            {
                return null; 
            }

            existingProject.Name = updatedProject.Name ?? existingProject.Name;
            existingProject.Description = updatedProject.Description ?? existingProject.Description;
            
            return await _projectRepository.UpdateAsync(existingProject);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return false;
            }

            await _projectRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Project>> GetProjectsByUserIdAsync(string userId) =>
            await _projectRepository.GetByUserIdAsync(userId);
    }

    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project project);
        Task<Project?> UpdateProjectAsync(int id, Project updatedProject);
        Task<bool> DeleteProjectAsync(int id);
        Task<IEnumerable<Project>> GetProjectsByUserIdAsync(string userId);
    }
}