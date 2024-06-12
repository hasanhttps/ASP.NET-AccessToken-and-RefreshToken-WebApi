using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities.Concretes;

public class AppUser : BaseEntity {
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? UserName { get; set; }
    public bool? ConfirmEmail { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }

    // -------------------------------------
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireTime { get; set; }
    public DateTime? RefreshTokenCreateTime { get; set; } = DateTime.Now;
    // -------------------------------------
    // -------------------------------------
    public string? RePasswordToken { get; set; }
    public DateTime? RePasswordTokenExpireTime { get; set; }
    public DateTime? RePasswordTokenCreateTime { get; set; } = DateTime.Now;
    // -------------------------------------
    // -------------------------------------
    public string? ConfirmEmailToken { get; set; }
    public DateTime? ConfirmEmailTokenExpireTime { get; set; }
    public DateTime? ConfirmEmailTokenCreateTime { get; set; } = DateTime.Now;
    // -------------------------------------

    // Navigation Property
    public virtual ICollection<Order> Orders { get; set; }
}
