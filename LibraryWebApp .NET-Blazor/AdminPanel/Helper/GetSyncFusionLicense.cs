namespace AdminPanel.Helper
{
    internal class GetSyncFusionLicense
    {
        internal static string GetLicenseCodeFromFile(string filename, string fileDirectory) 
        {
            string filePath = Path.Combine(fileDirectory, filename);
            string fileText = File.ReadAllText(filePath);
            return fileText;
        }
    }
}
