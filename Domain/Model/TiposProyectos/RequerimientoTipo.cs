using Shared.Core;

namespace Domain.Model.TiposProyectos
{
    public class RequerimientoTipo : Entity<Guid>
    {
        public Guid RequerimientoId { get; private set; }
        public bool Obligatorio { get; private set; }

        public RequerimientoTipo(Guid requerimientoId, bool obligatorio)
        {
            if (requerimientoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El requerimientoId es invalido");
            }
            Id = Guid.NewGuid();
            RequerimientoId = requerimientoId;
            Obligatorio = obligatorio;
        }
        public RequerimientoTipo() { }

    }
}
