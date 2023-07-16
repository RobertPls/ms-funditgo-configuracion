using Application.UseCases.ApplicationFiles.Queries.GetFileContent;
using Application.UseCases.ApplicationFiles.UploadFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebApi.Controllers;

[Route("api/file")]
public class FileController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<FileController> _logger;


    public FileController(IMediator mediator, ILogger<FileController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    //[HttpPost]
    //public async Task<IActionResult> Upload(IFormFile file)
    //{

    //    try
    //    {
    //        await using var memoryStream = new MemoryStream();
    //        await file.CopyToAsync(memoryStream);
    //        byte[] bytes = memoryStream.ToArray();

    //        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
    //        string originalFileName = Path.GetFileName(fileContent.FileName);
    //        string extension = Path.GetExtension(fileContent.FileName);
    //        string contentType = file.ContentType;

    //        var command = new UploadFileCommand(bytes, originalFileName, extension, contentType);
    //        var fileId = await _mediator.Send(command);

    //        return Ok(fileId);
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "Error al guardar el archivo");
    //        return BadRequest();
    //    }

    //}

    [AllowAnonymous]
    [HttpGet]
    [Route("{fileId}")]
    public async Task<IActionResult> GetImage(Guid fileId)
    {
        var query = new GetFileContentQuery(fileId);

        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }

        return File(result.Content, result.MimeType);

    }


}
