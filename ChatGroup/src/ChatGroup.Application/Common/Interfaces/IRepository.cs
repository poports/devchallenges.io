using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChatGroup.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes ); 
        Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        
        Task<int> SaveChanges();
    }
}
