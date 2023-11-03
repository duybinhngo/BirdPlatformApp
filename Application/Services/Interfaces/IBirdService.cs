using Entity = Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IBirdService
    {
        Task<List<Entity::BirdService>> GetAsync(string? search);
        Task<Entity::BirdService> GetByIdAsync(int id);
        Task<Entity::BirdService> CreateAsync(Entity::BirdService birdService);
    }
}
