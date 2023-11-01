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
        public async Task<IList<BirdService>> GetAllByProviderId(int providerId)
        {
            return await _context.BirdService.Where(x => x.ProviderId == providerId).ToListAsync();
        }
    }
}
