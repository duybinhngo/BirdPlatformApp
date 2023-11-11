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
        public Task<bool> CreateAsync(T entity);
        public Task<T> CreateAsync(T entity, bool returnBool = true);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
    }
}
