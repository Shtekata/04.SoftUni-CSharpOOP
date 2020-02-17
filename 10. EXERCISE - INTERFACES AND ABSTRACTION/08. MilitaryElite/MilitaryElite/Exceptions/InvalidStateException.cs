using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string ExcMessage = "Invalid mission state!";
        public InvalidStateException()
            : base(ExcMessage)
        {
        }

        public InvalidStateException(string message)
            : base(message)
        {
        }
    }
}
