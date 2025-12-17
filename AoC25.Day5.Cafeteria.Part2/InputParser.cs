namespace AoC25.Day5.Cafeteria.Part2;

public static class InputParser
{
    public static ImsDb Parse(string input)
    {
        var inputParts = input.Split("\n\n");
        var result = new ImsDb
        {
            FreshRanges = GetFreshRanges(inputParts[0]),
        };

        return result;
    }

    private static IdRange[] GetFreshRanges(string input)
    {
        var result = new List<IdRange>();
        foreach (var row in input.Split('\n'))
        {
            var ranges = row.Split('-');
            if (!long.TryParse(ranges[0], out var from) || !long.TryParse(ranges[1], out var to))
                throw new InvalidDataException("Invalid input");
            
            result.Add(new IdRange(from, to));
        }

        return result.ToArray();
    }
}