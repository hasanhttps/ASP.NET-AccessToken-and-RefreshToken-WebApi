using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class ReadCategoryRepository : ReadGenericRepository<Category>, IReadCategoryRepository
{
    public ReadCategoryRepository(ECommerceDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> AllProductByCategory(int categoryId)
    {
        var products = _table.Include(x => x.Products).FirstOrDefault(x => x.Id == categoryId)?.Products;
        return products;
    }
}
