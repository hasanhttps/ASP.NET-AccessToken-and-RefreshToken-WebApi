using ECommerce.Domain.Entities.Concretes;
namespace ECommerce.Application.Repositories;

public interface IReadCategoryRepository : IReadGenericRepository<Category>
{
    Task<IEnumerable<Product>> AllProductByCategory(int categoryId);
}
