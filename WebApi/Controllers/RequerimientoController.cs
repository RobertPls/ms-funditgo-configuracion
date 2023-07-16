using Application.UseCases.Command.Requerimientos.CrearRequerimiento;
using Application.UseCases.Command.Requerimientos.EliminarRequerimiento;
using Application.UseCases.Query.Requerimientos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/requerimiento")]
    [ApiController]
    public class RequerimientoController : ControllerBase
    {
        private readonly ILogger<RequerimientoController> _logger;
        private readonly IMediator _mediator;

        public RequerimientoController(IMediator mediator, ILogger<RequerimientoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRequerimiento([FromBody] CrearRequerimientoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el requerimiento");
                return BadRequest();
            }
        }


        [HttpDelete]
        public async Task<ActionResult> EliminarRequerimiento([FromBody] EliminarRequerimientoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el requerimiento");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetListaRequerimientoQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
