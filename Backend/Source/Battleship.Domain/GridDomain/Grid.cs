using System;
using Battleship.Domain.GridDomain.Contracts;

namespace Battleship.Domain.GridDomain
{
    public class Grid : IGrid
    {
        public IGridSquare[,] Squares { get; }

        public int Size { get; }

        public Grid(int size)
        {
            Size = size;
            Squares = new GridSquare[size, size];
        }

        public IGridSquare GetSquareAt(GridCoordinate coordinate)
        {
            throw new NotImplementedException("GetSquareAt method of Grid class is not implemented");
        }

        public IGridSquare Shoot(GridCoordinate coordinate)
        {
            throw new NotImplementedException("Shoot method of Grid class is not implemented");
        }
    }
}