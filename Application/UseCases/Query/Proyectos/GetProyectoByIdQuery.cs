using Application.Dto.Proyectos;
using MediatR;

namespace Application.UseCases.Query.Proyectos
{
    public class GetProyectoByIdQuery : IRequest<ProyectoDto>
    {
        public Guid ProyectoId { get; set; }
    }
}
