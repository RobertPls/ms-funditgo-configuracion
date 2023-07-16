using Domain.Events.TipoProyecto;
using Domain.Model.TipoProyecto;
using Domain.Repository.TiposProyectos;
using Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.TiposTipoProyectos
{
    internal class TipoProyectoRepository : ITipoProyectoRepository
    {
        private readonly WriteDbContext _context;

        public TipoProyectoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TipoProyecto obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<TipoProyecto?> FindByIdAsync(Guid id)
        {
            return await _context.TipoProyecto
                .Include(p => p.RequerimientosTipos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(TipoProyecto obj)
        {
            _context.RequerimientoTipo.RemoveRange(obj.RequerimientosTipos);

            _context.TipoProyecto.Remove(obj);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(TipoProyecto obj)
        {
            foreach (var e in obj.DomainEvents)
            {
                if (e is RequerimientoTipoAgregado)
                {
                    var evento = (RequerimientoTipoAgregado)e;
                    var requerimientoTipo = obj.RequerimientosTipos.FirstOrDefault(c => c.Id == evento.RequerimientoTipoId);
                    await _context.RequerimientoTipo.AddAsync(requerimientoTipo);
                }
                if (e is RequerimientoTipoEliminado)
                {
                    var evento = (RequerimientoTipoEliminado)e;
                    var requerimientoTipo = await _context.RequerimientoTipo.FindAsync(evento.RequerimientoTipoId);
                    _context.RequerimientoTipo.Remove(requerimientoTipo);
                }
            }

            _context.TipoProyecto.Update(obj);
        }

    }
}
