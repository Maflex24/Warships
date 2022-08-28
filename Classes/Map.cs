using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Warship.Classes
{
    public class Map
    {
        public char hitChar { get; } = 'o';
        public char missedChar { get; } = 'x';
        public char shipChar { get; } = 's';
        private const string columnSeparator = "|";
        public string alphabet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Dictionary<char, char[]> MapContext { get; }

        public Map(int columns, int rows)
        {
            var mapContext = new Dictionary<char, char[]>();

            for (var columnIndex = 0; columnIndex < columns; columnIndex++)
            {
                var currentChar = (char)alphabet[columnIndex];
                mapContext.Add(currentChar, new char[rows]);

                for (var rowIndex = 0; rowIndex < rows; rowIndex++)
                {
                    mapContext[currentChar][rowIndex] = ' ';
                }
            }

            MapContext = mapContext;
        }

        public void Show()
        {
            var topContext = new StringBuilder().Append("  ");
            var rowsContext = new StringBuilder();

            var mapRowsAmount = GetRowsAmount();

            foreach (var column in MapContext.Keys)
            {
                topContext.Append(columnSeparator + column);
            }

            for (var currentRow = 0; currentRow < mapRowsAmount; currentRow++)
            {
                var rowIndex = (currentRow + 1).ToString().PadLeft(2);
                rowsContext.Append("\n" + rowIndex + columnSeparator);

                foreach (var column in MapContext.Keys)
                {
                    var currentChar = MapContext[column][currentRow];
                    //if (currentChar == shipChar) // TODO uncomment it
                    //    currentChar = ' ';

                    rowsContext.Append(currentChar + columnSeparator);
                }
            }

            var totalContext = topContext.Append(rowsContext);
            Console.WriteLine(totalContext.ToString());
        }

        public bool IsCoordinateExist(Coordinate coordinate)
        {
            var column = coordinate.X;
            var columnExist = MapContext.ContainsKey(column);

            if (!columnExist) return false;

            var row = coordinate.Y;
            if (row >= MapContext[column].Length || row < 0) return false;
            var rowExist = MapContext[column][row] != null;

            return rowExist;
        }

        public bool WasCoordinateShooted(Coordinate coordinate)
        {
            var coordinatePositionContext = MapContext[coordinate.X][coordinate.Y];
            var wasShooted = coordinatePositionContext == missedChar || coordinatePositionContext == hitChar;

            return wasShooted;
        }

        public bool IsShipOnTargetField(Coordinate coordinate) => MapContext[coordinate.X][coordinate.Y] == shipChar;

        public void MarkShoot(Coordinate coordinate, bool successful)
        {
            var symbol = successful ? hitChar : missedChar;

            MapContext[coordinate.X][coordinate.Y] = symbol;
        }

        internal int GetRowsAmount() => MapContext['A'].Length;
        internal int GetColumnsAmount() => MapContext.Count;
    }
}
