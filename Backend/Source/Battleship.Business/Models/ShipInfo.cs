﻿using System;
using System.Linq;
using Battleship.Business.Models.Contracts;
using Battleship.Domain.FleetDomain;
using Battleship.Domain.FleetDomain.Contracts;
using Battleship.Domain.GridDomain;

namespace Battleship.Business.Models
{
    public class ShipInfo : IShipInfo
    {
        public GridCoordinate[] Coordinates { get; }

        public ShipKind Kind { get; }

        public bool HasSunk { get;}

        public ShipInfo(IShip ship)
        {
            Coordinates = ship.Squares?.Select(square => square.Coordinate).ToArray();
            Kind = ship.Kind;
            HasSunk = ship.HasSunk;
        }
    }
}