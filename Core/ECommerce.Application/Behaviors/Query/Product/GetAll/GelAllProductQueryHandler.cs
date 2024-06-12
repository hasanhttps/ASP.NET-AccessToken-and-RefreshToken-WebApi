
using ECommerce.Application.Extentions;
using ECommerce.Application.Repositories;
using ECommerce.Application.Services;
using ECommerce.Domain.ViewModels;
using MediatR;

namespace ECommerce.Application.Behaviors.Query.Product.GetAll;


public class GelAllProductQueryHandler : IRequestHandler<GelAllProductQueryRequest, GelAllProductQueryResponse>
{
    private readonly IProductService _productService;

    public GelAllProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<GelAllProductQueryResponse> Handle(GelAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var allProductVm = await _productService.GetAllProductsAsync(new PaginationVM() { Page = request.Page, PageSize = request.PageSize });
        return new GelAllProductQueryResponse()
        {
            Products = allProductVm
        };
    }
}









//public class GelAllProductQueryHandler : IRequestHandler<GelAllProductQueryRequest, GelAllProductQueryResponse>
//{
//    private readonly IReadProductRepository _readProductRepo;

//    public GelAllProductQueryHandler(IReadProductRepository readProductRepo)
//    {
//        _readProductRepo = readProductRepo;
//    }

//    public async Task<GelAllProductQueryResponse> Handle(GelAllProductQueryRequest request, CancellationToken cancellationToken)
//    {
//        var products = await _readProductRepo.GetAllAsync();
//        var prodcutForPage = products.ToList().Paginate(request.Page);


//        var allProductVm = prodcutForPage.Select(p => new GetProductVM()
//        {
//            Id = p.Id,
//            Name = p.Name,
//            Price = p.Price,
//            Description = p.Description,
//            CategoryName = p.Category.Name,
//            ImageUrl = p.ImageUrl,
//            Stock = p.Stock
//        }).ToList();

//        return new GelAllProductQueryResponse()
//        {
//            Products = allProductVm
//        };
//    }
//}
