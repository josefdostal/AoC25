namespace AoC25.Day1.SecretEntrance.Part1;

public class InstructionParser
{
    public int GetNumerator(string instruction)
    {
        if (string.IsNullOrEmpty(instruction))
            return 0;
        
        var direction = instruction[0];

        return GetDirection(direction) * GetCount(instruction[1..]);
    }

    private static int GetDirection(char direction)
        => direction switch
        {
            'L' => -1,
            'R' => 1,
            _ => throw new InvalidOperationException("Unknown direction input")
        };

    private static int GetCount(string countStr)
        => int.TryParse(countStr, out var count) 
            ? count 
            : throw new InvalidOperationException("Invalid instruction");
}