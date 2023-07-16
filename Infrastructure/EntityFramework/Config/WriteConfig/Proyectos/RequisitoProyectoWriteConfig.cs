using Domain.Model.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Proyectos
{
    internal class RequisitoProyectoWriteConfig : IEntityTypeConfiguration<RequisitoProyecto>
    {
        public void Configure(EntityTypeBuilder<RequisitoProyecto> builder)
        {
            builder.ToTable("RequisitoProyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RequerimientoId).HasColumnName("requerimientoId");
            builder.Property(x => x.ArchivoId).HasColumnName("archivoId");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
