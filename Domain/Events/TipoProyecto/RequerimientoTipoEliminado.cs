using Shared.Core;

namespace Domain.Events.TipoProyecto
{
    public record RequerimientoTipoEliminado : DomainEvent
    {
        public Guid RequerimientoTipoId { get; private set; }

        public RequerimientoTipoEliminado(Guid requerimientoTipoId) : base(DateTime.Now)
        {
            RequerimientoTipoId = requerimientoTipoId;
        }
    }
}
