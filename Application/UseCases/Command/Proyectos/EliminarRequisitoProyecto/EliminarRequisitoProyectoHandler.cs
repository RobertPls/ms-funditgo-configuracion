using Domain.Repository.Proyectos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.Command.Proyectos.EliminarRequisitoProyecto
{
    public class EliminarRequisitoProyectoHandler : IRequestHandler<EliminarRequisitoProyectoCommand, Guid>
    {
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarRequisitoProyectoHandler(IProyectoRepository proyectoRepository, IUnitOfWork unitOfWort)
        {
            _proyectoRepository = proyectoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarRequisitoProyectoCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            proyecto.EliminarRequisitoProyecto(request.RequisitoProyectoId);

            await _proyectoRepository.UpdateAsync(proyecto);

            await _unitOfWork.CommitAsync();

            return proyecto.Id;
        }
    }
}
