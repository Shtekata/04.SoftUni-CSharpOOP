using MortalEngines.Core;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            var mn = new MachinesManager();

            mn.HirePilot("Pesho");
            mn.ManufactureFighter("F1", 100, 200);
            mn.ManufactureTank("T1", 300, 400);

            mn.EngageMachine("Pesho", "F1");
            mn.EngageMachine("Pesho", "T1");

            Console.WriteLine(mn.PilotReport("Pesho"));
        }
    }
}