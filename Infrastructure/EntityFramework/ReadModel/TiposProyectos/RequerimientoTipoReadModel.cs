using Infrastructure.EntityFramework.ReadModel.Requerimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.ReadModel.TiposProyectos
{
    internal class RequerimientoTipoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool Obligatorio { get; private set; }
        public TipoProyectoReadModel TipoProyecto { get; set; }
        public Guid TipoProyectoId { get; set; }
        public RequerimientoReadModel Requerimiento { get; set; }
        public Guid RequerimientoId { get; set; }
    }
}
