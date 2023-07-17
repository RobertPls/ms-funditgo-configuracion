using Application.Dto.Proyectos;
using Application.Dto.Requerimientos;
using Application.Dto.TiposProyectos;
using Application.UseCases.Query.Proyectos;
using Application.UseCases.Query.TiposProyectos;
using Infrastructure.EntityFramework.Contexts;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query.TiposProyectos
{
    internal class GetTipoProyectoByIdHandler : IRequestHandler<GetTipoProyectoByIdQuery, TipoProyectoDto>
    {
        private readonly DbSet<TipoProyectoReadModel> tiposProyectos;
        public GetTipoProyectoByIdHandler(ReadDbContext dbContext)
        {
            tiposProyectos = dbContext.TipoProyecto;
        }
        public async Task<TipoProyectoDto> Handle(GetTipoProyectoByIdQuery request, CancellationToken cancellationToken)
        {

            var tipoProyecto = await tiposProyectos.AsNoTracking()
                .Include(p => p.RequerimientosTipos)
                .ThenInclude(p => p.Requerimiento)
                .FirstOrDefaultAsync(x => x.Id == request.TipoProyecto);

            if (tipoProyecto == null)
            {
                return null;
            }

            return new TipoProyectoDto
            {
                Id = tipoProyecto.Id,
                Nombre = tipoProyecto.Nombre,
                Descripcion = tipoProyecto.Descripcion,
                Requerimientos = tipoProyecto.RequerimientosTipos.Select(c => new RequerimientoTipoDto
                {
                    Id = c.Id,
                    Obligatorio = c.Obligatorio,
                    Requerimiento = new RequerimientoDto { Id = c.RequerimientoId, Nombre = c.Requerimiento.Nombre },

                }).ToList()
            };
        }
    }
}
