using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Command.Proyectos.AgregarRequisitoProyecto
{
    public record AgregarRequisitoProyectoCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid RequerimientoId { get; set; }
        public Guid ArchivoId { get; set; }



        public AgregarRequisitoProyectoCommand(Guid proyectoId, Guid requerimientoId,Guid archivoId)
        {
            ProyectoId = proyectoId;
            RequerimientoId = requerimientoId;
            ArchivoId = archivoId;
        }
    }
}