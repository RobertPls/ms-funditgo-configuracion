using Infrastructure.EntityFramework.Config.ReadConfig.Proyectos;
using Infrastructure.EntityFramework.Config.ReadConfig.Requerimientos;
using Infrastructure.EntityFramework.Config.ReadConfig.TiposProyectos;
using Infrastructure.EntityFramework.ReadModel.Archivos;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.EntityFramework.ReadModel.Requerimientos;
using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Contexts;

internal class ReadDbContext : DbContext
{
    public DbSet<ArchivoReadModel> Archivo { get; set; }
    public DbSet<ProyectoReadModel> Proyecto { get; set; }
    public DbSet<RequisitoProyectoReadModel> RequisitoProyecto { get; set; }
    public DbSet<RequerimientoReadModel> Requerimiento { get; set; }
    public DbSet<RequerimientoTipoReadModel> RequerimientoTipo { get; set; }
    public DbSet<TipoProyectoReadModel> TipoProyecto { get; set; }


    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ProyectoReadConfig());
        builder.ApplyConfiguration(new RequisitoProyectoReadConfig());
        builder.ApplyConfiguration(new RequerimientoTipoReadConfig());
        builder.ApplyConfiguration(new RequerimientoReadConfig());
        builder.ApplyConfiguration(new TipoProyectoReadConfig());
    }
}
