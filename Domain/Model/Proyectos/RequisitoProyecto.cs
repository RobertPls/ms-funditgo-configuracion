using Shared.Core;

namespace Domain.Model.Proyectos
{
    public class RequisitoProyecto : Entity<Guid>
    {
        public Guid ArchivoId { get; private set; }
        public Guid RequerimientoId { get; private set; }

        public RequisitoProyecto(Guid archivoId, Guid requerimientoId)
        {
            if (requerimientoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El requerimientoId es invalido");
            }
            if (archivoId == Guid.Empty)
            {
                throw new BussinessRuleValidationException("El archivoId es invalido");
            }
            Id = Guid.NewGuid();
            RequerimientoId = requerimientoId;
            ArchivoId = archivoId;
        }
        public RequisitoProyecto() { }

    }

}
