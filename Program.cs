using Warship.Classes;

var map = new Map(10, 10);

var ships = new List<Ship>
{
    new Ship("Battleship", 5, map),
    new Ship("Destroyer", 4, map),
    new Ship("Destroyer", 4, map)
};

ships.ForEach(s => s.PositionShip());

while (true)
{
    map.Show();

    Coordinate targetCoordinate;

    while (true)
    {
        Console.Write("Type your target: ");
        targetCoordinate = Coordinate.CreateCoordinateFromInput(Console.ReadLine().ToUpper());

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
            Console.WriteLine("You were shooting on this position");
        else
            break;
    }

    var hitSuccessful = false;
    foreach (var ship in ships)
    {
        var isOnTarget = ship.IsOnTarget(targetCoordinate);

        if (isOnTarget)
        {
            hitSuccessful = true;
            ship.IncreaseDamage();
            ship.ReportDamage();
        }
    }

    if (!hitSuccessful)
    {
        Console.WriteLine("You missed");
        map.MarkShoot(targetCoordinate, false);
        continue;
    }

    map.MarkShoot(targetCoordinate, true);

    var allShipsDestroyed = ships.All(ship => ship.Destroyed);

    if (allShipsDestroyed) break;
}

Console.WriteLine("Congratulations, you won!");