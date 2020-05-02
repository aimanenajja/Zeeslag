using System;
using Battleship.Domain.GameDomain.Contracts;
using Battleship.Domain.GridDomain;
using Battleship.Domain.PlayerDomain.Contracts;

namespace Battleship.Domain.GameDomain
{
    public class Game : IGame
    {
        public Guid Id { get; }
        public GameSettings Settings { get; }

        public IPlayer Player1 { get; }
        public IPlayer Player2 { get; }
        public bool IsStarted { get; private set; }

        internal Game(GameSettings settings, IPlayer player1, IPlayer player2)
        {
            Id = Guid.NewGuid();
            Settings = settings;
            Player1 = player1;
            Player2 = player2;
            IsStarted = false;
        }

        public Result Start()
        {
            throw new NotImplementedException("Start method of Game class is not implemented");
        }

        public ShotResult ShootAtOpponent(Guid shooterPlayerId, GridCoordinate coordinate)
        {
            throw new NotImplementedException("ShootAtOpponent method of Game class is not implemented");
        }

        public IPlayer GetPlayerById(Guid playerId)
        {
            return playerId == Player1.Id ? Player1 : Player2;
        }

        public IPlayer GetOpponent(IPlayer player)
        {
            return player == Player1 ? Player2 : Player1;
        }
    }
}