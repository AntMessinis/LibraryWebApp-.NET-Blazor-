using AdminPanel.Helper.IServices;
using Microsoft.AspNetCore.Components.Forms;

namespace AdminPanel.Helper
{
    public class FileUploadHelperService : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadHelperService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadFile(IBrowserFile browserFile)
        {
            // Get file info
            FileInfo fileInfo = new(browserFile.Name);

            // Get guid and add it to file name
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            // Get directory path
            var folderDirectory = $"{_webHostEnvironment}\\images\\authors";

            // If directory doen't exist, create it
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            // Unite directory path with filename
            var fullFilePath = Path.Combine(folderDirectory, fileName);

            // Open new filestream and copy file
            await using FileStream fileStream = new(fullFilePath, FileMode.Create);
            await browserFile.OpenReadStream().CopyToAsync(fileStream);

            // Return file's directory path
            return fullFilePath;
        }

        public bool DeleteFile(string filePath)
        {
            // Check if file exists
            if (File.Exists(filePath))
            {
                // If it exists delete it and return true
                File.Delete(filePath);
                return true;
            }
            // Else return false;
            return false;
        }
    }
}
