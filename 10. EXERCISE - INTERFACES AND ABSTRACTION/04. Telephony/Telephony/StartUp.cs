namespace Telephony
{
    using System;
    using Telephony.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
