using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.TiposProyectos
{
    internal class TipoProyectoReadConfig : IEntityTypeConfiguration<TipoProyectoReadModel>
    {
        public void Configure(EntityTypeBuilder<TipoProyectoReadModel> builder)
        {
            builder.ToTable("TipoProyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
            builder.Property(x => x.Descripcion).HasColumnName("descripcion");

            builder.HasMany(x => x.RequerimientosTipos).WithOne(x => x.TipoProyecto).HasForeignKey(x => x.TipoProyectoId);

        }
    }
}
