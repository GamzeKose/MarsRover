using System.Collections.Generic;
using System.Drawing;

namespace MarsRover
{
    /// <summary>
    /// The class of Plateau.
    /// </summary>
    public class Plateau
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="coordinates"></param>
        public Plateau(Point coordinates)
        {
            this.Coordinates = coordinates;
            this.Surface = new Rectangle(0, 0, this.Coordinates.X + 1, this.Coordinates.Y + 1);
        }

        /// <summary>
        /// The upper-right coordinates of the plateau.
        /// </summary>
        private Point Coordinates { get; set; }

        /// <summary>
        /// The surface of Plateau.
        /// </summary>
        private Rectangle Surface { get; set; }

        /// <summary>
        /// Checks the position of the Rover.
        /// </summary>
        /// <returns></returns>
        public bool CheckRoverPosition(Point instance)
        {
            return this.Surface.Contains(instance);
        }

        /// <summary>
        /// Calculates the next position of the Rover.
        /// If the next position is not in the plateau range, the rover is not moved.
        /// </summary>
        /// <param name="rover">The rover.</param>
        /// <returns>The Rover's final coordinates and heading.</returns>
        public string CalculateRoute(Rover rover)
        {
            var Position = rover.Position;
            var directions = new List<string>() { "W", "S", "E", "N" };
            int directionIndex = 0;

            for (int i = 0; i < rover.Route.Length; i++)
            {
                switch (rover.Route[i])
                {
                    case 'L':
                        directionIndex = directions.IndexOf(rover.Direction);
                        rover.Direction = (directionIndex == 3) ? directions[0] : directions[directionIndex + 1];
                        break;
                    case 'R':
                        directionIndex = directions.IndexOf(rover.Direction);
                        rover.Direction = (directionIndex == 0) ? directions[3] : directions[directionIndex - 1];
                        break;
                    case 'M':
                        Position = this.NextPoint(Position, rover.Direction);
                        rover.Position = this.CheckRoverPosition(Position) ? Position : rover.Position;
                        break;
                }
            }

            return string.Format("{0} {1} {2}", rover.Position.X, rover.Position.Y, rover.Direction);
        }

        /// <summary>
        /// Calculates the next point for the Rover.
        /// </summary>
        /// <param name="current">The current point.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>Next position.</returns>
        public Point NextPoint(Point current, string direction)
        {
            switch (direction)
            {
                case "W":
                    return new Point(current.X - 1, current.Y);
                case "S":
                    return new Point(current.X, current.Y - 1);
                case "E":
                    return new Point(current.X + 1, current.Y);
                case "N":
                    return new Point(current.X, current.Y + 1);
                default:
                    return current;
            }
        }
    }
}
