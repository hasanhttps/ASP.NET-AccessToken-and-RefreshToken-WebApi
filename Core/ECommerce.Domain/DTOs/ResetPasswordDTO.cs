using System.ComponentModel.DataAnnotations;

namespace ECommerce.Domain.DTOs;

public class ResetPasswordDTO
{
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
