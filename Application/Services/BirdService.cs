using Entity = Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;
using Application.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class BirdService : IBirdService
    {
        private readonly IBirdServiceRepository birdServiceRepository;
        private readonly IProviderRepository providerRepository;

        public BirdService(
            IBirdServiceRepository birdServiceRepository,
            IProviderRepository providerRepository)
        {
            this.birdServiceRepository = birdServiceRepository;
            this.providerRepository = providerRepository;
        }

        public async Task<List<Entity::BirdService>> GetAsync(string? search)
        {
            
            var model = await birdServiceRepository.GetAll()
                .Include("Provider").Include("Category").Include("Feedbacks")
                .Where(x => x.Category.Name.ToLower().Contains(search!.ToLower())
                        || x.Description.ToLower().Contains(search.ToLower())
                        || x.Provider.ProviderName.ToLower().Contains(search.ToLower()))
                .ToListAsync();
            return model;
        }

        public async Task<Entity.BirdService> GetByIdAsync(int id)
        {
            var model = await birdServiceRepository.GetAll().SingleOrDefaultAsync(x => x.Id == id);
            return model;
        }
    }
}
