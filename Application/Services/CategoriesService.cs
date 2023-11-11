using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<List<Category>> GetCategoriesAsync(string? search)
        {
            return await categoryRepository.GetAll().Where(x => x.Name.Contains(search)).ToListAsync();
        }
    }
}
