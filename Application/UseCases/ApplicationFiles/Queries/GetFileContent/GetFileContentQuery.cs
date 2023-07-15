using Application.Dto.ApplicationFile;
using MediatR;

namespace Application.UseCases.ApplicationFiles.Queries.GetFileContent;

public class GetFileContentQuery : IRequest<FileContentDto?>
{
    public GetFileContentQuery(Guid fileId)
    {
        FileId = fileId;
    }

    public Guid FileId { get; set; }
}
