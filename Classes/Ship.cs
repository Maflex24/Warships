using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warship.Classes
{
    public class Ship
    {
        public string Name { get; private set; }
        public int ShipLarge { get; private set; }
        public List<Coordinate> Coordinates { get; set; }
        public int DamagesAmount { get; private set; }
        public bool Destroyed { get; private set; }

        public Ship(string name, int shipLarge)
        {
            Name = name;
            ShipLarge = shipLarge;
        }

        internal void PositionShip()
        {
            throw new NotImplementedException();
        }

        public bool IsOnTarget(Coordinate targetCoordinate)
        {
            throw new NotImplementedException();
        }

        public void IncreaseDamage() // +1 to DamagesAmount, and Destroyed = true if DamagesAmount == ShipLarge
        {
            throw new NotImplementedException();
        }

        public void ReportDamage() // Print info about damage, and destroyed if it's true
        {
            throw new NotImplementedException();
        }
    }
}
