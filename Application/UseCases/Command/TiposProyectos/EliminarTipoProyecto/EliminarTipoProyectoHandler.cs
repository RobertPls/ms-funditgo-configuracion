using Domain.Repository.TiposProyectos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.Command.TiposProyectos.EliminarTipoProyecto
{
    public class EliminarTipoProyectoHandler : IRequestHandler<EliminarTipoProyectoCommand, Guid>
    {
        private readonly ITipoProyectoRepository _tipoProyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarTipoProyectoHandler(ITipoProyectoRepository tipoProyectoRepository, IUnitOfWork unitOfWort)
        {
            _tipoProyectoRepository = tipoProyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarTipoProyectoCommand request, CancellationToken cancellationToken)
        {
            var tipoProyecto = await _tipoProyectoRepository.FindByIdAsync(request.TipoProyectoId);

            if (tipoProyecto == null)
            {
                throw new BussinessRuleValidationException("TipoProyecto no encontrado");
            }

            await _tipoProyectoRepository.RemoveAsync(tipoProyecto);

            await _unitOfWork.CommitAsync();

            return tipoProyecto.Id;
        }
    }
}
