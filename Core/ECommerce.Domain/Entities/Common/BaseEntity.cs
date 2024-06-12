using ECommerce.Domain.Entities.Abstracts;

namespace ECommerce.Domain.Entities.Common;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
