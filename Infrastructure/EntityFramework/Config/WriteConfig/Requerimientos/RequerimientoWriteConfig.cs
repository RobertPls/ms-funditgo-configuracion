using Domain.Model.Requerimientos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Requerimientos
{

    internal class RequerimientoWriteConfig : IEntityTypeConfiguration<Requerimiento>
    {
        public void Configure(EntityTypeBuilder<Requerimiento> builder)
        {
            var nombreRequerimientoConverter = new ValueConverter<NombreRequerimientoValue, string>(
                nombreRequerimientoValue => nombreRequerimientoValue.NombreRequerimiento,
                stringValue => new NombreRequerimientoValue(stringValue)
            );
            builder.ToTable("Requerimiento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre").HasConversion(nombreRequerimientoConverter);

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
