using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories.Common;

namespace ECommerce.Persistence.Repositories;

public class WriteOrderRepository : WriteGenericRepository<Order>, IWriteOrderRepository
{
    public WriteOrderRepository(ECommerceDbContext context) : base(context)
    {
    }
}
