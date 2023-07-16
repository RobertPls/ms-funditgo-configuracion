using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Command.Requerimientos.EliminarRequerimiento
{
    public record EliminarRequerimientoCommand : IRequest<Guid>
    {
        public Guid RequerimientoId { get; set; }

    }
}
