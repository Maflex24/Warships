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
        public Coordinate(string input)
        {
            var x = input[0];

            if (int.TryParse(input.Substring(1), out var y))
            {
                X = x;
                Y = y - 1; // Y is for array, started from 0, user inputs is started from 1
            }
        }

        public Coordinate() { }
    }
}
