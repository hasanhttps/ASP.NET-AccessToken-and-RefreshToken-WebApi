using ECommerce.Domain.ViewModels;
using System.Net;

namespace ECommerce.Application.Behaviors.Query.Product.GetAll;

public class GelAllProductQueryResponse
{
    public ICollection<GetProductVM> Products { get; set; }
}
