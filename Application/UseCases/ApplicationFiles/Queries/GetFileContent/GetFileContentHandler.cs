
using Application.Dto.ApplicationFile;
using Application.Services;
using Application.UseCases.ApplicationFiles.Queries.GetFileContent;
using Domain.Repository;
using MediatR;

namespace Application.UseCases.ApplicationFiles.Queries.GetFileContent;

internal class GetFileContentHandler : IRequestHandler<GetFileContentQuery, FileContentDto?>
{
    private readonly IApplicationFileRepository _applicationFileRepository;
    private readonly IFileService _fileService;

    public GetFileContentHandler(IApplicationFileRepository applicationFileRepository, IFileService fileService)
    {
        _applicationFileRepository = applicationFileRepository;
        _fileService = fileService;
    }

    public async Task<FileContentDto?> Handle(GetFileContentQuery request, CancellationToken cancellationToken)
    {
        var applicationFile = await _applicationFileRepository.FindByIdAsync(request.FileId);
        if (applicationFile == null)
        {
            return null;
        }
        
        var bytes = await _fileService.ReadFile(applicationFile.Location);
        
        return new FileContentDto
        {
            Content = bytes,
            MimeType = applicationFile.MimeType,
            FileId = applicationFile.Id
        };
    }
}
