using Domain.Factory.Proyectos;
using Domain.Repository.Proyectos;
using MediatR;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Command.Proyectos.CrearProyecto
{
    public class CrearProyectoHandler : IRequestHandler<CrearProyectoCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IProyectoFactory _proyectoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearProyectoHandler(IProyectoRepository proyectoRepository, IProyectoFactory proyectoFactory, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _proyectoFactory = proyectoFactory;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(CrearProyectoCommand request, CancellationToken cancellationToken)
        {

            var proyecto = _proyectoFactory.Crear(
                request.Id,
                request.CreadorId,
                request.TipoProyectoId,
                request.Titulo,
                request.Estado
                );

            await _proyectoRepository.CreateAsync(proyecto);
            await _unitOfWork.CommitAsync();
            return proyecto.Id;
        }
    }
}
