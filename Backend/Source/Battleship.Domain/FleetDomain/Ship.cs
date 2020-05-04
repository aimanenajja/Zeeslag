using System;
using System.Linq;
using Battleship.Domain.FleetDomain.Contracts;
using Battleship.Domain.GridDomain;
using Battleship.Domain.GridDomain.Contracts;

namespace Battleship.Domain.FleetDomain
{
    public class Ship : IShip
    {
        public IGridSquare[] Squares { get; set; }

        public ShipKind Kind { get; }

        public bool HasSunk => Squares == null ? false : Squares.All(square => square.Status == GridSquareStatus.Hit);

        public Ship(ShipKind kind)
        {
            Kind = kind;
        }

        public void PositionOnGrid(IGridSquare[] squares)
        {
            Squares?.ToList().ForEach(square => square.OnHitByBomb -= HitByBombHandler);
            Squares = squares;
            Squares.ToList().ForEach(square => square.OnHitByBomb += HitByBombHandler);
        }

        private void HitByBombHandler(IGridSquare square)
        {
            square.Status = GridSquareStatus.Hit;
        }

        public bool CanBeFoundAtCoordinate(GridCoordinate coordinate)
        {
            return Squares == null ? false : Squares.Select(gs => gs.Coordinate).Contains(coordinate);
        }
    }

}