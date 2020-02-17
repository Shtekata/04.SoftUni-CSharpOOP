using System;

namespace Telephony.Exeptions
{
    public class InvalidURLException : Exception
    {
        private const string ExcMessage = "Invalid URL!";
        public InvalidURLException()
            : base(ExcMessage)
        {

        }

        public InvalidURLException(string message) 
            : base(message)
        {

        }
    }
}
