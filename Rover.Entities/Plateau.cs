using System;
using Mars.Entities.Enums;

namespace Mars.Entities
{
    // Coordinate is the plateau's size
    public class Plateau : Coordinate
    {
        private static Plateau instance;
        private Rover rover;

        public Rover Rover
        {
            get { return rover; }
            set { rover = value; }
        }

        private Plateau() { }

        public static Plateau Mars
        {
            get
            {
                if (instance == null)
                {
                    instance = new Plateau();
                }
                return instance;
            }
        }        

        public void Explore(char[] movements)
        {
            foreach (char ch in movements)
            {
                Movement movement = new Movement(ch);

                if (! (movement.Direction == MovementEnum.M && OnPlateauPerimeter()))
                {
                    this.Rover.Explore(movement);
                }
            }          
        }

        public void Explore(Movement movement)
        {
            if (!(movement.Direction == MovementEnum.M && OnPlateauPerimeter()))
            {
                this.Rover.Explore(movement);
            }            
       }

        public bool OnPlateauPerimeter()
        {
            bool atEdge = false;
                        
            atEdge = this.Rover.Coordinate.Y == 0 && this.Rover.Orientation == CompassPointEnum.S;
            atEdge = this.Rover.Coordinate.X == 0 && this.Rover.Orientation == CompassPointEnum.W || atEdge;
            atEdge = this.Rover.Coordinate.Y == this.Y && this.Rover.Orientation == CompassPointEnum.N || atEdge;
            atEdge = this.Rover.Coordinate.X == this.X && this.Rover.Orientation == CompassPointEnum.E || atEdge;

            return atEdge;             
        }
    } 
}