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
        private string columnSeparator { get; } = "|";
        private string alphabet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

            var mapRowsQty = this.MapContext['A'].Length;

            foreach (var column in MapContext.Keys)
            {
                topContext.Append(columnSeparator + column);
            }

            for (var currentRow = 0; currentRow < mapRowsQty; currentRow++)
            {
                var rowIndex = (currentRow + 1).ToString().PadLeft(2);
                rowsContext.Append("\n" + rowIndex + columnSeparator);

                foreach (var column in MapContext.Keys)
                {
                    rowsContext.Append(MapContext[column][currentRow] + columnSeparator);
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
            var rowExist = MapContext[column].Length >= row;

            return rowExist;
        }

        public bool WasCoordinateShooted(Coordinate coordinate)
        {
            var coordinatePositionContext = MapContext[coordinate.X][coordinate.Y - 1];
            var wasShooted = coordinatePositionContext == missedChar || coordinatePositionContext == hitChar;

            return wasShooted;
        }

        public void MarkShoot(Coordinate coordinate, bool successful)
        {
            var symbol = successful ? hitChar : missedChar;

            MapContext[coordinate.X][coordinate.Y - 1] = symbol;
        }
    }
}
