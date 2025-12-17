namespace AoC25.Day5.Cafeteria.Part1;

public static class InputParser
{
    public static ImsDb Parse(string input)
    {
        var inputParts = input.Split("\n\n");
        var result = new ImsDb
        {
            FreshRanges = GetFreshRanges(inputParts[0]),
            IngredientIds = GetIngredientIds(inputParts[1])
        };

        return result;
    }

    private static long[] GetIngredientIds(string input)
    {
        var result = new List<long>();
        foreach (var row in input.Split('\n'))
        {
            if (!long.TryParse(row, out var id))
                throw new InvalidDataException("Invalid input");
            
            result.Add(id);
        }
        
        return result.ToArray();
    }

    private static (long from, long to)[] GetFreshRanges(string input)
    {
        var result = new List<(long from, long to)>();
        foreach (var row in input.Split('\n'))
        {
            var ranges = row.Split('-');
            if (!long.TryParse(ranges[0], out var from) || !long.TryParse(ranges[1], out var to))
                throw new InvalidDataException("Invalid input");
            
            result.Add((from, to));
        }

        return result.ToArray();
    }
}