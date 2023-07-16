using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.Config.ReadConfig.TiposProyectos
{
    internal class RequerimientoTipoReadConfig : IEntityTypeConfiguration<RequerimientoTipoReadModel>
    {
        public void Configure(EntityTypeBuilder<RequerimientoTipoReadModel> builder)
        {
            builder.ToTable("RequerimientoTipo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Obligatorio).HasColumnName("obligatorio");

            builder.Property(x => x.TipoProyectoId).HasColumnName("tipoProyectoId");

            builder.Property(x => x.RequerimientoId).HasColumnName("requerimientoId");
            builder.HasOne(x => x.Requerimiento).WithMany().HasForeignKey(x => x.RequerimientoId);
        }
    }
}
