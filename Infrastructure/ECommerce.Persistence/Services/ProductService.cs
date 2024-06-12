using ECommerce.Application.Repositories;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Domain.ViewModels;
using ECommerce.Application.Extentions;
using System.Net;

namespace ECommerce.Persistence.Services;

public class ProductService : IProductService
{
    private readonly IReadProductRepository _readProductRepo;
    private readonly IWriteProductRepository _writeProductRepo;
    private readonly IReadCategoryRepository _readCategoryRepo;

    public ProductService(IReadProductRepository readProductRepo, IWriteProductRepository writeProductRepo, IReadCategoryRepository readCategoryRepo)
    {
        _readProductRepo = readProductRepo;
        _writeProductRepo = writeProductRepo;
        _readCategoryRepo = readCategoryRepo;
        
    }

    public async Task AddProductAsync(AddProductVM productVM)
    {
        var product = new Product()
        {
            Name = productVM.Name,
            Price = productVM.Price,
            Description = productVM.Description,
            CategoryId = productVM.CategoryId,
        };

        await _writeProductRepo.AddAsync(product);
        await _writeProductRepo.SaveChangeAsync();
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        var product = await _readProductRepo.GetByIdAsync(productId);
        if (product == null)
            return false;

        await _writeProductRepo.DeleteAsync(product);
        await _writeProductRepo.SaveChangeAsync();
        return true;
    }

    public async Task<ICollection<GetProductVM>> GetAllProductsAsync(PaginationVM paginationVM)
    {
        var products = await _readProductRepo.GetAllAsync();
        var prodcutForPage = products.ToList().Paginate(paginationVM.Page);


        var allProductVm = prodcutForPage.Select(p => new GetProductVM()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            CategoryName = p.Category.Name,
            ImageUrl = p.ImageUrl,
            Stock = p.Stock
        }).ToList();
        return allProductVm;
    }

    public async Task<GetProductVM?> GetProductByIdAsync(int id)
    {
        var product = await _readProductRepo.GetByIdAsync(id);
        if (product == null)
            return null;

        var productVm = new GetProductVM()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryName = product.Category.Name,
            ImageUrl = product.ImageUrl,
            Stock = product.Stock
        };
        return productVm;
    }

    public async Task<HttpStatusCode> UpdateProductAsync(int id, UpdateProductVM productVM)
    {
        var product = await _readProductRepo.GetByIdAsync(id);
        if (product == null)
            return HttpStatusCode.NotFound;

        var category = await _readCategoryRepo.GetByIdAsync(productVM.CategoryId);
        if (category == null)
            return HttpStatusCode.NotFound;

        product.Name = productVM.Name;
        product.Price = productVM.Price;
        product.Description = productVM.Description;
        product.CategoryId = productVM.CategoryId;

        await _writeProductRepo.UpdateAsync(product);
        await _writeProductRepo.SaveChangeAsync();
        return HttpStatusCode.OK;
    }
}
