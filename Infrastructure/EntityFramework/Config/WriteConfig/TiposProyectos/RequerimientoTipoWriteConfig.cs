using Domain.Model.TiposProyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.WriteConfig.TiposProyectos
{
    internal class RequerimientoTipoWriteConfig : IEntityTypeConfiguration<RequerimientoTipo>
    {
        public void Configure(EntityTypeBuilder<RequerimientoTipo> builder)
        {

            builder.ToTable("RequerimientoTipo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Obligatorio).HasColumnName("obligatorio");
            builder.Property(x => x.RequerimientoId).HasColumnName("requerimientoId");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
