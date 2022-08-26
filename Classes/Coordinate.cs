using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warship.Classes
{
    public class Coordinate
    {
        public char X { get; set; }
        public int Y { get; set; }

        public Coordinate(char x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate CreateCoordinateFromInput(string userInput)
        {
            throw new NotImplementedException();
        }
    }
}
