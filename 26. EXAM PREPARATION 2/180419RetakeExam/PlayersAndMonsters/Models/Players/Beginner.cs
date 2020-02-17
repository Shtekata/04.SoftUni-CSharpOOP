using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int BeginnerInitialHelth = 50;
        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, BeginnerInitialHelth)
        {
        }
    }
}
