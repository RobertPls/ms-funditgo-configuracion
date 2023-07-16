using Domain.Model.TiposProyectos;
using Domain.ValueObjects;
using Shared.Core;

namespace Domain.Model.Requerimientos
{
    public class Requerimiento : AggregateRoot<Guid>
    {
        public NombreRequerimientoValue Nombre { get; private set; }

        public Requerimiento(string nombre)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
        }
        public Requerimiento() { }
    }
}
