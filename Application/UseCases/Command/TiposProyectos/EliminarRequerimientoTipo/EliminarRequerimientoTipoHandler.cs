using Domain.Repository.TiposProyectos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.Command.TiposProyectos.EliminarRequerimientoTipo
{
    public class EliminarRequerimientoTipoHandler : IRequestHandler<EliminarRequerimientoTipoCommand, Guid>
    {
        private readonly ITipoProyectoRepository _tipoProyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarRequerimientoTipoHandler(ITipoProyectoRepository tipoProyectoRepository, IUnitOfWork unitOfWort)
        {
            _tipoProyectoRepository = tipoProyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarRequerimientoTipoCommand request, CancellationToken cancellationToken)
        {
            var tipoProyecto = await _tipoProyectoRepository.FindByIdAsync(request.TipoProyectoId);

            if (tipoProyecto == null)
            {
                throw new BussinessRuleValidationException("TipoProyecto no encontrado");
            }

            tipoProyecto.EliminarRequerimientoTipo(request.RequerimientoTipoId);

            await _tipoProyectoRepository.UpdateAsync(tipoProyecto);

            await _unitOfWork.CommitAsync();

            return tipoProyecto.Id;
        }
    }
}
