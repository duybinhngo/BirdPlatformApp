using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public interface IProviderRepository : IRepositoryBase<Provider>
    {
        public Task<Provider?> GetProviderById(int id);
        public Task<IEnumerable<Provider>?> GetProviderByName(string name);
    }
}
