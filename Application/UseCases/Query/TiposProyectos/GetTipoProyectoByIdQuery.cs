using Application.Dto.TiposProyectos;
using MediatR;

namespace Application.UseCases.Query.TiposProyectos
{
    public class GetTipoProyectoByIdQuery : IRequest<TipoProyectoDto>
    {
        public Guid TipoProyecto { get; set; }
    }
}
