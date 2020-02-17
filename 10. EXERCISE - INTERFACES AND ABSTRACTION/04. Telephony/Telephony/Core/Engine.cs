using System;
using System.Linq;
using Telephony.Exeptions;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        private Smartphone smartphone;
        public Engine()
        {
            smartphone = new Smartphone();
        }
        
        public void Run()
        {
            var numbers = Console.ReadLine()
                .Split()
                .ToArray();
            var urls = Console.ReadLine()
                .Split()
                .ToArray();

            CallNumbers(numbers);
            BrowseInternet(urls);
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var item in numbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(item));
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void BrowseInternet(string[] urls)
        {
            foreach (var item in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(item));
                }
                catch (InvalidURLException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
