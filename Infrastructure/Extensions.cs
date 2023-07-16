
using Application;
using Application.Services;
using Domain.Repository.Archivos;
using Domain.Repository.Proyectos;
using Domain.Repository.Requerimientos;
using Domain.Repository.TiposProyectos;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Contexts;
using Infrastructure.Repository.Archivos;
using Infrastructure.Repository.Proyectos;
using Infrastructure.Repository.Requerimientos;
using Infrastructure.Repository.TiposTipoProyectos;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core;
using System.Reflection;

namespace Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration,bool isProduction)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddApplication();
        AddDatabase(services, configuration, isProduction);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IArchivoRepository, ArchivoRepository>();
        services.AddScoped<IProyectoRepository, ProyectoRepository>();
        services.AddScoped<IRequerimientoRepository, RequerimientoRepository>();
        services.AddScoped<ITipoProyectoRepository, TipoProyectoRepository>();

        return services;
    }

    private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isProduction)
    {
        var connectionString = configuration.GetConnectionString("DbConnectionString");
        services.AddDbContext<WriteDbContext>(ctx =>ctx.UseSqlServer(connectionString));
        services.AddDbContext<ReadDbContext>(ctx =>ctx.UseSqlServer(connectionString));
        using var scope = services.BuildServiceProvider().CreateScope();
        if (isProduction)
        {
            var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
            context.Database.Migrate();
        }
    }
}