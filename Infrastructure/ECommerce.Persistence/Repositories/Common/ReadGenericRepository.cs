
using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Abstracts;
using ECommerce.Domain.Entities.Common;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Persistence.Repositories.Common;

public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity, new()
{
    public ReadGenericRepository(ECommerceDbContext context) 
        : base(context)
    {
    }


    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _table;
    }

    public async Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
    {
        return _table.Where(expression);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _table.FirstOrDefaultAsync(x => x.Id == id);
    }
}
