using ECommerce.Domain.Entities.Concretes;
using ECommerce.Domain.Helpers;

namespace ECommerce.Application.Services;

public interface ITokenService
{
    string CreateAccessToken(AppUser user);
    RefreshToken CreateRefreshToken();
    RefreshToken CreateRepasswordToken();
    RefreshToken CreateConfirmEmailToken();
}
