using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;
using System.Globalization;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        private int messagesAppended;
        private ConsoleAppender()
        {
            messagesAppended = 0;
        }
        public ConsoleAppender(ILayout layout, Level level)
            :this()
        {
            Layout = layout;
            Level = level;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            var format = Layout.Format;

            var dateTime = error.DateTime;
            var level = error.Level;
            var message = error.Message;

            var formattedMessage 
                = string.Format(format, dateTime.ToString(dateFormat, CultureInfo.InvariantCulture), level.ToString(), message);

            Console.WriteLine(formattedMessage);
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {Level.ToString()}, Messages appended: {messagesAppended}";
        }
    }
}
