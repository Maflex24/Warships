using System.ComponentModel;

namespace Warship.Classes
{
    public class Map
    {
        private char hitChar { get; } = 'o';
        private char missedChar { get; } = 'x';
        private string alphabet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public Dictionary<char, char[]> ColumnsContext { get; }

        public Map(int columns, int rows)
        {
            var mapContext = new Dictionary<char, char[]>();

            for (var i = 0; i < columns; i++)
            {
                var currentChar = (char)alphabet[i];

                mapContext.Add(currentChar, new char[rows]);
            }

            this.ColumnsContext = mapContext;
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public bool IsCoordinateExist(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public bool WasCoordinateShooted(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public void MarkShoot(Coordinate coordinate, bool successful)
        {
            throw new NotImplementedException();
        }
    }
}
