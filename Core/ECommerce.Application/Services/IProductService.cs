using ECommerce.Domain.ViewModels;
using System.Net;

namespace ECommerce.Application.Services;

public interface IProductService
{
    Task<ICollection<GetProductVM>> GetAllProductsAsync(PaginationVM paginationVM);
    Task<GetProductVM?> GetProductByIdAsync(int productId);
    Task AddProductAsync(AddProductVM productVM);
    Task<HttpStatusCode> UpdateProductAsync(int id,UpdateProductVM updateProductVM);
    Task<bool> DeleteProductAsync(int productId);
}
