using Domain.Model.Proyectos;
using Shared.Core;

namespace Domain.Repository.Proyectos
{
    public interface IProyectoRepository : IRepository<Proyecto, Guid>
    {
        Task UpdateAsync(Proyecto obj);
        Task RemoveAsync(Proyecto obj);
    }
}
