using Domain.Events.Proyecto;
using Domain.Events.TipoProyecto;
using Domain.Model.Proyectos;
using Domain.Model.TiposProyectos;
using Domain.ValueObjects;
using Shared.Core;

namespace Domain.Model.TipoProyecto
{
    public class TipoProyecto : AggregateRoot<Guid>
    {
        public TituloValue Nombre { get; private set; }

        public DescripcionValue Descripcion { get; private set; }

        private readonly ICollection<RequerimientoTipo> _requerimientosTipos;
        public IEnumerable<RequerimientoTipo> RequerimientosTipos { get { return _requerimientosTipos; } }

        public TipoProyecto(string nombre, string descripcion) 
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Descripcion = descripcion;
            _requerimientosTipos = new List<RequerimientoTipo>();
        }
        public void AgregarRequerimientoTipo(Guid requerimientoId, bool obligatorio)
        {
            var requerimientoTipoExiste = RequerimientosTipos.FirstOrDefault(x => x.RequerimientoId == requerimientoId);


            if (requerimientoTipoExiste != null)
            {
                throw new BussinessRuleValidationException("El tipo proyecto ya cuenta con este requerimiento");
            }

            var requerimientoTipo = new RequerimientoTipo(requerimientoId, obligatorio);
            _requerimientosTipos.Add(requerimientoTipo);
            AddDomainEvent(new RequerimientoTipoAgregado(requerimientoTipo.Id));
        }

        public void EliminarRequerimientoTipo(Guid requerimientoTipoId)
        {
            var requerimientoTipo = RequerimientosTipos.FirstOrDefault(x => x.Id == requerimientoTipoId);


            if (requerimientoTipo == null)
            {
                throw new BussinessRuleValidationException("El requerimiento no fue encontrado");
            }

            _requerimientosTipos.Remove(requerimientoTipo);
            AddDomainEvent(new RequerimientoTipoEliminado(requerimientoTipo.Id));
        }
        public TipoProyecto() { }

    }
}
