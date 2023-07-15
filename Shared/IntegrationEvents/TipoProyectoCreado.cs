using Shared.Core;

namespace Shared.IntegrationEvents
{
    public record TipoProyectoCreado : IntegrationEvent
    {
        public Guid TipoProyectoId { get; set; }
        public string Nombre { get; set; }
    }
}
