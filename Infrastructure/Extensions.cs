
using Application;
using Application.Services;
using Domain.Repository;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Contexts;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core;

namespace Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration,
        bool isProduction)
    {
        services.AddApplication();
        AddDatabase(services, configuration, isProduction);

        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IApplicationFileRepository, ApplicationFileRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isProduction)
    {
        var connectionString = configuration.GetConnectionString("DbConnectionString");

        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseSqlServer(connectionString));

        services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseSqlServer(connectionString));

        using var scope = services.BuildServiceProvider().CreateScope();
        if (isProduction)
        {
            var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
            context.Database.Migrate();
        }
    }
}