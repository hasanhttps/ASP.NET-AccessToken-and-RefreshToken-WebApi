using ECommerce.Application.Behaviors.Query.Product.GetAll;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Application;

public static class RegisterServices
{
    public static void AddApplicationRegister(this IServiceCollection services)
    {
        services.AddMediatR(p=>p.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
