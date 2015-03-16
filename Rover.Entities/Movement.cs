using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mars.Entities.Enums;

namespace Mars.Entities
{
    public class Movement
    {
        private MovementEnum direction;

        public Movement() {}

        public Movement(char movement)
        {
            this.Direction = (MovementEnum)Enum.Parse(typeof(MovementEnum), movement.ToString().Substring(0)).GetHashCode();
        }
       
        public MovementEnum Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}
