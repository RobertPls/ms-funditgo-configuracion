using Shared.Core;

namespace Domain.Events.Proyecto
{
    public record RequisitoProyectoEliminado : DomainEvent
    {
        public Guid RequisitoProyectoId { get; private set; }

        public RequisitoProyectoEliminado(Guid requisitoProyectoId) : base(DateTime.Now)
        {
            RequisitoProyectoId = requisitoProyectoId;
        }
    }
}
