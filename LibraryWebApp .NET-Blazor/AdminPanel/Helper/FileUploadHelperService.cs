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
        public async Task<string> UploadFile(IBrowserFile browserFile, string imageFor)
        {
            // Get file info
            FileInfo fileInfo = new(browserFile.Name);

            // Get guid and add it to file name
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

            // Get directory path
            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\{imageFor}";

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
            return $"/images/{imageFor}/{fileName}";
        }

        public bool DeleteFile(string filePath)
        {
            // Check if file exists
            if (File.Exists(_webHostEnvironment.WebRootPath + filePath))
            {
                // If it exists delete it and return true
                File.Delete(_webHostEnvironment.WebRootPath + filePath);
                return true;
            }
            // Else return false;
            return false;
        }
    }
}
