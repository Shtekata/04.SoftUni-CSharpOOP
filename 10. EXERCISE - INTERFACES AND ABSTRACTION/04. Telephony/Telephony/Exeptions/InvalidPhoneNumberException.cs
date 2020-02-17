using System;

namespace Telephony.Exeptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string ExcMessage = "Invalid number!";
        public InvalidPhoneNumberException()
            : base(ExcMessage)
        {

        }

        public InvalidPhoneNumberException(string message) 
            : base(message)
        {

        }
    }
}
