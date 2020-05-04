using System.Linq;

namespace Battleship.Domain.GridDomain
{
    public static class GridCoordinateArrayExtensions
    {
        public static bool HasAnyOutOfBounds(this GridCoordinate[] coordinates, int gridSize)
        {
            return coordinates.Any(c => c.IsOutOfBounds(gridSize));
        }

        public static bool AreAligned(this GridCoordinate[] coordinates)
        {
            return coordinates.AreHorizontallyAligned() || coordinates.AreVerticallyAligned();
        }

        public static bool AreHorizontallyAligned(this GridCoordinate[] coordinates)
        {
            return coordinates.All(sc => sc.Row == coordinates[0].Row);
        }

        public static bool AreVerticallyAligned(this GridCoordinate[] coordinates)
        {
            return coordinates.All(sc => sc.Column == coordinates[0].Column);
        }

        public static bool AreDiagonallyAligned(this GridCoordinate[] coordinates)
        {
            var orderedCoordinates = coordinates.OrderBy(gc => gc.Column).ToArray();
            for (int i = 1; i < orderedCoordinates.Length; i++)
            {
                if ((!(orderedCoordinates[i].Column == orderedCoordinates[i - 1].Column + 1 &&
                    orderedCoordinates[i].Row == orderedCoordinates[i - 1].Row + 1)) && 
                    !(orderedCoordinates[i].Column + orderedCoordinates[i].Row == orderedCoordinates[i - 1].Column + orderedCoordinates[i - 1].Row))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreAllTouching(this GridCoordinate[] coordinates)
        {
            for (int i = 1; i < coordinates.Length; i++)
            {
                if (!coordinates.Any(c => coordinates[i].Column == c.Column - 1 || coordinates[i].Column == c.Column + 1))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreLinked(this GridCoordinate[] coordinates)
        {
            if (coordinates.AreHorizontallyAligned())
            {
                var orderedCoordinates = coordinates.OrderBy(gc => gc.Column).ToArray();
                for (int i = 1; i < orderedCoordinates.Length; i++)
                {
                    if (orderedCoordinates[i].Column != orderedCoordinates[i - 1].Column + 1)
                    {
                        return false;
                    }
                }
            }

            if (coordinates.AreVerticallyAligned())
            {
                var orderedCoordinates = coordinates.OrderBy(gc => gc.Row).ToArray();
                for (int i = 1; i < orderedCoordinates.Length; i++)
                {
                    if (orderedCoordinates[i].Row != orderedCoordinates[i - 1].Row + 1)
                    {
                        return false;
                    }
                }
            }

            return coordinates.AreHorizontallyAligned() || 
                coordinates.AreVerticallyAligned() || 
                coordinates.AreDiagonallyAligned() || 
                coordinates.AreAllTouching();
        }

        public static string Print(this GridCoordinate[] coordinates)
        {
            return $"[{string.Join<GridCoordinate>(", ", coordinates)}]";
        }
    }
}