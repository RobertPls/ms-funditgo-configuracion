using MediatR;

namespace Application.UseCases.Command.TiposProyectos.AgregarRequerimientoTipo
{
    public record AgregarRequerimientoTipoCommand : IRequest<Guid>
    {
        public Guid TipoProyectoId { get; set; }
        public Guid RequerimientoId { get; set; }
        public bool Obligatorio{ get; set; }


    }
}

