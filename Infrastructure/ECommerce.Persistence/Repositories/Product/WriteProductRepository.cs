
using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories.Common;

namespace ECommerce.Persistence.Repositories;

public class WriteProductRepository : WriteGenericRepository<Product>, IWriteProductRepository
{
    public WriteProductRepository(ECommerceDbContext context) : base(context)
    {
    }
}