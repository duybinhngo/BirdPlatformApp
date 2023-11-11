using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public class CatogoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public async Task<IEnumerable<Category>?> GetCategoryByName(string name)
        {
            return await _context.Categories.Where(x => name.Contains(x.Name)).ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.Where(x => x.Id == id).FirstAsync();
        }
    }
}
