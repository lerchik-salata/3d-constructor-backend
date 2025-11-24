using ConstructorApi.Data;
using ConstructorApi.Models;
using ConstructorApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructorApi.Repositories
{
    public class CustomShapeRepository : Repository<CustomShape>, ICustomShapeRepository
    {
        public CustomShapeRepository(ApplicationDbContext context) : base(context) { }

        public async Task<CustomShape?> GetByNameAsync(string name)
        {
            return await _context.Set<CustomShape>()
                .FirstOrDefaultAsync(s => s.Name == name);
        }
    }

    public interface ICustomShapeRepository : IRepository<CustomShape>
    {
        Task<CustomShape?> GetByNameAsync(string name);
    }
}
