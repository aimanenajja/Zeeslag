using Battleship.Business.Models.Contracts;
using Battleship.Domain.GameDomain.Contracts;
using System;
using System.Collections.Generic;

namespace Battleship.Business.Models
{
    public class GameInfoFactory : IGameInfoFactory
    {
        private readonly IGridInfoFactory _gridInfoFactory;
        private readonly IShipInfoFactory _shipInfoFactory;

        public GameInfoFactory(IGridInfoFactory gridInfoFactory, IShipInfoFactory shipInfoFactory)
        {
            _gridInfoFactory = gridInfoFactory;
            _shipInfoFactory = shipInfoFactory;
        }

        public IGameInfo CreateFromGame(IGame game, Guid playerId)
        {
            var player1 = game.GetPlayerById(playerId);
            var player2 = game.GetOpponent(player1);

            return new GameInfo 
            {
                Id = game.Id,
                OwnGrid = _gridInfoFactory.CreateFromGrid(player1.Grid),
                OpponentGrid = _gridInfoFactory.CreateFromGrid(player2.Grid),
                HasBombsLoaded = player1.HasBombsLoaded,
                OwnShips = _shipInfoFactory.CreateMultipleFromFleet(player1.Fleet),
                SunkenOpponentShips = game.Settings.MustReportSunkenShip ? _shipInfoFactory.CreateMultipleFromSunkenShipsOfFleet(player2.Fleet) : new List<IShipInfo>(),
                IsReadyToStart = player1.Fleet.IsPositionedOnGrid && player2.Fleet.IsPositionedOnGrid,
            };
        }
    }
}