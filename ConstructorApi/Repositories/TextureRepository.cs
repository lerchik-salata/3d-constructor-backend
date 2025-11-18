using ConstructorApi.Models;
using ConstructorApi.Data;
using ConstructorApi.Repositories.Interfaces;

namespace ConstructorApi.Repositories
{
    public class TextureRepository : Repository<Texture>, ITextureRepository
    {
        public TextureRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public interface ITextureRepository : IRepository<Texture>
    {
    }
}
