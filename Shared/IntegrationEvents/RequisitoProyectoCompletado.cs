using Shared.Core;

namespace Shared.IntegrationEvents
{
    public record RequisitoProyectoCompletado : IntegrationEvent
    {
        public Guid ProyectoId { get; set; }
    }
}
