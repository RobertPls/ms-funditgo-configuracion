using Domain.Model.Proyectos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Proyectos
{
    internal class ProyectoWriteConfig : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            var tituloConverter = new ValueConverter<TituloValue, string>(
                tituloValue => tituloValue.Titulo,
                stringValue => new TituloValue(stringValue)
            );

            builder.ToTable("Proyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Titulo).HasColumnName("titulo").HasConversion(tituloConverter);
            builder.Property(x => x.Estado).HasColumnName("estado");
            builder.Property(x => x.TipoProyectoId).HasColumnName("tipoProyectoId");
            builder.Property(x => x.CreadorId).HasColumnName("creadorId");


            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
