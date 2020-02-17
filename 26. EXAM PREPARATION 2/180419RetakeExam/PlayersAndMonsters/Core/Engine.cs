using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                var line = reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                var lineParts = line.Split();
                var command = lineParts[0];

                var result = string.Empty;

                try
                {
                    result = ExecuteCommand(lineParts, command);
                }
                catch (ArgumentException ae)
                {
                    result = ae.Message;
                }
                writer.WriteLine(result);
            }
        }

        private string ExecuteCommand(string[] lineParts, string command)
        {
            var result = string.Empty;

            string cardName;
            switch (command)
            {
                case "AddPlayer":
                    var playerType = lineParts[1];
                    var playerUserName = lineParts[2];

                    result = managerController.AddPlayer(playerType, playerUserName);
                    break;
                case "AddCard":
                    var cardType = lineParts[1];
                    cardName = lineParts[2];

                    result = managerController.AddCard(cardType, cardName);
                    break;
                case "AddPlayerCard":
                    var username = lineParts[1];
                    cardName = lineParts[2];

                    result = managerController.AddPlayerCard(username, cardName);
                    break;
                case "Fight":
                    var attackUsername = lineParts[1];
                    var enemyUsername = lineParts[2];

                    result = managerController.Fight(attackUsername, enemyUsername);
                    break;
                case "Report":

                    result = managerController.Report();
                    break;
            }

            return result;
        }
    }
}
