using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MarsRover
{
    /// <summary>
    /// The class of Robotic Rover.
    /// </summary>
    public class Rover
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public Rover()
        {
        }

        /// <summary>
        /// The position of Rover.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// The series of instructions telling the rover how to explore the plateau.
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// The direction of the Rover.
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Checks the direction of the Rover.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>True/False</returns>
        public bool CheckDirecton(string direction)
        {
            var directions = new List<string>() {"W", "S", "E", "N"};
            return directions.Contains(direction);
        }
    }
}
