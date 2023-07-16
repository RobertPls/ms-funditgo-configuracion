using MediatR;

namespace Application.UseCases.Command.Requerimientos.CrearRequerimiento
{

    public record CrearRequerimientoCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
    }
}
