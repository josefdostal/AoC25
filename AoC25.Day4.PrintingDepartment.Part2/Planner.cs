namespace AoC25.Day4.PrintingDepartment.Part2;

public static class Planner
{
    public static int Plan(Shelf shelf)
    {
        var result = 0;
        var locator = new ReachableRollLocator(4);
        var takenRollsCoordinates = new List<(int, int)>();
        locator.OnReachableRollFound += (x, y) => takenRollsCoordinates.Add((x, y));

        do
        {
            TakeRollsOut(shelf, takenRollsCoordinates);
            takenRollsCoordinates.Clear();
            locator.GetReachableRollCount(shelf);

            result += locator.Count;
        } while (locator.Count != 0);

        return result;
    }

    private static void TakeRollsOut(Shelf shelf, List<(int x, int y)> takenRollsCoordinates)
    {
        foreach (var coord in takenRollsCoordinates)
        {
            shelf.ShelfSchema[coord.y][coord.x] = false;
        }
    }
}