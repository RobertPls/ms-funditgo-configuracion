using Application.UseCases.Command.TiposProyectos.EliminarRequerimientoTipo;
using Domain.Repository.Requerimientos;
using Domain.Repository.TiposProyectos;
using MediatR;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Command.Requerimientos.EliminarRequerimiento
{
    public class EliminarRequerimientoHandler : IRequestHandler<EliminarRequerimientoCommand, Guid>
    {
        private readonly IRequerimientoRepository _requerimientoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarRequerimientoHandler(IRequerimientoRepository requerimientoRepository, IUnitOfWork unitOfWort)
        {
            _requerimientoRepository = requerimientoRepository;
            _unitOfWork = unitOfWort;
        }
        public async Task<Guid> Handle(EliminarRequerimientoCommand request, CancellationToken cancellationToken)
        {
            var requerimiento = await _requerimientoRepository.FindByIdAsync(request.RequerimientoId);

            if (requerimiento == null)
            {
                throw new BussinessRuleValidationException("Requerimiento no encontrado");
            }

            await _requerimientoRepository.RemoveAsync(requerimiento);

            await _unitOfWork.CommitAsync();

            return requerimiento.Id;
        }
    }
}
