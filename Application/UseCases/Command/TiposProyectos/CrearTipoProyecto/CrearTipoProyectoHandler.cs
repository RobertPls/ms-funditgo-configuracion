using Domain.Factory.TiposProyectos;
using Domain.Repository.TiposProyectos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.Command.TiposProyectos.CrearTipoProyecto
{
    public class CrearTipoProyectoHandler : IRequestHandler<CrearTipoProyectoCommand, Guid>
    {
        private readonly ITipoProyectoRepository _tipoProyectoRepository;
        private readonly ITipoProyectoFactory _tipoProyectoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearTipoProyectoHandler(ITipoProyectoRepository tipoProyectoRepository, ITipoProyectoFactory tipoProyectoFactory, IUnitOfWork unitOfWort)
        {
            _tipoProyectoRepository = tipoProyectoRepository;
            _tipoProyectoFactory = tipoProyectoFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearTipoProyectoCommand request, CancellationToken cancellationToken)
        {
            var tipoProyecto = _tipoProyectoFactory.Crear(request.Nombre, request.Descripcion);

            await _tipoProyectoRepository.CreateAsync(tipoProyecto);
            await _unitOfWork.CommitAsync();
            return tipoProyecto.Id;
        }
    }
}
