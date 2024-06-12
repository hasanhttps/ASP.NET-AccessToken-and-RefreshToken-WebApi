using ECommerce.Domain.Entities.Abstracts;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Repositories;

public interface IGenericRepository<T> where T : class, IBaseEntity, new()
{
}
