using CommandPattern.Core.Contracts;
using System.IO;
using System.Linq;

namespace CommandPattern.Core.Commands
{
    public class CreateFileCommand : ICommand
    {
        public string Execute(string[] args)
        {
            var fileName = args[0];
            var content = "";

            if (args.Length > 1)
            {
                var arrayContent = args.Skip(1).ToArray();
                content += string.Join(" ", arrayContent);
            }

            File.WriteAllText(fileName, content);

            return $"File {fileName} created successfully";
        }
        public string currentPath => Directory.GetCurrentDirectory();
    }
}
