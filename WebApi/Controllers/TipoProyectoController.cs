using Application.UseCases.Command.TiposProyectos.AgregarRequerimientoTipo;
using Application.UseCases.Command.TiposProyectos.CrearTipoProyecto;
using Application.UseCases.Command.TiposProyectos.EliminarRequerimientoTipo;
using Application.UseCases.Command.TiposProyectos.EliminarTipoProyecto;
using Application.UseCases.Query.TiposProyectos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/tipoProyecto")]
    [ApiController]
    public class TipoProyectoController : ControllerBase
    {
        private readonly ILogger<TipoProyectoController> _logger;
        private readonly IMediator _mediator;

        public TipoProyectoController(IMediator mediator, ILogger<TipoProyectoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoProyecto([FromBody] CrearTipoProyectoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el tipoProyecto");
                return BadRequest();
            }
        }


        [HttpDelete]
        public async Task<ActionResult> EliminarTipoProyecto([FromBody] EliminarTipoProyectoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el tipoProyecto");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetListaTipoProyectoQuery();
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("requerimiento")]
        [HttpPost]
        public async Task<IActionResult> AgregarRequerimiento([FromBody] AgregarRequerimientoTipoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el requerimiento al tipo proyecto");
                return BadRequest();
            }
        }

        [Route("requerimiento")]
        [HttpDelete]
        public async Task<IActionResult> EliminarRequerimiento([FromBody] EliminarRequerimientoTipoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el requerimiento del tipo proyecto");
                return BadRequest();
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetTipoProyectoByIdQuery()
            {
                TipoProyecto = id
            };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
