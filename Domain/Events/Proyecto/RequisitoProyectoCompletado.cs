using Shared.Core;

namespace Domain.Events.Proyecto
{
    public record RequisitoProyectoCompletado : DomainEvent
    {

        public Guid ProyectoId { get; set; }

        public RequisitoProyectoCompletado(Guid proyectoId) : base(DateTime.Now)
        {
            ProyectoId = proyectoId;
        }
    }
}
