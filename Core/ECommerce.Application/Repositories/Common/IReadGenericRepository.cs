using ECommerce.Domain.Entities.Abstracts;
using ECommerce.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerce.Application.Repositories;

public interface IReadGenericRepository<T> :IGenericRepository<T> where T : class, IBaseEntity, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(int id);
}
