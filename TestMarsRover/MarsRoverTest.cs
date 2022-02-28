using System;
using Xunit;
using MarsRover;
using System.Drawing;

namespace TestMarsRover
{
    public class MarsRoverTest
    {
        private Plateau plateau;

        public MarsRoverTest()
        {
            plateau = new Plateau(new Point(5, 5));
        }

        [Fact]
        public void RoverTest1()
        {
            var Rover1 = new Rover();
            Rover1.Position = new Point(1,2);
            Rover1.Direction = "N";
            Rover1.Route = "LMLMLMLMM";
            var Expected1 = "1 3 N";

            Assert.Equal(Expected1, plateau.CalculateRoute(Rover1));
        }

        [Fact]
        public void RoverTest2()
        {
            var Rover2 = new Rover();
            Rover2.Position = new Point(3, 3);
            Rover2.Direction = "E";
            Rover2.Route = "MMRMMRMRRM";
            var Expected2 = "5 1 E";

            Assert.Equal(Expected2, plateau.CalculateRoute(Rover2));
        }
    }
}
