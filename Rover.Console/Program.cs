using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using Mars.Entities;
using Mars.Entities.Enums;


namespace Mars.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Enter upper-right coordinates (XY)");

                char[] coordinateArray = Console.ReadLine().Replace(" ", "").ToCharArray();

                Plateau.Mars.X = Convert.ToInt32(coordinateArray[0].ToString());
                Plateau.Mars.Y = Convert.ToInt32(coordinateArray[1].ToString());

                IList<Rover> rovers = new List<Rover>(2);
                rovers.Add(new Rover());
                rovers.Add(new Rover());

                foreach (Rover rover in rovers)
                {
                    Console.WriteLine("Enter Rover's position XYO");

                    char[] currentPosition = Console.ReadLine().Replace(" ", "").ToCharArray();

                    int orientation = Enum.Parse(typeof(CompassPointEnum), currentPosition[2].ToString().ToUpper()).GetHashCode();

                    Position position = new Position(new Coordinate(Convert.ToInt32(currentPosition[0].ToString()), Convert.ToInt32(currentPosition[1].ToString())));
                    position.Orientation = (CompassPointEnum)orientation;

                    rover.Coordinate = position.Coordinate;
                    rover.Orientation = position.Orientation;

                    Console.WriteLine("Enter Rover's movements");

                    char[] movements = Console.ReadLine().Replace(" ", "").ToUpper().ToCharArray();

                    Plateau.Mars.Rover = rover;
                    Plateau.Mars.Explore(movements);
                }

                foreach (Rover rover in rovers)
                {
                    Console.WriteLine(string.Format("Rover's location is {0} {1} {2}", rover.Coordinate.X.ToString(), rover.Coordinate.Y.ToString(), rover.Orientation.ToString()));
                }

                Console.WriteLine("Press any key to continue and exit");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Sorry an exception occurred (details below), please try again");
                Console.WriteLine("Press any key to continue and exit");
                Console.WriteLine();
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }

        }

    }
}
