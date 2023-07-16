using Domain.Model.TipoProyecto;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.TiposProyectos
{
    internal class TipoProyectoWriteConfig : IEntityTypeConfiguration<TipoProyecto>
    {
        public void Configure(EntityTypeBuilder<TipoProyecto> builder)
        {
            var descripcionConverter = new ValueConverter<DescripcionValue, string>(
                descripcionValue => descripcionValue.Descripcion,
                stringValue => new DescripcionValue(stringValue)
            );
            var tituloConverter = new ValueConverter<TituloValue, string>(
                tituloValue => tituloValue.Titulo,
                stringValue => new TituloValue(stringValue)
            );

            builder.ToTable("TipoProyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre").HasConversion(tituloConverter);
            builder.Property(x => x.Descripcion).HasColumnName("descripcion").HasConversion(descripcionConverter);

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
