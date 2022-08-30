using Warship.Classes;

var map = new Map(10, 10);
map.Show();

var ships = new List<Ship>
{
    new Ship("Battleship", 5, map),
    new Ship("Destroyer", 4, map),
    new Ship("Destroyer", 4, map)
};

ships.ForEach(s => s.PositionShip());

var allShipsDestroyed = false;

while (!allShipsDestroyed)
{
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

        if (map.WasCoordinateShooted(targetCoordinate))
        {
            Console.WriteLine("You were shooting on this position");
            continue;
        }

        targetIsValid = true;
    }

    var hitIsSuccessful = map.IsShipOnTargetField(targetCoordinate);

    switch (hitIsSuccessful)
    {
        case true:
            var shootedShip = ships.Single(s => s.IsOnTarget(targetCoordinate));
            shootedShip.IncreaseDamage();

            map.MarkShoot(targetCoordinate, true);
            Console.Clear();
            map.Show();

            shootedShip.ReportDamage();
            allShipsDestroyed = ships.All(ship => ship.IsDestroyed);
            break;

        case false:
            map.MarkShoot(targetCoordinate, false);
            Console.Clear();
            map.Show();

            Console.WriteLine("You missed");
            break;
    }
}

Console.WriteLine("Congratulations, you won!");
Console.ReadKey();