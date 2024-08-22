using FAN.Model.Entities;
using System.Linq.Expressions;

namespace FAN.Infrastructure.Persistence.Repositories
{
    public interface IRepository<T> : IDisposable where T : Base
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
    }
}
