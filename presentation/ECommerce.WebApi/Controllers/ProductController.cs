using ECommerce.Application.Behaviors.Query.Product.GetAll;
using ECommerce.Application.Repositories;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Text.Json;

namespace ECommerce.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
[Authorize(Roles ="Admin")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMediator _mediator;

    public ProductController(IProductService productService, IMediator mediator)
    {
        _productService = productService;
        _mediator = mediator;
    }

    //[HttpGet("AllProducts")]
    //public async Task<IActionResult> GetAll([FromQuery] PaginationVM paginationVM)
    //{
    //    var allProductVm = await _productService.GetAllProductsAsync(paginationVM);
    //    return Ok(allProductVm);
    //}


    [HttpGet("AllProducts")]
    public async Task<IActionResult> GetAll([FromQuery] GelAllProductQueryRequest request)
    {
        GelAllProductQueryResponse? response = await _mediator.Send(request);
        return response.Products.Count == 0 ? NotFound("Product Not Found") : Ok(response.Products);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductVM productVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _productService.AddProductAsync(productVM);
        return StatusCode(201);
    }

    // Delete product (By id)
    [HttpDelete("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (await _productService.DeleteProductAsync(id) == false)
            return NotFound("Product Not Found");
        return StatusCode(204);
    }
    // Update product (By id)
    [HttpPut("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductVM productVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _productService.UpdateProductAsync(id, productVM);
        return StatusCode((int)result);
    }

    // Get product (By id)
    [HttpGet("GetProduct/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var productVm = await _productService.GetProductByIdAsync(id);
        if (productVm == null)
            return NotFound("Product Not Found");
        return Ok(productVm);
    }
}
