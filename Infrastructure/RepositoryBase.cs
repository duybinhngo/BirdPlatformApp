using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly BirdPlatformContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase()
        {
            _context = new BirdPlatformContext();
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T> CreateAsync(T entity, bool returnEntity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var entry = _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
