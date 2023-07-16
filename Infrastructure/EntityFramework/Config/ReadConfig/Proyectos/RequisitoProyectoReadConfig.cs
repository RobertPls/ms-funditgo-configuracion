using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class RequisitoProyectoReadConfig : IEntityTypeConfiguration<RequisitoProyectoReadModel>
    {
        public void Configure(EntityTypeBuilder<RequisitoProyectoReadModel> builder)
        {
            builder.ToTable("RequisitoProyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.ProyectoId).HasColumnName("proyectoId");

            builder.Property(x => x.ArchivoId).HasColumnName("archivoId");
            builder.HasOne(x => x.Archivo).WithMany().HasForeignKey(x => x.ArchivoId);

            builder.Property(x => x.RequerimientoId).HasColumnName("requerimientoId");
            builder.HasOne(x => x.Requerimiento).WithMany().HasForeignKey(x => x.RequerimientoId);

        }
    }
}
