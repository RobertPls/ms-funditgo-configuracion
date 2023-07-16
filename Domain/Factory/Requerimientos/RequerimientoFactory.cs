using Domain.Model.Requerimientos;

namespace Domain.Factory.Requisitos
{
    public class RequerimientoFactory : IRequerimientoFactory
    {
        public Requerimiento Crear(string nombre)
        {
            return new Requerimiento(nombre);
        }
    }
}
