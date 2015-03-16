using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mars.Entities;
using Mars.Entities.Enums;

namespace Mars.Tests
{
    [TestFixture]
    public class PlateautTests
    {
        [Test]
        public void TestSetPlateauCoordinates()
        {   
            Plateau.Mars.X = 5;
            Plateau.Mars.Y = 5;

            Coordinate coordinate = new Coordinate();

            coordinate.X = 5;
            coordinate.Y = 5;

            Assert.AreEqual(Plateau.Mars.X, coordinate.X);
            Assert.AreEqual(Plateau.Mars.Y, coordinate.Y);
        }
    }
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void TestSetRoverCoordinates()
        {
            Position startingRoverPosition = new Position();

            startingRoverPosition.Coordinate.X = 1;
            startingRoverPosition.Coordinate.Y = 2;
            startingRoverPosition.Orientation = CompassPointEnum.N;

            Rover rover = new Rover();

            rover.Coordinate.X = 1;
            rover.Coordinate.Y = 2;
            rover.Orientation = CompassPointEnum.N;

            Assert.AreEqual(rover.Coordinate.X, startingRoverPosition.Coordinate.X);
            Assert.AreEqual(rover.Coordinate.Y, startingRoverPosition.Coordinate.Y);
            Assert.AreEqual(rover.Orientation, startingRoverPosition.Orientation);
            
        }
        [Test]
        public void TestMoveRover()
        {
            Position startingRoverPosition = new Position();

            startingRoverPosition.Coordinate.X = 1;
            startingRoverPosition.Coordinate.Y = 2;
            startingRoverPosition.Orientation = CompassPointEnum.N;

            Rover rover = new Rover();

            rover.Coordinate.X = 1;
            rover.Coordinate.Y = 2;
            rover.Orientation = CompassPointEnum.N;

            Movement movement = new Movement();
            movement.Direction = MovementEnum.L;
                        
            rover.Explore(movement);
         
            movement.Direction = MovementEnum.M;

            rover.Explore(movement);

            Position expectedPosition = new Position();

            expectedPosition.Coordinate.X = 0;
            expectedPosition.Coordinate.Y = 2;
            expectedPosition.Orientation = CompassPointEnum.W;

            Assert.AreEqual(rover.Coordinate.X, expectedPosition.Coordinate.X);
            Assert.AreEqual(rover.Coordinate.Y, expectedPosition.Coordinate.Y);
            Assert.AreEqual(rover.Orientation, expectedPosition.Orientation);

        }

        [Test]
        public void TestRoverStaysOnPlateau()
        {

            Plateau.Mars.X = 5;
            Plateau.Mars.Y = 5;
            
            Rover rover = new Rover();

            rover.Coordinate.X = 5;
            rover.Coordinate.Y = 3;
            rover.Orientation = CompassPointEnum.E;

            Plateau.Mars.Rover = rover;

            Movement movement = new Movement();
            movement.Direction = MovementEnum.M;

            Position expectedPosition = new Position();

            expectedPosition.Coordinate.X = 5;
            expectedPosition.Coordinate.Y = 3;
            expectedPosition.Orientation = CompassPointEnum.E;

            Plateau.Mars.Explore(movement); ;            

            Assert.AreEqual(rover.Coordinate.X, expectedPosition.Coordinate.X);
            Assert.AreEqual(rover.Coordinate.Y, expectedPosition.Coordinate.Y);
            Assert.AreEqual(rover.Orientation, expectedPosition.Orientation);

        }
    }
}
