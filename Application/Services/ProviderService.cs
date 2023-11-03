using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository providerRepository;
        public ProviderService(IProviderRepository providerRepository)
        {
            this.providerRepository = providerRepository;
        }

        public async Task<List<Provider>> GetAsync(string? search)
        {
            return await providerRepository.GetAll().Where(x => x.ProviderName.Contains(search)).ToListAsync();
        }

        public async Task<Provider> GetAsyncByEmail(string email)
        {
            return await providerRepository.GetAll().SingleOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}
