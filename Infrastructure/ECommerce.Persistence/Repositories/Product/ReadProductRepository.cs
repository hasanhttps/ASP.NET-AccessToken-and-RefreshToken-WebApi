using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories.Common;

namespace ECommerce.Persistence.Repositories;

public class ReadProductRepository : ReadGenericRepository<Product>, IReadProductRepository
{
    public ReadProductRepository(ECommerceDbContext context) : base(context)
    {
    }
}
