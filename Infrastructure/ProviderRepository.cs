using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public async Task<Provider?> GetProviderById(int id)
        {
            return await _context.Providers.Where(x => x.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<Provider>?> GetProviderByName(string name)
        {
            return await _context.Providers.Where(x => name.Contains(x.ProviderName)).ToListAsync();
        }
    }
}
