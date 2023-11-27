using System.Linq.Expressions;

namespace EasyStay.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        T GetSingle(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> FindByAsNoTrackingAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T> GetFirst(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task AddRange(List<T> entity);
        Task Update(T entity);
        Task UpdateRange(List<T> entity);
        Task<T> MapperUpdate(T receiver, T sender);
        Task Delete(T entity);
        Task DeleteRange(List<T> entity);
    }
}
