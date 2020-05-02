using Battleship.Domain.GameDomain.Contracts;
using Battleship.Domain.GridDomain;
using Battleship.Domain.PlayerDomain;
using Battleship.Domain.PlayerDomain.Contracts;

namespace Battleship.Domain.GameDomain
{
    public class GameFactory : IGameFactory
    {
        public IGame CreateNewSinglePlayerGame(GameSettings settings, User user)
        {
            return new Game(settings, new HumanPlayer(user, settings), new ComputerPlayer(settings, new RandomShootingStrategy(settings, new Grid(settings.GridSize))));
        }

        public IGame CreateNewTwoPlayerGame(GameSettings settings, IPlayer player1, IPlayer player2)
        {
            //This only needs to be implemented when you add the extra of multiplayer games
            throw new System.NotImplementedException();
        }
    }
}