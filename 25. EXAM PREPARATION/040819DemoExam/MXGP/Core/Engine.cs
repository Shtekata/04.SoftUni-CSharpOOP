using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            championshipController = new ChampionshipController();
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = input[0];

                if(command== "CreateRider")
                {
                    var name = input[1];

                    championshipController.CreateRider(name);
                }

            }
        }
    }
}
