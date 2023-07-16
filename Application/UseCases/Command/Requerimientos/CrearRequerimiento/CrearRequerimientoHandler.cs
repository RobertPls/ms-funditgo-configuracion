using Domain.Factory.Requisitos;
using Domain.Repository.Requerimientos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.Command.Requerimientos.CrearRequerimiento
{
    public class CrearRequerimientoHandler : IRequestHandler<CrearRequerimientoCommand, Guid>
    {
        private readonly IRequerimientoRepository _requerimientosRepository;
        private readonly IRequerimientoFactory _requerimientoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearRequerimientoHandler(IRequerimientoRepository tipoProyectoRepository, IRequerimientoFactory requerimientoFactory, IUnitOfWork unitOfWort)
        {
            _requerimientosRepository = tipoProyectoRepository;
            _requerimientoFactory = requerimientoFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearRequerimientoCommand request, CancellationToken cancellationToken)
        {
            var requerimiento = _requerimientoFactory.Crear(request.Nombre);

            await _requerimientosRepository.CreateAsync(requerimiento);
            await _unitOfWork.CommitAsync();
            return requerimiento.Id;
        }
    }
}
