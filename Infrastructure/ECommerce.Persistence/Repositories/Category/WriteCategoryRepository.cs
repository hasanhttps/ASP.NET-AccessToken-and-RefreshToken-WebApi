using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories.Common;

namespace ECommerce.Persistence.Repositories;

public class WriteCategoryRepository : WriteGenericRepository<Category>, IWriteCategoryRepository
{
    public WriteCategoryRepository(ECommerceDbContext context) : base(context)
    {
    }
}

