using ConstructorApi.Models;
using ConstructorApi.Factories;
using ConstructorApi.Repositories;
using ConstructorApi.Models.Shapes;

namespace ConstructorApi.Services
{   
    public class ShapeService
    {
        private readonly ICustomShapeRepository _repo;

        public ShapeService(ICustomShapeRepository repo)
        {
            _repo = repo;
        }
        
        public IShape GetBasicShape(string type) => ShapeFactory.CreateShape(type);

        public async Task<List<CustomShape>> GetCustomShapes()
        {
            var shapes = await _repo.GetAllAsync();
            return shapes.ToList();
        }

        public List<IShape> GetAllBasicShapes()
        {
            var types = new[] { "cube", "sphere", "cylinder", "cone", "torus", "plane" };
            return types.Select(ShapeFactory.CreateShape).ToList();
        }

        public async Task<CustomShape?> GetCustomShape(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<CustomShape> CreateCustomShape(CustomShape shape)
        {
            return await _repo.AddAsync(shape);
        }

        public async Task<CustomShape> UpdateCustomShape(CustomShape shape)
        {
            await _repo.UpdateAsync(shape);
            return shape; 
        }

        public async Task DeleteCustomShape(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
