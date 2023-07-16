using Application.Dto.Requerimientos;
using Application.UseCases.Query.Requerimientos;
using Infrastructure.EntityFramework.Contexts;
using Infrastructure.EntityFramework.ReadModel.Requerimientos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.Requerimientos
{

    internal class GetListaRequerimientoHandler : IRequestHandler<GetListaRequerimientoQuery, IEnumerable<RequerimientoDto>>
    {
        private readonly DbSet<RequerimientoReadModel> requerimientos;
        public GetListaRequerimientoHandler(ReadDbContext dbContext)
        {
            requerimientos = dbContext.Requerimiento;
        }
        public async Task<IEnumerable<RequerimientoDto>> Handle(GetListaRequerimientoQuery request, CancellationToken cancellationToken)
        {
            var query = requerimientos.AsNoTracking().AsQueryable();

            var lista = await query.Select(tipoProyecto => new RequerimientoDto
            {
                Id = tipoProyecto.Id,
                Nombre = tipoProyecto.Nombre,
            }).ToListAsync();

            return lista;
        }
    }
}
