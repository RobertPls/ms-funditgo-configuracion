using Application.Dto.TiposProyectos;
using MediatR;

namespace Application.UseCases.Query.TiposProyectos
{
    public class GetListaTipoProyectoQuery : IRequest<IEnumerable<TipoProyectoDto>>
    {
    }
}
