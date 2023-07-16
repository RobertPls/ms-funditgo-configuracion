using Application.Dto.Proyectos;
using Application.Dto.Requerimientos;
using Application.Dto.TiposProyectos;
using Application.UseCases.Query.Proyectos;
using Infrastructure.EntityFramework.Contexts;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query.Proyectos
{
    internal class GetProyectoByIdHandler : IRequestHandler<GetProyectoByIdQuery, ProyectoDto>
    {
        private readonly DbSet<ProyectoReadModel> proyectos;
        public GetProyectoByIdHandler(ReadDbContext dbContext)
        {
            proyectos = dbContext.Proyecto;
        }
        public async Task<ProyectoDto> Handle(GetProyectoByIdQuery request, CancellationToken cancellationToken)
        {

            var proyecto = await proyectos.AsNoTracking()
                .Include(p => p.Requisitos)
                .ThenInclude(p => p.Requerimiento)
                .Include(p=> p.TipoProyecto)
                .FirstOrDefaultAsync(x => x.Id == request.ProyectoId);

            if (proyecto == null)
            {
                return null;
            }

            return new ProyectoDto
            {
                Id = proyecto.Id,
                Estado = proyecto.Estado,
                TipoProyecto = new TipoProyectoSimpleDto { Id = proyecto.TipoProyecto.Id, Nombre = proyecto.TipoProyecto.Nombre },
                Titulo = proyecto.Titulo,
                Requisitos = proyecto.Requisitos.Select(r => new RequisitoProyectoDto
                {
                    Id = r.Id,
                    Requerimiento = new RequerimientoDto { Id = r.Requerimiento.Id, Nombre = r.Requerimiento.Nombre },
                    AtchivoId = r.ArchivoId
                }).ToList(),
            };
        }
    }
}
