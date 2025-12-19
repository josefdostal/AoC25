namespace AoC25.Day6.TrashCompactor.Part1;

public record Operator
{
    public char Symbol { get; }
    public Func<IEnumerable<long>, long> Handler { get; }
    
    private Operator(char symbol, Func<IEnumerable<long>, long> handler)
    {
        Symbol = symbol;
        Handler = handler;
    }

    public static readonly Operator Addition = new('+', x => x.Sum());
    public static readonly Operator Multiplication = new('*', x => x.Aggregate(1L, (a, b) => a * b));
    public static readonly Operator[] All = [Addition, Multiplication];
}