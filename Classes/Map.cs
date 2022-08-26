using System.ComponentModel;

namespace Warship.Classes
{
    public class Map
    {
        public Dictionary<char, string> Context { get; private set; }

        public Map(int columns, int rows)
        {
            throw new NotImplementedException();
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
