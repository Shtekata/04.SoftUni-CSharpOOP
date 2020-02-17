using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;
        private Engine()
        {
            errorFactory = new ErrorFactory();
        }
        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }
        public void Run()
        {
            var command = Console.ReadLine();

            while (command!="END")
            {
                var errorArgs = command
                    .Split("|")
                    .ToArray();

                var level = errorArgs[0];
                var date = errorArgs[1];
                var message = errorArgs[2];

                IError error;

                try
                {
                    error = errorFactory.GetError(date, level, message);
                    logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                command = Console.ReadLine();

            }

            Console.WriteLine(logger.ToString());
        }
    }
}
