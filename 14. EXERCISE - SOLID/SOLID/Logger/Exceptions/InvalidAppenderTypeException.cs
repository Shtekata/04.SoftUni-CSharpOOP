using System;

namespace Logger.Exeptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string ExcMessase = "Invalid Appender Type!";
        public InvalidAppenderTypeException()
            :base(ExcMessase)
        {
        }

        public InvalidAppenderTypeException(string message)
            : base(message)
        {
        }
    }
}
