using Domain.Factory.Proyectos;
using Domain.Factory.Requisitos;
using Domain.Factory.TiposProyectos;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IProyectoFactory, ProyectoFactory>();
        services.AddScoped<IRequerimientoFactory, RequerimientoFactory>();
        services.AddScoped<ITipoProyectoFactory, TipoProyectoFactory>();
        return services;
    }
}

