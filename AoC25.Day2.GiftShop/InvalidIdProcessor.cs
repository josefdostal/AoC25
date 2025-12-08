namespace AoC25.Day2.GiftShop;

public class InvalidIdProcessor
{
    private readonly IInvalidIdScanner _scanner;

    public InvalidIdProcessor(IInvalidIdScanner scanner)
    {
        _scanner = scanner;
    }
    
    public long Process(string input)
    {
        var idRanges = InputParser.Parse(input);
        var result = new List<long>();
        foreach (var range in idRanges)
        {
            result.AddRange(_scanner.GetInvalidIds(range.start, range.end));
        }

        return result.Sum();
    }
}