using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        public Task<IEnumerable<Category>?> GetCategoryByName(string name);
        public Task<Category> GetCategoryById(int id);

    }
}
