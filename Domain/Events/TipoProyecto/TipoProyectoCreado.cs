using Shared.Core;

namespace Domain.Events.TipoProyecto
{
    public record TipoProyectoCreado : DomainEvent
    {

        public Guid TipoProyectoId { get; set; }
        public string Nombre { get; set; }

        public TipoProyectoCreado(Guid tipoProyectoId, string nombre) : base(DateTime.Now)
        {
            TipoProyectoId = tipoProyectoId;
            Nombre = nombre;
        }
    }
}
