using Microsoft.AspNetCore.Components.Forms;

namespace AdminPanel.Helper.IServices
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile browserFile, string imageFor);
        bool DeleteFile(string filePath);
    }
}
