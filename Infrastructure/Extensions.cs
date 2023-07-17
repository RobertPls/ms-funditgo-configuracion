
using Application;
using Application.Services;
using Application.UseCases.Consumers;
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
using MassTransit;
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

        AddRabbitMq(services, configuration);
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
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqHost = configuration["RabbitMq:Host"];
        var rabbitMqPort = configuration["RabbitMq:Port"];
        var rabbitMqUserName = configuration["RabbitMq:UserName"];
        var rabbitMqPassword = configuration["RabbitMq:Password"];

        services.AddMassTransit(config =>
        {
            config.AddConsumer<ProyectoCreadoConsumer>().Endpoint(endpoint => endpoint.Name = ProyectoCreadoConsumer.QueueName);

            config.UsingRabbitMq((context, cfg) =>
            {
                var uri = string.Format("amqps://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort);
                cfg.Host(uri);

                cfg.ReceiveEndpoint(ProyectoCreadoConsumer.QueueName, endpoint =>
                {
                    endpoint.ConfigureConsumer<ProyectoCreadoConsumer>(context);
                });
            });
        }
        );
    }
}