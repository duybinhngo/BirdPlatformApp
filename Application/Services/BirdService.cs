using Entity = Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;
using Application.Services.Interfaces;

namespace Application.Services
{
    public class BirdService : IBirdService
    {
        private readonly IBirdServiceRepository birdServiceRepository;
        private readonly IProviderRepository providerRepository;
        private readonly IScheduleRepository scheduleRepository;

        public BirdService(
            IBirdServiceRepository birdServiceRepository,
            IProviderRepository providerRepository,
            IScheduleRepository scheduleRepository)
        {
            this.birdServiceRepository = birdServiceRepository;
            this.providerRepository = providerRepository;
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<List<Entity::BirdService>> GetAsync()
        {
            return await birdServiceRepository.GetAll().Include("Provider").Include("Schedules").ToListAsync();
        }
    }
}
