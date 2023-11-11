using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetCategoriesAsync(string? search);
    }
}
