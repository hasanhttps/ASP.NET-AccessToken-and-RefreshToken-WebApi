using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories.Common;

namespace ECommerce.Persistence.Repositories;

public class WriteAppUserRepository : WriteGenericRepository<AppUser>, IWriteAppUserRepository
{
    public WriteAppUserRepository(ECommerceDbContext context) : base(context)
    {
    }
}

