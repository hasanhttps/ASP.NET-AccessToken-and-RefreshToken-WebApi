using ECommerce.Domain.Entities.Abstracts;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Repositories;

public interface IWriteGenericRepository<T>: IGenericRepository<T> where T : class, IBaseEntity, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task DeleteAsync(T entity);
    Task SaveChangeAsync();
}
