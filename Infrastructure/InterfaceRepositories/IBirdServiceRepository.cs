using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public interface IBirdServiceRepository : IRepositoryBase<BirdService>
    {
        public Task<IEnumerable<BirdService>?> GetBirdServicesByName(string name);
        public Task<IEnumerable<BirdService>?> GetBirdServicesByProviderName(string name);
        public Task<BirdService> GetBirdServiceById(int id);

    }
}
