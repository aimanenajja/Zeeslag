using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Domain.FleetDomain.Contracts;
using Battleship.Domain.GridDomain;
using Battleship.Domain.GridDomain.Contracts;

namespace Battleship.Domain.FleetDomain
{
    public class Fleet : IFleet
    {
        private readonly Dictionary<ShipKind, IShip> _allShips = 
            ShipKind.All.Select(shipKind => new KeyValuePair<ShipKind, IShip>(shipKind, new Ship(shipKind))).ToDictionary(x => x.Key, x => x.Value);

        public bool IsPositionedOnGrid => _allShips.Select(kvp => kvp.Value).All(ship => ship.Squares != null);

        public Result TryMoveShipTo(ShipKind kind, GridCoordinate[] segmentCoordinates, IGrid grid)
        {
            if (!_allShips.TryGetValue(kind, out var ship))
            {
                return Result.CreateFailureResult($"Ship of kind {kind.Name} not found");
            }

            if (ship.Kind.Size != segmentCoordinates.Length)
            {
                return Result.CreateFailureResult($"Ship is not as big as the amount of GridSquares you are trying to position it in");
            }

            if (segmentCoordinates.HasAnyOutOfBounds(grid.Size))
            {
                return Result.CreateFailureResult($"SegmentCoordinates are out of bounds");
            }

            if (!segmentCoordinates.AreAligned())
            {
                return Result.CreateFailureResult($"SegmentCoordinates are not aligned");
            }

            if (!segmentCoordinates.AreLinked())
            {
                return Result.CreateFailureResult($"SegmentCoordinates are not linked");
            }

            var otherPositionedShips = _allShips
                .Where(kvp => kvp.Key != kind && kvp.Value.Squares != null).Select(kvp => kvp.Value);

            foreach (var otherPositionedShip in otherPositionedShips)
            {
                foreach (var segmentCoordinate in segmentCoordinates)
                {
                    if (otherPositionedShip.CanBeFoundAtCoordinate(segmentCoordinate))
                    {
                        return Result.CreateFailureResult($"SegmentCoordinate '{segmentCoordinate}' collides with '{otherPositionedShip.Kind.Name}'");
                    }
                }
            }

            ship.PositionOnGrid(segmentCoordinates.Select(sc => grid.GetSquareAt(sc)).ToArray());

            return Result.CreateSuccessResult();
        }

        public void RandomlyPositionOnGrid(IGrid grid, bool allowDeformedShips = false)
        {
            throw new NotImplementedException("RandomlyPositionOnGrid method of Fleet class is not implemented");
        }

        public IShip FindShipAtCoordinate(GridCoordinate coordinate)
        {
            return _allShips
                .Where(kvp => kvp.Value.Squares != null)
                .Select(kvp => kvp.Value)
                .FirstOrDefault(ship => ship.CanBeFoundAtCoordinate(coordinate));
        }

        public IList<IShip> GetAllShips()
        {
            return _allShips.Values.ToList();
        }

        public IList<IShip> GetSunkenShips()
        {
            return _allShips.Values.Where(ship => ship.HasSunk).ToList();
        }
    }
}