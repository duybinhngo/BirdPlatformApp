using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public class BirdServiceRepository : RepositoryBase<BirdService>, IBirdServiceRepository
    {
        public async Task<IEnumerable<BirdService>?> GetBirdServicesByName(string name)
        {
            return await _context.BirdServices.Where(x => name.Contains(x.ProductName)).ToListAsync();
        }
        public async Task<IEnumerable<BirdService>?> GetBirdServicesByProviderName(string name)
        {
            return await _context.BirdServices.Where(x => name.Contains(x.Provider.ProviderName)).ToListAsync();
        }
        public async Task<BirdService> GetBirdServiceById(int id)
        {
            return await _context.BirdServices.Where(x => x.Id == id).FirstAsync();
        }
    }
}
