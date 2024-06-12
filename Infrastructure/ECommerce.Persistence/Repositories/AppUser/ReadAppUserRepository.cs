using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.DbContexts;
using ECommerce.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class ReadAppUserRepository : ReadGenericRepository<AppUser>, IReadAppUserRepository
{
    public ReadAppUserRepository(ECommerceDbContext context) : base(context)
    {
    }

    public async Task<AppUser?> GetUserByEmail(string email)
    {
        return await _table.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<AppUser?> GetUserByRefreshToken(string refreshToken)
    {
        return await _table.SingleOrDefaultAsync(p => p.RefreshToken == refreshToken);
    }

    public Task<AppUser?> GetUserByRePasswordToken(string rePasswordToken)
    {
        return _table.FirstOrDefaultAsync(p => p.RePasswordToken == rePasswordToken);
    }

    public async Task<AppUser?> GetUserByUserName(string userName)
    {
        return await _table.FirstOrDefaultAsync(p => p.UserName == userName);
    }

}
