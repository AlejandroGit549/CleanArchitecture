using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> pedicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> pedicate = null,
                                        Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTacking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> pedicate = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                List<Expression<Func<T,object>>> includes = null,
                                bool disableTacking = true);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
 