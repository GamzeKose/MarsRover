using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            string Key = "0";
            while (Key != "N")
            {
                #region --- Plateau ---------------------------------

                // Enter the upper-right coordinates of the plateau.
                var upperXY = Console.ReadLine();
                var XY = upperXY.Split(' ');
                uint X = 0;
                uint Y = 0;
                if (!(XY.Length == 2 && UInt32.TryParse(XY[0], out X) && UInt32.TryParse(XY[1], out Y)))
                {
                    Console.WriteLine("Upper-right coordinates is invalid -> {0}", upperXY);
                    goto Next;
                }

                var Plateau = new Plateau(new Point((int)X, (int)Y));

                #endregion --- Plateau ------------------------------

                #region --- First Rover -----------------------------

                // Enter the first Rover's position.
                var firstRoverXY = Console.ReadLine();
                var firstXY = firstRoverXY.Split(' ');

                var FirstRover = new Rover();

                if ((firstXY.Length == 3 && UInt32.TryParse(firstXY[0], out X) && UInt32.TryParse(firstXY[1], out Y)))
                {
                    FirstRover.Position = new Point((int)X, (int)Y);
                    FirstRover.Direction = firstXY[2];

                    if (false == Plateau.CheckRoverPosition(FirstRover.Position))
                    {
                        Console.WriteLine("The Rover's position is not in the Plateau area -> {0}", FirstRover.Position);
                        goto Next;
                    }
                    else if(false == FirstRover.CheckDirecton(FirstRover.Direction))
                    {
                        Console.WriteLine("The Rover's direction is invalid -> {0}", FirstRover.Direction);
                        goto Next;
                    }
                }
                else
                {
                    Console.WriteLine("The position of the Rover is invalid -> {0}", firstRoverXY);
                    goto Next;
                }
                #endregion --- First Rover --------------------------

                #region --- Second Rover ----------------------------

                // Enter the first series of instructions.
                var firstInstruction = Console.ReadLine();
                FirstRover.Route = firstInstruction;

                // Enter the second Rover's position.
                var secondRoverXY = Console.ReadLine();
                var secondXY = secondRoverXY.Split(' ');

                var SecondRover = new Rover();

                if ((secondXY.Length == 3 && UInt32.TryParse(secondXY[0], out X) && UInt32.TryParse(secondXY[1], out Y)))
                {
                    SecondRover.Position = new Point((int)X, (int)Y);
                    SecondRover.Direction = secondXY[2];

                    if (false == Plateau.CheckRoverPosition(SecondRover.Position))
                    {
                        Console.WriteLine("The Rover's position is not in the Plateau area -> {0}", SecondRover.Position);
                        goto Next;
                    }
                    else if (false == SecondRover.CheckDirecton(SecondRover.Direction))
                    {
                        Console.WriteLine("The Rover's direction is invalid -> {0}", SecondRover.Direction);
                        goto Next;
                    }
                }
                else
                {
                    Console.WriteLine("The position of the Rover is invalid -> {0}", secondRoverXY);
                    goto Next;
                }

                // Enter the second series of instructions:");
                var secondInstruction = Console.ReadLine();
                SecondRover.Route = secondInstruction;

                #endregion --- Second Rover -----------------------------

                Console.WriteLine(Plateau.CalculateRoute(FirstRover));
                Console.WriteLine(Plateau.CalculateRoute(SecondRover));

            Next:
                Console.WriteLine("Start again Y/N");
                Key = Console.ReadLine();
            }
        }
    }
}
