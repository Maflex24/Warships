namespace Warships.Classes
{
    public class Ship
    {
        private readonly Map _map;
        public string Name { get; private set; }
        public int ShipLength { get; private set; }
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();
        public int DamagesAmount { get; private set; }
        public bool IsDestroyed { get; private set; }

        public Ship(string name, int shipLength, Map map)
        {
            _map = map;
            Name = name;
            ShipLength = shipLength;
        }

        public void PositionShip()
        {
            var random = new Random();

            string position = "";
            int startColumn = 0, startRow = 0;

            var collision = true;
            while (collision)
            {
                position = random.Next(2) == 1 ? "vertical" : "horizontal";

                switch (position)
                {
                    case "horizontal":
                        startColumn = random.Next(0, _map.GetColumnsAmount() - ShipLength);
                        startRow = random.Next(0, _map.GetRowsAmount());
                        collision = IsHorizontalCollision(startColumn, startRow);
                        break;

                    case "vertical":
                        startColumn = random.Next(0, _map.GetColumnsAmount());
                        startRow = random.Next(0, _map.GetRowsAmount() - ShipLength);
                        collision = IsVerticalCollision(startRow, startColumn);
                        break;
                }
            }

            var columnKey = (char)_map.alphabet[startColumn];

            if (position == "horizontal")
            {
                for (var column = columnKey; column < columnKey + ShipLength; column++)
                {
                    _map.MapContext[column][startRow] = _map.shipChar;

                    var coordinate = new Coordinate(column, startRow);
                    Coordinates.Add(coordinate);
                }
            }

            if (position == "vertical")
            {
                for (var currentRow = startRow; currentRow < startRow + ShipLength; currentRow++)
                {
                    _map.MapContext[columnKey][currentRow] = _map.shipChar;

                    var coordinate = new Coordinate(columnKey, currentRow);
                    Coordinates.Add(coordinate);
                }
            }
        }

        private bool IsHorizontalCollision(int startColumn, int row)
        {
            var columnKey = (char)_map.alphabet[startColumn];

            for (var currentColumn = columnKey; currentColumn < columnKey + ShipLength; currentColumn++)
            {
                if (_map.MapContext[currentColumn][row] != _map.emptySpaceChar)
                    return true;
            }

            return false;
        }

        private bool IsVerticalCollision(int startRow, int columnIndex)
        {
            var columnKey = (char)_map.alphabet[columnIndex];

            for (var currentRow = startRow; currentRow < startRow + ShipLength; currentRow++)
            {
                if (_map.MapContext[columnKey][currentRow] != _map.emptySpaceChar)
                    return true;
            }

            return false;
        }

        public bool IsOnTarget(Coordinate targetCoordinate)
        {
            foreach (var coordinate in Coordinates)
            {
                if (coordinate.X == targetCoordinate.X && coordinate.Y == targetCoordinate.Y)
                    return true;
            }

            return false;
        }

        public void IncreaseDamage()
        {
            DamagesAmount += 1;

            if (DamagesAmount >= ShipLength)
                IsDestroyed = true;
        }

        public void ReportDamage()
        {
            if (IsDestroyed)
            {
                Console.WriteLine($"You destroyed {Name} completely!");
                return;
            }

            Console.WriteLine($"Your fire get {Name}");
        }
    }
}
