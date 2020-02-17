using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Logger.Models.Contracts;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        private string currentPath;
        private IIOManager IOManager;
        public LogFile()
        {
            IOManager = new IOManager(currentDirectory, currentFile);
            currentPath = IOManager.GetCurrentPath();
            IOManager.EnsureDirectoryAndFileExist();
            Path = currentPath + currentDirectory + currentFile;
        }

        public string Path { get; private set; }

        public ulong Size => GetFileSize();
        
        public string Write(ILayout layout, IError error)
        {
            var format = layout.Format;

            var dateTame = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            var formattedMessage 
                = String.Format(format, dateTame.ToString(dateFormat, CultureInfo.InvariantCulture), level.ToString(), message);

            return formattedMessage;
        }
        private ulong GetFileSize()
        {
            string text = File.ReadAllText(Path);

            var size = (ulong)text
                .ToCharArray()
                .Where(x => Char.IsLetter(x))
                .Sum(x => (int)x);

            return size;
        }

    }
}
