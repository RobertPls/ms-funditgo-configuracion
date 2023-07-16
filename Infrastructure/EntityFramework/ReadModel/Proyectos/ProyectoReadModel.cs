using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class ProyectoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CreadorId { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public TipoProyectoReadModel TipoProyecto { get; set; }
        public Guid TipoProyectoId { get; set; }
        public ICollection<RequisitoProyectoReadModel> Requisitos { get; set; }

    }
}
