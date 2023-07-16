using MediatR;

namespace Application.UseCases.Command.Proyectos.EliminarRequisitoProyecto
{
    public record EliminarRequisitoProyectoCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid RequisitoProyectoId { get; set; }

    }
}
