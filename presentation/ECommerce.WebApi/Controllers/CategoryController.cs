using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IWriteCategoryRepository _writeCategoryRepo;
    private readonly IReadCategoryRepository _readCategoryRepo;

    public CategoryController(IWriteCategoryRepository writeCategoryRepo, IReadCategoryRepository readCategoryRepo)
    {
        _writeCategoryRepo = writeCategoryRepo;
        _readCategoryRepo = readCategoryRepo;
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryVM categoryVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = new Category()
        {
            Name = categoryVM.Name,
            Description = categoryVM.Description,
        };

        await _writeCategoryRepo.AddAsync(category);
        await _writeCategoryRepo.SaveChangeAsync();

        return StatusCode(201);
    }


    // All Producyt List
    [HttpPost("AllProductsByCategory")]
    public async Task<IActionResult> GetAllProductsByCategory([FromBody] int categoryId)
    {
        var products = await _readCategoryRepo.AllProductByCategory(categoryId);
        if (products == null)
            return NotFound("Category Not Found");

        var allProductVm = products.Select(p => new GetProductVM()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            CategoryName = p.Category.Name,
            ImageUrl = p.ImageUrl,
            Stock = p.Stock
        }).ToList();

        return Ok(allProductVm);
    }
}
