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
        private Dictionary<ShipKind, IShip> _allShips = 
            ShipKind.All.Select(shipKind => new KeyValuePair<ShipKind, IShip>(shipKind, new Ship(shipKind))).ToDictionary(x => x.Key, x => x.Value);

        public bool IsPositionedOnGrid { get; }

        public Result TryMoveShipTo(ShipKind kind, GridCoordinate[] segmentCoordinates, IGrid grid)
        {
            throw new NotImplementedException("TryMoveShipTo method of Fleet class is not implemented");
        }

        public void RandomlyPositionOnGrid(IGrid grid, bool allowDeformedShips = false)
        {
            throw new NotImplementedException("RandomlyPositionOnGrid method of Fleet class is not implemented");
        }

        public IShip FindShipAtCoordinate(GridCoordinate coordinate)
        {
            throw new NotImplementedException("FindShipAtCoordinate method of Fleet class is not implemented");
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