using Logger.Exeptions;
using Logger.Models.Appenders;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Files;
using System;
using System.Linq;
using System.Reflection;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelStr)
        {
            Level level;

            bool hasParsed = Enum.TryParse(levelStr, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            var layout = layoutFactory.GetLayout(layoutType);

            //IAppender appender;
            //
            //if (appenderType == "ConsoleAppender")
            //{
            //    appender = new ConsoleAppender(layout, level);
            //}
            //else if (appenderType == "FileAppender")
            //{
            //    var file = new LogFile();
            //    appender = new FileAppender(layout, level, file);
            //}
            //else
            //{
            //    throw new InvalidAppenderTypeException();
            //}
            //
            //return appender;

            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes()
                .FirstOrDefault(x => x.Name == appenderType);

            if (type == null)
            {
                throw new InvalidAppenderTypeException();
            }

            object[] args = new object[]
            {
                layout,
                level
            };

            var appender = (IAppender)Activator.CreateInstance(type, args);

            return appender;
        }
    }
}
