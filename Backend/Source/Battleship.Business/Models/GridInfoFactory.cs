using Battleship.Business.Models.Contracts;
using Battleship.Domain.GridDomain.Contracts;

namespace Battleship.Business.Models
{
    public class GridInfoFactory : IGridInfoFactory
    {
        public IGridInfo CreateFromGrid(IGrid grid)
        {
            GridSquareInfo[][] squareInfos2D = new GridSquareInfo[grid.Size][];

            for(int i = 0; i < grid.Size; i++)
            {
                GridSquareInfo[] squareInfos = new GridSquareInfo[grid.Size];
                for(int j = 0; j < grid.Size; j++)
                {
                    squareInfos[j] = new GridSquareInfo(grid.Squares[i, j]);
                }
                squareInfos2D[i] = squareInfos;
            }

            return new GridInfo
            {
                Size = grid.Size,
                Squares = squareInfos2D
            };
        }
    }
}