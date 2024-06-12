using ECommerce.Domain.Entities.Common;
using System.Text.Json.Serialization;

namespace ECommerce.Domain.Entities.Concretes;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public string? ImageUrl { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }

    // Navigation Property
    public virtual Category Category { get; set; }
}
