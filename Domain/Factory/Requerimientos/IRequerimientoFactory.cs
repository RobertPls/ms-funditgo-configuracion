using Domain.Model.Requerimientos;

namespace Domain.Factory.Requisitos
{
    public interface IRequerimientoFactory
    {
        Requerimiento Crear(string nombre);
    }
}
