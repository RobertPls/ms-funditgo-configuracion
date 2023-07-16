using Shared.Core;

namespace Domain.Events.Proyecto
{
    public record RequisitoProyectoAgregado : DomainEvent
    {
        public Guid RequisitoProyectoId { get; private set; }

        public RequisitoProyectoAgregado(Guid requisitoProyectoId) : base(DateTime.Now)
        {
            RequisitoProyectoId = requisitoProyectoId;
        }
    }
}
