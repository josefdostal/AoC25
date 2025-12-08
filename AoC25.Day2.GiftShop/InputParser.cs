namespace AoC25.Day2.GiftShop;

public static class InputParser
{
    public static IEnumerable<(long start, long end)> Parse(string idRanges)
    {
        var result = idRanges.Split(",").Select(x =>
        {
            var range = x.Split('-');
            
            if (range.Length != 2
                || !long.TryParse(range[0], out var start)
                || !long.TryParse(range[1], out var end))
                throw new InvalidOperationException("Invalid range format");
                
            return (start, end);
        });

        return result.ToList();
    }
}
