using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Business.Models.Contracts;
using Battleship.Domain.FleetDomain.Contracts;

namespace Battleship.Business.Models
{
    public class ShipInfoFactory : IShipInfoFactory 
    {
        public IList<IShipInfo> CreateMultipleFromFleet(IFleet fleet)
        {
            return fleet.GetAllShips().Select(ship => new ShipInfo(ship)).ToList<IShipInfo>();
        }

        public IList<IShipInfo> CreateMultipleFromSunkenShipsOfFleet(IFleet fleet)
        {
            return fleet.GetSunkenShips().Select(ship => new ShipInfo(ship)).ToList<IShipInfo>();
        }
    }
}