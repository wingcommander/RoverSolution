using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mars.Entities
{
    public class Coordinate
    {
        public Coordinate()
        { }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
       
        private Int32 x;

        public Int32 X
        {
            get { return x; }
            set { x = value; }
        }
        private Int32 y;

        public Int32 Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
