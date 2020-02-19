using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericInterface<T> : IDisposable where T : class
    {
        void Delete(T entity);
        void Delete(long id);
        T Get(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Update(T entity);
    }
}