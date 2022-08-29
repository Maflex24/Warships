using Warship.Classes;

var map = new Map(10, 10);

var ships = new List<Ship>
{
    new Ship("Battleship", 5, map),
    new Ship("Destroyer", 4, map),
    new Ship("Destroyer", 4, map)
};

ships.ForEach(s => s.PositionShip());

var allShipsDestroyed = false;
var shootCount = 0;

while (!allShipsDestroyed)
{
    Console.WriteLine($"Shooted {shootCount} time(s)\n");

    map.Show();

    var targetCoordinate = new Coordinate();

    var targetIsValid = false;
    while (!targetIsValid)
    {
        Console.Write("Type your target: ");
        var userInput = Console.ReadLine().ToUpper();
        if (userInput == "") continue;

        targetCoordinate = new Coordinate(userInput);

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

        targetIsValid = true;
    }

    var hitSuccessful = map.IsShipOnTargetField(targetCoordinate);
    shootCount++;

    switch (hitSuccessful)
    {
        case true:
            var ship = ships.SingleOrDefault(s => s.IsOnTarget(targetCoordinate));
            ship.IncreaseDamage();
            ship.ReportDamage();
            break;

        case false:
            Console.WriteLine("You missed");
            map.MarkShoot(targetCoordinate, false);

            Console.WriteLine();
            continue;
    }

    map.MarkShoot(targetCoordinate, true);
    allShipsDestroyed = ships.All(ship => ship.Destroyed);
}

Console.WriteLine("Congratulations, you won!");
Console.ReadKey();