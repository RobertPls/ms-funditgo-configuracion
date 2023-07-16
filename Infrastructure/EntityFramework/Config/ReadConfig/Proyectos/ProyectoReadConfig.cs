using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class ProyectoReadConfig : IEntityTypeConfiguration<ProyectoReadModel>
    {
        public void Configure(EntityTypeBuilder<ProyectoReadModel> builder)
        {
            builder.ToTable("Proyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Titulo).HasColumnName("titulo");
            builder.Property(x => x.Estado).HasColumnName("estado");
            builder.Property(x => x.CreadorId).HasColumnName("creadorId");

            builder.Property(x => x.TipoProyectoId).HasColumnName("tipoProyectoId");
            builder.HasOne(x => x.TipoProyecto).WithMany().HasForeignKey(x => x.TipoProyectoId);

            builder.HasMany(x => x.Requisitos).WithOne(x => x.Proyecto).HasForeignKey(x => x.ProyectoId);
        }
    }
}
