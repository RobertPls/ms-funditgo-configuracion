using Domain.Events.Proyecto;
using Domain.Model.Proyectos;
using Domain.Repository.Proyectos;
using Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Proyectos
{
    internal class ProyectoRepository : IProyectoRepository
    {
        private readonly WriteDbContext _context;

        public ProyectoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Proyecto obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Proyecto?> FindByIdAsync(Guid id)
        {
            return await _context.Proyecto
                .Include(p => p.Requisitos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Proyecto obj)
        {
            _context.RequisitoProyecto.RemoveRange(obj.Requisitos);

            _context.Proyecto.Remove(obj);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Proyecto obj)
        {
            foreach (var e in obj.DomainEvents)
            {
                if (e is RequisitoProyectoAgregado)
                {
                    var evento = (RequisitoProyectoAgregado)e;
                    var requisitoProyecto = obj.Requisitos.FirstOrDefault(c => c.Id == evento.RequisitoProyectoId);
                    System.Diagnostics.Debug.WriteLine(requisitoProyecto.Id);

                    await _context.RequisitoProyecto.AddAsync(requisitoProyecto);
                }
                if (e is RequisitoProyectoEliminado)
                {
                    var evento = (RequisitoProyectoEliminado)e;
                    var requisitoProyecto = await _context.RequisitoProyecto.FindAsync(evento.RequisitoProyectoId);
                    _context.RequisitoProyecto.Remove(requisitoProyecto);
                }
            }

            _context.Proyecto.Update(obj);
        }

    }
}
