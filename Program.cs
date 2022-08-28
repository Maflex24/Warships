using System.Threading.Channels;
using Warship.Classes;

var map = new Map(10, 10);

var ships = new List<Ship>
{
    new Ship("Battleship", 5, map),
    new Ship("Destroyer", 4, map),
    new Ship("Second Destroyer", 4, map)
};

ships.ForEach(s => s.PositionShip());
bool allShipsDestroyed = false;

var shootCount = 0;

while (!allShipsDestroyed)
{
    Console.WriteLine($"Shooted {shootCount} time(s)");
    map.Show();

    Coordinate targetCoordinate = null;

    bool targedIsValid = false;
    while (!targedIsValid)
    {
        Console.Write("Type your target: ");
        targetCoordinate = new Coordinate(Console.ReadLine().ToUpper());

        if (targetCoordinate is null)
        {
            Console.WriteLine("Your coordinate is wrong. Try again!");
            continue;
        }

        if (!map.IsCoordinateExist(targetCoordinate))
        {
            Console.WriteLine("Coordinate doesn't exist");
            continue;
        }

        var positionWasShootAt = map.WasCoordinateShooted(targetCoordinate);
        if (positionWasShootAt)
        {
            Console.WriteLine("You were shooting on this position");
            continue;
        }

        targedIsValid = true;
    }

    var hitSuccessful = map.IsShipOnTargetField(targetCoordinate);
    shootCount++;

    if (hitSuccessful)
    {
        foreach (var ship in ships.Where(s => !s.Destroyed))
        {
            if (ship.IsOnTarget(targetCoordinate))
            {
                ship.IncreaseDamage();
                ship.ReportDamage();
                break;
            }
        }
    }

    if (!hitSuccessful)
    {
        Console.WriteLine("You missed");
        map.MarkShoot(targetCoordinate, false);

        Console.WriteLine();
        continue;
    }

    map.MarkShoot(targetCoordinate, true);

    allShipsDestroyed = ships.All(ship => ship.Destroyed);

    ships.ForEach(s => Console.WriteLine($"{s.Name} {s.ShipLength - s.DamagesAmount}/{s.ShipLength}"));
    Console.WriteLine();
}

Console.WriteLine("Congratulations, you won!");
Console.ReadKey();