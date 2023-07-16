using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Command.TiposProyectos.EliminarTipoProyecto
{
    public record EliminarTipoProyectoCommand : IRequest<Guid>
    {
        public Guid TipoProyectoId { get; set; }

    }
}
