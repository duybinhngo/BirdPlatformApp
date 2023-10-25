using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        public IQueryable<T> GetAll();
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);


    }
}
