using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;

namespace ViceCity
{
    public class StartUp
    {
        private static IEngine engine;
        private static void Main()
        {
            engine = new Engine();
            engine.Run();
        }
    }
}
