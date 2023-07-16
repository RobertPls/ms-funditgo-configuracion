using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Command.Proyectos.CrearProyecto
{
    public record CrearProyectoCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public Guid CreadorId { get; set; }

        public Guid TipoProyectoId { get; set; }

        public string Titulo { get; set; }
        public string Estado { get; set; }

        public CrearProyectoCommand (Guid id, Guid creadorId, Guid tipoProyectoId, string titulo, string estado)
        { 
            Id = id;
            CreadorId = creadorId;
            TipoProyectoId = tipoProyectoId;
            Titulo = titulo;
            Estado = estado;
        }
    }
}
