namespace AoC25.Day6.TrashCompactor.Part1;

public static class InputParser
{
    public static Assignment[] Parse(string input) // TODO this is mess
    {
        var rows = input.Split('\n');
        
        var operandCount = GetRowParts(rows[0]).Count();
        var result = new Assignment[operandCount];

        foreach (var row in rows[..^1])
        {
            var operands = GetRowParts(row).ToArray();
            for (var i = 0; i < operandCount; i++)
            {
                if (!long.TryParse(operands[i], out var value))
                    throw new InvalidDataException("Invalid input");

                result[i] ??= new Assignment();
                result[i].Operands.Add(value);
            }
        }

        var operators = ParseOperators(rows[^1]).ToArray();
        for (var i = 0; i < operandCount; i++)
        {
            result[i].Operator = operators[i];
        }

        return result;
    }

    private static IEnumerable<string> GetRowParts(string row)
    {
        return row.Split(' ').Where(x => x.Length != 0);
    }

    private static IEnumerable<Operator> ParseOperators(string input)
    {
         return GetRowParts(input).Select(x => Operator.All.First(o => o.Symbol == x[0]));
    }
}