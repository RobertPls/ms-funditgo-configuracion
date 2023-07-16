using Domain.Model.TipoProyecto;

namespace Domain.Factory.TiposProyectos
{
    public interface ITipoProyectoFactory
    {
        TipoProyecto Crear(string nombre, string descripcion);
    }
}
