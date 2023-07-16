
using Application.Services;
using Domain.Model;
using Domain.Model.Archivos;
using Domain.Repository.Archivos;
using MediatR;
using Shared.Core;

namespace Application.UseCases.ApplicationFiles.UploadFile;

public class UploadFileHandler : IRequestHandler<UploadFileCommand, Guid>
{
    private readonly IArchivoRepository _archivoRepository;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;

    public UploadFileHandler(
        IArchivoRepository archivoRepository, 
        IFileService fileService, 
        IUnitOfWork unitOfWork)
    {
        _archivoRepository = archivoRepository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var locationPath = await _fileService.SaveFile(request.FileBytes);

        var archivo = new Archivo(request.FileName, locationPath, request.Extension, request.ContentType, DateTime.Now);

        await _archivoRepository.CreateAsync(archivo);

        await _unitOfWork.CommitAsync(cancellationToken);

        return archivo.Id;
    }
}
