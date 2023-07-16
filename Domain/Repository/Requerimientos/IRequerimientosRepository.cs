using Domain.Model.Requerimientos;
using Shared.Core;

namespace Domain.Repository.Requerimientos
{
    public interface IRequerimientoRepository : IRepository<Requerimiento, Guid>
    {
        Task UpdateAsync(Requerimiento obj);
        Task RemoveAsync(Requerimiento obj);
    }
}
