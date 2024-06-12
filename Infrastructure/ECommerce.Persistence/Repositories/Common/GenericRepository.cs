
using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Abstracts;
using ECommerce.Domain.Entities.Common;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories.Common;

public class GenericRepository<T>:IGenericRepository<T> where T : class,IBaseEntity, new()
{
    protected readonly ECommerceDbContext _context;
    protected DbSet<T> _table;

    public GenericRepository(ECommerceDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
}
