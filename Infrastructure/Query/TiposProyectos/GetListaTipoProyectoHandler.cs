using Application.Dto.Requerimientos;
using Application.Dto.TiposProyectos;
using Application.UseCases.Query.TiposProyectos;
using Domain.Model.Proyectos;
using Infrastructure.EntityFramework.Contexts;
using Infrastructure.EntityFramework.ReadModel.Requerimientos;
using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.TiposProyectos
{
    internal class GetListaTipoProyectoHandler : IRequestHandler<GetListaTipoProyectoQuery, IEnumerable<TipoProyectoDto>>
    {
        private readonly DbSet<TipoProyectoReadModel> tipoProyecto;
        public GetListaTipoProyectoHandler(ReadDbContext dbContext)
        {
            tipoProyecto = dbContext.TipoProyecto;
        }
        public async Task<IEnumerable<TipoProyectoDto>> Handle(GetListaTipoProyectoQuery request, CancellationToken cancellationToken)
        {
            var query = tipoProyecto
                .Include(x=>x.RequerimientosTipos)
                    .ThenInclude(x=>x.Requerimiento)
                .AsNoTracking()
                .AsQueryable();

            var lista = await query.Select(tipoProyecto => new TipoProyectoDto
            {
                Id = tipoProyecto.Id,
                Nombre = tipoProyecto.Nombre,
                Descripcion = tipoProyecto.Descripcion,
                Requerimientos = tipoProyecto.RequerimientosTipos.Select(c => new RequerimientoTipoDto
                {
                    Id = c.Id,
                    Obligatorio = c.Obligatorio,
                    Requerimiento= new RequerimientoDto{ Id = c.RequerimientoId, Nombre= c.Requerimiento.Nombre},

                }).ToList(),

            }).ToListAsync();

            return lista;
        }
    }
}
