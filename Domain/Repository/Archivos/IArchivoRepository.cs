using Domain.Model.Archivos;
using Shared.Core;

namespace Domain.Repository.Archivos
{
    public interface IArchivoRepository : IRepository<Archivo, Guid>
    {
        public Task UpdateAsync(Archivo file);
    }
}
