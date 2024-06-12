using Microsoft.EntityFrameworkCore;
using ECommerce.Persistence.DbContexts;
using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.Repositories.Common;

namespace ECommerce.Persistence.Repositories;

public class ReadAppUserRepository : ReadGenericRepository<AppUser>, IReadAppUserRepository {

    // Constructor

    public ReadAppUserRepository(ECommerceDbContext context) : base(context) {

    }


    // Methods

    public async Task<AppUser?> GetUserByEmail(string email) {
        return await _table.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<AppUser?> GetUserByRefreshToken(string refreshToken) {
        return await _table.SingleOrDefaultAsync(p => p.RefreshToken == refreshToken);
    }

    public Task<AppUser?> GetUserByRePasswordToken(string rePasswordToken) {
        return _table.FirstOrDefaultAsync(p => p.RePasswordToken == rePasswordToken);
    }
    public Task<AppUser?> GetUserByConfirmEmailToken(string confirmEmailToken) {
        return _table.FirstOrDefaultAsync(p => p.ConfirmEmailToken == confirmEmailToken);
    }

    public async Task<AppUser?> GetUserByUserName(string userName) {
        return await _table.FirstOrDefaultAsync(p => p.UserName == userName);
    }
}