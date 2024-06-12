namespace ECommerce.Domain.Helpers;

public class RefreshToken
{
    public string Token { get; set; }
    public DateTime ExpireTime { get; set; }
    public DateTime CreateTime { get; set; } = DateTime.Now;
}
