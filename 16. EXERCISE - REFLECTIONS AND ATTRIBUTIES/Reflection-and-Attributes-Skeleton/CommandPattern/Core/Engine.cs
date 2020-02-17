using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine (ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                var commandLine = Console.ReadLine();

                var result = commandInterpreter.Read(commandLine);

                Console.WriteLine(result);
            }
        }
    }
}
