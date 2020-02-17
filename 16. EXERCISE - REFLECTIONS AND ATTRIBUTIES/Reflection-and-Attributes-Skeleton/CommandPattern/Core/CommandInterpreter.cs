using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostfix = "Command";
        public string Read(string inputLine)
        {
            var cmdTokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commandName = cmdTokens[0] + CommandPostfix;
            var commandArgs = cmdTokens.Skip(1).ToArray();

            var assembly = Assembly.GetCallingAssembly();
            var types = assembly.GetTypes();
            var typeToCreate = types.FirstOrDefault(x => x.Name == commandName);

            if (typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid Command Type!");
            }

            var instance = Activator.CreateInstance(typeToCreate);
            var command = (ICommand)instance;

            var result = command.Execute(commandArgs);

            return result;
        }
    }
}
