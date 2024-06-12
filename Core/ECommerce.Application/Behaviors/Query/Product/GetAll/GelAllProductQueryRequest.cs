using MediatR;
namespace ECommerce.Application.Behaviors.Query.Product.GetAll;

public class GelAllProductQueryRequest: IRequest<GelAllProductQueryResponse>
{
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}
