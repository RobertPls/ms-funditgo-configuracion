using MediatR;

namespace Application.UseCases.ApplicationFiles.UploadFile;

public class UploadFileCommand : IRequest<Guid>
{
    public byte[] FileBytes { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string Extension { get; set; }

    public UploadFileCommand(byte[] bytes, string fileName, string extension, string contentType)
    {
        FileBytes = bytes;
        FileName = fileName;
        Extension = extension;
        ContentType = contentType;
    }


}
