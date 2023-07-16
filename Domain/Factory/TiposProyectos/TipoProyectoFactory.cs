using Domain.Events.TipoProyecto;
using Domain.Model.TipoProyecto;

namespace Domain.Factory.TiposProyectos
{
    public class TipoProyectoFactory : ITipoProyectoFactory
    {
        public TipoProyecto Crear(string nombre, string descripcion)
        {
            var obj =  new TipoProyecto(nombre, descripcion);
            var domainEvent = new TipoProyectoCreado(obj.Id, obj.Nombre);
            obj.AddDomainEvent(domainEvent);
            return obj;
        }
    }
}
