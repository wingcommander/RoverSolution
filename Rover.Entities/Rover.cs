using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mars.Entities.Enums;

namespace Mars.Entities
{
    public class Rover : Position
    {
        private Camera camera;      

        public Rover(){}
        
        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }       
     
        public void Explore(Movement movement)
        {
            switch (Convert.ToInt32(movement.Direction))
            {
                case (Int32)MovementEnum.M:

                    switch (Convert.ToInt32(this.Orientation))
                    {
                        case (Int32)CompassPointEnum.W:
                            this.Coordinate.X--;
                            break;

                        case (Int32)CompassPointEnum.N:
                            this.Coordinate.Y++;
                            break;

                        case (Int32)CompassPointEnum.E:
                            this.Coordinate.X++;
                            break;

                        case (Int32)CompassPointEnum.S:
                            this.Coordinate.Y--;
                            break;
                    }

                    break;

                // Moving counter clockwise
                case (Int32)MovementEnum.L:

                    this.Orientation = this.Orientation == CompassPointEnum.N ? CompassPointEnum.W : this.Orientation-1;               

                    break;

                // Moving clockwise
                case (Int32)MovementEnum.R:

                    this.Orientation = this.Orientation == CompassPointEnum.W ? CompassPointEnum.N : this.Orientation+1;
                    
                    break;
            }
        }
    }
}
