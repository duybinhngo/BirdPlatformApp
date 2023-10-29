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

        public async Task<List<Provider>> GetAsync()
        {
            return await providerRepository.GetAll().ToListAsync();
        }
    }
}
