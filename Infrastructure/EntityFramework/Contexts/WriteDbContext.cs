using Domain.Model.Archivos;
using Domain.Model.Proyectos;
using Domain.Model.Requerimientos;
using Domain.Model.TipoProyecto;
using Domain.Model.TiposProyectos;
using Infrastructure.EntityFramework.Config.WriteConfig.Archivos;
using Infrastructure.EntityFramework.Config.WriteConfig.Proyectos;
using Infrastructure.EntityFramework.Config.WriteConfig.Requerimientos;
using Infrastructure.EntityFramework.Config.WriteConfig.TiposProyectos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Contexts;

internal class WriteDbContext : DbContext
{
    public virtual DbSet<Archivo> Archivo { get; set; }
    public virtual DbSet<Proyecto> Proyecto { get; set; }
    public virtual DbSet<RequisitoProyecto> RequisitoProyecto { get; set; }
    public virtual DbSet<Requerimiento> Requerimiento { get; set; }
    public virtual DbSet<RequerimientoTipo> RequerimientoTipo { get; set; }
    public virtual DbSet<TipoProyecto> TipoProyecto { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ArchivoWriteConfig());
        modelBuilder.ApplyConfiguration(new ProyectoWriteConfig());
        modelBuilder.ApplyConfiguration(new RequisitoProyectoWriteConfig());
        modelBuilder.ApplyConfiguration(new RequerimientoTipoWriteConfig());
        modelBuilder.ApplyConfiguration(new TipoProyectoWriteConfig());
        modelBuilder.ApplyConfiguration(new RequerimientoWriteConfig());
    }
}
