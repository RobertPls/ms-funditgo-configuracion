using Infrastructure.EntityFramework.ReadModel.Requerimientos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Requerimientos
{
    internal class RequerimientoReadConfig : IEntityTypeConfiguration<RequerimientoReadModel>
    {
        public void Configure(EntityTypeBuilder<RequerimientoReadModel> builder)
        {
            builder.ToTable("Requerimiento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nombre).HasColumnName("nombre");
        }
    }
}
