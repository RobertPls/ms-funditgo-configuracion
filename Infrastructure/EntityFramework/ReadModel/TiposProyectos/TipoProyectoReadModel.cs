using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.ReadModel.TiposProyectos
{
    internal class TipoProyectoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<RequerimientoTipoReadModel> RequerimientosTipos{ get; set; }

    }
}
