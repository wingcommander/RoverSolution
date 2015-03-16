using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mars.Entities.Enums;

namespace Mars.Entities
{
    public class Position
    {
        private Coordinate coordinate;
        private CompassPointEnum orientation;

        public Position()
        {}

        public Position(Coordinate coordinate)
        {
            this.Coordinate.X = coordinate.X;
            this.Coordinate.Y = coordinate.Y;
        }

        public Position(Coordinate coordinate, CompassPointEnum orientation)
        {
            this.Coordinate.X = coordinate.X;
            this.Coordinate.Y = coordinate.Y;
            this.Orientation = orientation;
        }

        public Coordinate Coordinate
        {
            get
            {
                if (this.coordinate == null)
                {
                    this.coordinate = new Coordinate();                    
                }

                return this.coordinate;
            }
            set { coordinate = value; }
        }

        public CompassPointEnum Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }
    }
}
