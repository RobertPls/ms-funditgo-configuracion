using Application.Services;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

internal class FileService : IFileService
{
    private readonly IConfiguration _configuration;

    public FileService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<byte[]> ReadFile(string fileLocation)
    {
        byte[] bytes = await File.ReadAllBytesAsync(fileLocation);

        return bytes;
    }

    public Task<string> SaveFile(byte[] fileBytes)
    {
        string destinationDirectory = _configuration["ApplicationFilePath"];
        DirectoryInfo dirInfo = GetFinalDirectory(destinationDirectory);

        // Try to get a random file name and save the file to disk. We will try three times.

        string fileName = "";
        bool success = false;
        for (int i = 0; i < 3; i++)
        {
            fileName = dirInfo.FullName + "\\" + Path.GetRandomFileName();

            FileInfo newFileInfo = new FileInfo(fileName);
            success = !newFileInfo.Exists;
            if (success)
            {
                break;
            }
        }

        if (!success)
        {
            throw new IOException("Error generating random file");
        }

        using (BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
        {
            writer.Write(fileBytes);
        }


        return Task.FromResult<string>(fileName);
    }


    private static DirectoryInfo GetFinalDirectory(string destinationDirectory)
    {

        if (String.IsNullOrEmpty(destinationDirectory))
        {
            throw new FileNotFoundException("Undefined Document Storage Directory in Configuration.");
        }

        // Make sure that the storage directory exists and that we can operate there
        DirectoryInfo dirInfo = new DirectoryInfo(destinationDirectory);
        if (!dirInfo.Exists)
        {
            throw new FileNotFoundException("Document Storage Directory defined does not exist.");
        }



        ///*********************************************************************
        //////*********************************************************************
        ///*********************************************************************
        //////*********************************************************************
        ///*********************************************************************
        ///
        //create subfolders system to storage files
        ///*********************************************************************
        //////*********************************************************************
        ///*********************************************************************
        //////*********************************************************************
        ///*********************************************************************

        //Files in the system are stored in only one folder. This should be changed to the following: 
        //every file should be stored in a folder named YYYY/MM/DD/HH 
        //(i.e. the date + the hour.  ST does not allow slashes, but this is a hierarchical system. 
        //There is a folder YYYY and a subfolder MM and a subfolder DD and a subfolder HH). 
        //The strategy is as follows: when a new file has to be stored, it will check if the corresponding folder exists, 
        //if it doesnt it creates the folder and stores the file there. This is to avoid having millions of files in ONE folder (which is painful in windows system files).



        // Make sure that the year storage directory exists and that we can operate there
        string year = DateTime.Now.Year.ToString();

        DirectoryInfo dirInfoYear = new DirectoryInfo(destinationDirectory + "//" + year);
        if (!dirInfoYear.Exists)
        {

            dirInfoYear.Create();
        }

        // Make sure that the month storage directory exists and that we can operate there
        string month = DateTime.Now.Month.ToString();

        DirectoryInfo dirInfoMonth = new DirectoryInfo(destinationDirectory + "//" + year + "//" + month);
        if (!dirInfoMonth.Exists)
        {
            dirInfoMonth.Create();
        }

        // Make sure that the day storage directory exists and that we can operate there
        string day = DateTime.Now.Day.ToString();

        DirectoryInfo dirInfoDay = new DirectoryInfo(destinationDirectory + "//" + year + "//" + month + "//" + day);
        if (!dirInfoDay.Exists)
        {
            dirInfoDay.Create();
        }

        // Make sure that the hour storage directory exists and that we can operate there
        string hour = DateTime.Now.Hour.ToString();

        DirectoryInfo dirInfoHour = new DirectoryInfo(destinationDirectory + "//" + year + "//" + month + "//" + day + "//" + hour);
        if (!dirInfoHour.Exists)
        {

            dirInfoHour.Create();
        }

        //Final directory
        dirInfo = dirInfoHour;

        return dirInfo;
    }
}
