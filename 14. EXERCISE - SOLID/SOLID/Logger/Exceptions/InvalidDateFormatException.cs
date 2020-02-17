using System;

namespace Logger.Factories
{
    public class InvalidDateFormatException : Exception
    {
        private const string ExcMessage = "Invalid DateTime Format";
        public InvalidDateFormatException()
            : base(ExcMessage)
        {
        }

        public InvalidDateFormatException(string message)
            : base(message)
        {
        }

        public InvalidDateFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
