using System;
using Battleship.Business.Models.Contracts;
using Battleship.Business.Services.Contracts;
using Battleship.Domain;
using Battleship.Domain.FleetDomain;
using Battleship.Domain.GameDomain;
using Battleship.Domain.GameDomain.Contracts;
using Battleship.Domain.GridDomain;

namespace Battleship.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameFactory _gameFactory;
        private readonly IGameRepository _gameRepository;
        private readonly IGameInfoFactory _gameInfoFactory;

        public GameService(
            IGameFactory gameFactory,
            IGameRepository gameRepository, 
            IGameInfoFactory gameInfoFactory)
        {
            _gameFactory = gameFactory;
            _gameRepository = gameRepository;
            _gameInfoFactory = gameInfoFactory;
        }

        public IGameInfo CreateGameForUser(GameSettings settings, User user)
        {
            var game = _gameFactory.CreateNewSinglePlayerGame(settings, user);
            _gameRepository.Add(game);
            return _gameInfoFactory.CreateFromGame(game, user.Id);
        }

        public Result StartGame(Guid gameId, Guid playerId)
        {
            throw new NotImplementedException("StartGame method of GameService class is not implemented");
        }

        public IGameInfo GetGameInfoForPlayer(Guid gameId, Guid playerId)
        {
            var game = _gameRepository.GetById(gameId);
            return _gameInfoFactory.CreateFromGame(game, playerId);
        }

        public Result PositionShipOnGrid(Guid gameId, Guid playerId, ShipKind shipKind, GridCoordinate[] segmentCoordinates)
        {
            var game = _gameRepository.GetById(gameId);
            var player1 = game.GetPlayerById(playerId);
            return player1.Fleet.TryMoveShipTo(shipKind, segmentCoordinates, player1.Grid);
        }

        public ShotResult ShootAtOpponent(Guid gameId, Guid shooterPlayerId, GridCoordinate coordinate)
        {
            throw new NotImplementedException("ShootAtOpponent method of GameService class is not implemented");
        }
    }
}