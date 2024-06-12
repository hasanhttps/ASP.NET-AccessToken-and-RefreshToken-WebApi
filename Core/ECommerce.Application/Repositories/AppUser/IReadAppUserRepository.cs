using ECommerce.Domain.Entities.Concretes;

namespace ECommerce.Application.Repositories;

public interface IReadAppUserRepository : IReadGenericRepository<AppUser>
{
    Task<AppUser?> GetUserByEmail(string email);
    Task<AppUser?> GetUserByUserName(string userName);
    Task<AppUser?> GetUserByRefreshToken(string refreshToken);
    Task<AppUser?> GetUserByRePasswordToken(string rePasswordToken);
    Task<AppUser?> GetUserByConfirmEmailToken(string confirmEmailToken);
}
