using Application.UseCases.ApplicationFiles.UploadFile;
using Application.UseCases.Command.Proyectos.AgregarRequisitoProyecto;
using Application.UseCases.Command.Proyectos.CrearProyecto;
using Application.UseCases.Command.Proyectos.EliminarRequisitoProyecto;
using Application.UseCases.Command.TiposProyectos.EliminarRequerimientoTipo;
using Application.UseCases.Command.TiposProyectos.EliminarTipoProyecto;
using Application.UseCases.Query.Proyectos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebApi.Controllers
{
    [Route("api/proyecto")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ILogger<ProyectoController> _logger;
        private readonly IMediator _mediator;

        public ProyectoController(IMediator mediator, ILogger<ProyectoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTipoProyecto([FromBody] CrearProyectoCommand command)
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

        [Route("requisito")]
        [HttpPost]
        public async Task<IActionResult> AgregarRequisitoProyecto(IFormFile file)
        {
            var proyectoIdString = Request.Form["proyectoId"];
            var requerimientoIdString = Request.Form["requerimientoId"];

            if (string.IsNullOrEmpty(proyectoIdString) || string.IsNullOrEmpty(requerimientoIdString))
            {
                return BadRequest(requerimientoIdString);

            }

            var proyectoId = Guid.Parse(proyectoIdString);
            var requerimientoId = Guid.Parse(requerimientoIdString);

            try
            {
                await using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                byte[] bytes = memoryStream.ToArray();

                var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                string originalFileName = Path.GetFileName(fileContent.FileName);
                string extension = Path.GetExtension(fileContent.FileName);
                string contentType = file.ContentType;

                var command = new UploadFileCommand(bytes, originalFileName, extension, contentType);
                var fileId = await _mediator.Send(command);

                try
                {
                    var commandRequerimiento = new AgregarRequisitoProyectoCommand(proyectoId, requerimientoId, fileId);
                    var resultGuid = await _mediator.Send(commandRequerimiento);
                    return Ok(resultGuid);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al agregar el requisito de proyecto");
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar el archivo");
                return BadRequest();
            }
        }

        [Route("requisito")]
        [HttpDelete]
        public async Task<IActionResult> EliminarRequisitoProyecto([FromBody] EliminarRequisitoProyectoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el requisito del proyecto");
                return BadRequest();
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetProyectoByIdQuery()
            {
                ProyectoId = id
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
