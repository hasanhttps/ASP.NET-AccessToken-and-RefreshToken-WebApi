using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities.Concretes;

public class Order: BaseEntity
{
    public string? OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string? OrderNote { get; set; }
    public decimal Total { get; set; }

    // Foreign Key
    public int CustomerId { get; set; }

    // Navigation Property
    public virtual ICollection<Product> Products { get; set; }
    public virtual AppUser Customer { get; set; }
}
