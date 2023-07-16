using Application.Dto.Requerimientos;
using MediatR;

namespace Application.UseCases.Query.Requerimientos
{
    public class GetListaRequerimientoQuery : IRequest<IEnumerable<RequerimientoDto>>
    {
    }
}
