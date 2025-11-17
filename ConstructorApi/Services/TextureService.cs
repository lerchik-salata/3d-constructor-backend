using ConstructorApi.Models;
using ConstructorApi.Repositories;

namespace ConstructorApi.Services
{
    public class TextureService : ITextureService
    {
        private readonly ITextureRepository _repo;
        private readonly IGoogleDriveService _drive;

        public TextureService(ITextureRepository repo, IGoogleDriveService drive)
        {
            _repo = repo;
            _drive = drive;
        }

        public async Task<IEnumerable<Texture>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Texture> CreateAsync(string name, IFormFile image)
        {
            var url = await _drive.UploadFileAsync(image);

            var tex = new Texture
            {
                Name = name,
                ImageUrl = url
            };

            return await _repo.AddAsync(tex);
        }

        public async Task<Texture?> UpdateAsync(int id, string name, IFormFile? image)
        {
            var tex = await _repo.GetByIdAsync(id);
            if (tex == null) return null;

            tex.Name = name;

            if (image != null)
                tex.ImageUrl = await _drive.UploadFileAsync(image);

            return await _repo.UpdateAsync(tex);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }

    public interface ITextureService
    {
        Task<IEnumerable<Texture>> GetAllAsync();
        Task<Texture> CreateAsync(string name, IFormFile image);
        Task<Texture?> UpdateAsync(int id, string name, IFormFile? image);
        Task<bool> DeleteAsync(int id);
    }
}
