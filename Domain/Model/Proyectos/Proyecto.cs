using Domain.Events.Proyecto;
using Domain.Model.Proyectos.Enum;
using Domain.Model.TiposProyectos;
using Domain.ValueObjects;
using Shared.Core;

namespace Domain.Model.Proyectos
{
    public class Proyecto : AggregateRoot<Guid>
    {
        public TituloValue Titulo { get; private set; }
        public Guid TipoProyectoId { get; private set; }
        public Guid CreadorId { get; private set; }
        public string Estado { get; private set; }


        private readonly ICollection<RequisitoProyecto> _requisitos;
        public IEnumerable<RequisitoProyecto> Requisitos { get { return _requisitos; } }


        public Proyecto(Guid id, Guid creadorId, Guid tipoProyectoId, string titulo, string estado)
        {
            if (estado != nameof(EstadoProyecto.Borrador))
            {
                throw new BussinessRuleValidationException("El estado de proyecto es invalido");
            }
            if (id == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El id es invalido");
            }
            if (tipoProyectoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El tipoProyectoId es invalido");
            }
            if (creadorId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El creadorId es invalido");
            }
            Id = id;
            TipoProyectoId = tipoProyectoId;
            Titulo = titulo;
            CreadorId = creadorId;
            Estado = estado;
            _requisitos = new List<RequisitoProyecto>();
        }

        public void MarcarRequisitosCompletados()
        {
            Estado = nameof(EstadoProyecto.RequisitosCompletados);
            AddDomainEvent(new RequisitoProyectoCompletado(this.Id));
        }

        public void AgregarRequisitoProyecto(Guid archivoId, Guid requerimientoId)
        {
            var requisitoProyectoExiste = Requisitos.FirstOrDefault(x => x.RequerimientoId == requerimientoId);


            if (requisitoProyectoExiste != null)
            {
                throw new BussinessRuleValidationException("Ya se ha enviado un requisito de este tipo");
            }

            var requisitoProyecto = new RequisitoProyecto(archivoId, requerimientoId);

            _requisitos.Add(requisitoProyecto);
            AddDomainEvent(new RequisitoProyectoAgregado(requisitoProyecto.Id));
        }

        public void EliminarRequisitoProyecto(Guid requisitoProyectoId)
        {
            var requisitoProyecto = Requisitos.FirstOrDefault(x => x.Id == requisitoProyectoId);


            if (requisitoProyecto == null)
            {
                throw new BussinessRuleValidationException("El requisito no fue encontrado");
            }

            _requisitos.Remove(requisitoProyecto);
            AddDomainEvent(new RequisitoProyectoEliminado(requisitoProyecto.Id));
        }

        public Proyecto(){}
    }
}
