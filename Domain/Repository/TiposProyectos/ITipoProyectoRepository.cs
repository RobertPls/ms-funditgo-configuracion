using Domain.Model.TipoProyecto;
using Shared.Core;

namespace Domain.Repository.TiposProyectos
{
    public interface ITipoProyectoRepository : IRepository<TipoProyecto, Guid>
    {
        Task UpdateAsync(TipoProyecto obj);
        Task RemoveAsync(TipoProyecto obj);
    }
}
