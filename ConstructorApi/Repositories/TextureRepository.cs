using ConstructorApi.Models;
using ConstructorApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ConstructorApi.Repositories
{
    public class TextureRepository : ITextureRepository
    {
        private readonly ApplicationDbContext _context;

        public TextureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Texture>> GetAllAsync() =>
            await _context.Textures.ToListAsync();

        public async Task<Texture?> GetByIdAsync(int id) =>
            await _context.Textures.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Texture> AddAsync(Texture texture)
        {
            _context.Textures.Add(texture);
            await _context.SaveChangesAsync();
            return texture;
        }

        public async Task<Texture> UpdateAsync(Texture texture)
        {
            _context.Textures.Update(texture);
            await _context.SaveChangesAsync();
            return texture;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tex = await _context.Textures.FindAsync(id);
            if (tex == null) return false;

            _context.Textures.Remove(tex);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    public interface ITextureRepository
    {
        Task<IEnumerable<Texture>> GetAllAsync();
        Task<Texture?> GetByIdAsync(int id);
        Task<Texture> AddAsync(Texture texture);
        Task<Texture> UpdateAsync(Texture texture);
        Task<bool> DeleteAsync(int id);
    }
}
