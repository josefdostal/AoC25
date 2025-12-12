namespace AoC25.Day4.PrintingDepartment;

public class InputParser
{
    public Shelf Parse(string input)
    {
        var shelfSchema = ParseShelfSchema(input);

        var result = new Shelf
        {
            ShelfSchema = shelfSchema
        };

        return result;
    }

    private static bool[][] ParseShelfSchema(string input)
    {
        var result = input.Split('\n').Select((x, _) =>
            x.Select(c => c switch
            {
                '@' => true,
                '.' => false,
                _ => throw new ArgumentException("Invalid shelf format")
            }).ToArray()
        ).ToArray();

        return result;
    }
}