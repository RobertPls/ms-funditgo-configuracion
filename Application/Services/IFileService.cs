namespace Application.Services;

public interface IFileService
{
    /// <summary>
    /// Persist bytes of file 
    /// </summary>
    /// <param name="file">Bytes of file</param>
    /// <returns>Location of saved file</returns>
    Task<string> SaveFile(byte[] fileBytes);

    Task<byte[]> ReadFile(string fileLocation);
}
