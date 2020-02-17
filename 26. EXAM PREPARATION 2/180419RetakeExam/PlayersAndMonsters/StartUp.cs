namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var playerFactory = new PlayerFactory();
            var playerRepository = new PlayerRepository();
            var cardRepositiry = new CardRepository();
            var cardFactory = new CardFactory();
            var battelField = new BattleField();
            var managerController = new ManagerController(playerFactory, playerRepository, cardFactory, cardRepositiry, battelField);

            var engine = new Engine(reader, writer, managerController);
            engine.Run();
        }
    }
}