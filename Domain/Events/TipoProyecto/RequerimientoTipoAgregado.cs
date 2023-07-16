using Shared.Core;

namespace Domain.Events.TipoProyecto
{
    public record RequerimientoTipoAgregado : DomainEvent
    {
        public Guid RequerimientoTipoId { get; private set; }

        public RequerimientoTipoAgregado(Guid requerimientoTipoId) : base(DateTime.Now)
        {
            RequerimientoTipoId = requerimientoTipoId;
        }
    }
}
