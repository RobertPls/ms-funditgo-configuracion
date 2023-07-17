using Domain.Model.Proyectos;
using Domain.Repository.Archivos;
using Domain.Repository.Proyectos;
using Domain.Repository.Requerimientos;
using Domain.Repository.TiposProyectos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.Command.Proyectos.AgregarRequisitoProyecto
{
    public class AgregarRequisitoProyectoHandler : IRequestHandler<AgregarRequisitoProyectoCommand, Guid>
    {
        private readonly ITipoProyectoRepository _tipoProyectoRepository;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IRequerimientoRepository _requerimientoRepository;
        private readonly IArchivoRepository _archivoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarRequisitoProyectoHandler(ITipoProyectoRepository tipoProyectoRepository, IProyectoRepository proyectoRepository, IRequerimientoRepository requerimientoRepository, IArchivoRepository archivoRepository, IUnitOfWork unitOfWort)
        {
            _tipoProyectoRepository = tipoProyectoRepository;
            _proyectoRepository = proyectoRepository;
            _requerimientoRepository = requerimientoRepository;
            _archivoRepository = archivoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(AgregarRequisitoProyectoCommand request, CancellationToken cancellationToken)
        {

            var proyecto = await _proyectoRepository.FindByIdAsync(request.ProyectoId);
            var requerimiento = await _requerimientoRepository.FindByIdAsync(request.RequerimientoId);
            var archivo = await _archivoRepository.FindByIdAsync(request.ArchivoId);

            if (archivo == null)
            {
                throw new BussinessRuleValidationException("TipoProyecto no encontrado");
            }

            if (proyecto == null)
            {
                throw new BussinessRuleValidationException("Proyecto no encontrado");
            }

            if (requerimiento == null)
            {
                throw new BussinessRuleValidationException("Requerimiento no encontrado");
            }


            proyecto.AgregarRequisitoProyecto(archivo.Id, requerimiento.Id);

            var tipoProyecto = await _tipoProyectoRepository.FindByIdAsync(proyecto.TipoProyectoId);

            bool tieneTodosLosRequisitos = true;

            foreach (var requerimientoEnTipoProyecto in tipoProyecto.RequerimientosTipos)
            {
                var requisitoProyecto = proyecto.Requisitos.FirstOrDefault(x => x.RequerimientoId == requerimientoEnTipoProyecto.RequerimientoId);
                if (requisitoProyecto == null && requerimientoEnTipoProyecto.Obligatorio)
                {
                    tieneTodosLosRequisitos = false;
                }
            }

            if (tieneTodosLosRequisitos)
            {
                proyecto.MarcarRequisitosCompletados();
            }

            await _proyectoRepository.UpdateAsync(proyecto);
            await _unitOfWork.CommitAsync();
            return proyecto.Id;
        }
    }
}
