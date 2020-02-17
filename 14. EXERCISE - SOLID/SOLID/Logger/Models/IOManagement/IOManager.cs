using Logger.Models.Contracts;
using System.IO;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;
        public IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }
        public IOManager(string currentDirectory, string currentFile)
            : this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }
        public string CurrentDirectoryPath => currentPath + currentDirectory;

        public string CurrentFilePath => CurrentDirectoryPath + currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(CurrentDirectoryPath))
            {
                Directory.CreateDirectory(CurrentDirectoryPath);
            }

            File.WriteAllText(CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
