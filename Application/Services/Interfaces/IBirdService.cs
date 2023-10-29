using Entity = Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IBirdService
    {
        Task<List<Entity::BirdService>> GetAsync();
    }
}
