using Shared.Core;

namespace Shared.IntegrationEvents
{
    public record ProyectoCreado : IntegrationEvent
    {
        public Guid ProyectoId { get; set; }

        public Guid CreadorId { get; set; }

        public Guid TipoProyectoId { get; set; }

        public string Titulo { get; set; }
        public string Estado { get; set; }
    }
}
