
namespace Logger
{
    using Logger.Core;
    using Logger.Factories;
    using Logger.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var appendersCount = int.Parse(Console.ReadLine());
            var appenders = new List<IAppender>();
            var appenderFactory = new AppenderFactory();

            ReadAppendersData(appendersCount, appenders, appenderFactory);

            var logger = new Logger.Models.Logger(appenders);

            var engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount, List<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                var appendersInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                var appenderType = appendersInfo[0];
                var layoutType = appendersInfo[1];
                var levelStr = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelStr = appendersInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}
