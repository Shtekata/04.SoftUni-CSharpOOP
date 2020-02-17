using System.Linq;
using Telephony.Contracts;
using Telephony.Exeptions;

namespace Telephony.Models
{
    public class Smartphone : IBrowseable, ICallable
    {
        public Smartphone()
        {

        }
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
