namespace AoC25.Day4.PrintingDepartment;

public delegate void ReachableRollFoundHandler(int x, int y);
public class ReachableRollLocator
{
    private readonly int _blockingRollAmount;
    public int Count { get; private set; }

    public event ReachableRollFoundHandler? OnReachableRollFound;
    private readonly (int, int)[] _matrix =
    [
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), /* --- */ (0, 1),
        (1, -1), (1, 0), (1, 1)
    ];

    public ReachableRollLocator(int blockingRollAmount)
    {
        _blockingRollAmount = blockingRollAmount;
        OnReachableRollFound += (_, _) => Count++;
    }

    public void GetReachableRollCount(Shelf shelf)
    {
        Count = 0;
        for (var y = 0; y < shelf.ShelfSchema.Length; y++)
        {
            for (var x = 0; x < shelf.ShelfSchema[y].Length; x++)
            {
                if (!shelf.ShelfSchema[y][x])
                    continue;

                var count = _matrix.Count(f =>
                {
                    var (h, v) = f;
                    return x + h >= 0
                                 && x + h < shelf.ShelfSchema.Length
                                 && y + v >= 0
                                 && y + v < shelf.ShelfSchema[x + h].Length
                                 && shelf.ShelfSchema[y + v][x + h];
                });
                if (count < _blockingRollAmount)
                {
                    OnReachableRollFound?.Invoke(x, y);
                }
            }
        }
    }
}