
using Application.Services;
using Domain.Model;
using Domain.Repository;
using MediatR;
using Shared.Core;

namespace Application.UseCases.ApplicationFiles.UploadFile;

public class UploadFileHandler : IRequestHandler<UploadFileCommand, Guid>
{
    private readonly IApplicationFileRepository _applicationFileRepository;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;

    public UploadFileHandler(
        IApplicationFileRepository applicationFileRepository, 
        IFileService fileService, 
        IUnitOfWork unitOfWork)
    {
        _applicationFileRepository = applicationFileRepository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var locationPath = await _fileService.SaveFile(request.FileBytes);

        var applicationFile = new ApplicationFile(request.FileName, locationPath, request.Extension, request.ContentType, DateTime.Now);

        await _applicationFileRepository.CreateAsync(applicationFile);

        await _unitOfWork.CommitAsync(cancellationToken);

        return applicationFile.Id;
    }
}
