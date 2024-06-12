namespace ECommerce.Domain.ViewModels;

public class AddProductVM
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }
}
