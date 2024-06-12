using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Abstracts;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories.Common;

public class WriteGenericRepository<T> : GenericRepository<T>, IWriteGenericRepository<T> where T : class, IBaseEntity, new()
{
    public WriteGenericRepository(ECommerceDbContext context) :
        base(context)
    {
    }


    public async Task AddAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _table.AddRangeAsync(entities);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
            _table.Remove(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _table.Remove(entity);
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _table.Update(entity);
    }
}
