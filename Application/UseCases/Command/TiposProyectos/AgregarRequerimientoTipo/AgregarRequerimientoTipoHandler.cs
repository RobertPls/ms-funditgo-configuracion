using Domain.Repository.Requerimientos;
using Domain.Repository.TiposProyectos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.Command.TiposProyectos.AgregarRequerimientoTipo
{
    public class AgregarRequerimientoTipoHandler : IRequestHandler<AgregarRequerimientoTipoCommand, Guid>
    {
        private readonly ITipoProyectoRepository _tipoTipoProyectoRepository;
        private readonly IRequerimientoRepository _requerimientoRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public AgregarRequerimientoTipoHandler(ITipoProyectoRepository tipoTipoProyectoRepository, IRequerimientoRepository requerimientoRepository, IUnitOfWork unitOfWort)
        {
            _tipoTipoProyectoRepository = tipoTipoProyectoRepository;
            _requerimientoRepository = requerimientoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AgregarRequerimientoTipoCommand request, CancellationToken cancellationToken)
        {
            var tipoTipoProyecto = await _tipoTipoProyectoRepository.FindByIdAsync(request.TipoProyectoId);
            var requerimiento = await _requerimientoRepository.FindByIdAsync(request.RequerimientoId);
            
            if (tipoTipoProyecto == null)
            {
                throw new BussinessRuleValidationException("TipoProyecto no encontrado");
            }

            if (requerimiento == null)
            {
                throw new BussinessRuleValidationException("Requerimiento no encontrado");
            }

            tipoTipoProyecto.AgregarRequerimientoTipo(requerimiento.Id, request.Obligatorio);

            await _tipoTipoProyectoRepository.UpdateAsync(tipoTipoProyecto);
            
            await _unitOfWork.CommitAsync();

            return tipoTipoProyecto.Id;
        }
    }
}
