using ChatGroup.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChatGroup.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal ChatGroupDbContext _context;
        public Repository(ChatGroupDbContext context)
        {
            this._context = context;
        }
        public virtual async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);

        public virtual Task Update(T entity) 
        { 
            _context.Entry(entity).State = EntityState.Modified; 
            return Task.CompletedTask; 
        }

        public virtual Task Delete(T entity)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }
        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (Expression<Func<T, object>> i in includes)
            {
                query = query.Include(i);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().Where(predicate);
            foreach (Expression<Func<T, object>> i in includes)
            {
                query = query.Include(i);
            }
            return await query.ToListAsync();
        }
        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();
    }
}
