using Domain.Model.Requerimientos;
using Domain.Repository.Requerimientos;
using Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Requerimientos
{
    internal class RequerimientoRepository : IRequerimientoRepository
    {
        private readonly WriteDbContext _context;

        public RequerimientoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Requerimiento obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Requerimiento?> FindByIdAsync(Guid id)
        {
            return await _context.Requerimiento.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Requerimiento obj)
        {
            _context.Requerimiento.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Requerimiento obj)
        {
            _context.Requerimiento.Update(obj);
            return Task.CompletedTask;
        }

    }
}
