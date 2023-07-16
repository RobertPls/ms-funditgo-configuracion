using Domain.Model.Archivos;
using Domain.Repository.Archivos;
using Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Archivos
{
    internal class ArchivoRepository : IArchivoRepository
    {
        private readonly WriteDbContext _dbContext;

        public ArchivoRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Archivo obj)
        {
            await _dbContext.Archivo.AddAsync(obj);
        }

        public Task<Archivo?> FindByIdAsync(Guid id)
        {
            return _dbContext.Archivo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Archivo file)
        {
            _dbContext.Archivo.Update(file);
            return Task.CompletedTask;
        }
    }
}
