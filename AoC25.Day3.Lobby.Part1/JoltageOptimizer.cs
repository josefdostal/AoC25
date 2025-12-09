namespace AoC25.Day3.Lobby.Part1;

public static class JoltageOptimizer
{
    public static int GetHighestJoltage(string batteryBank)
    {
        var maxJoltage = GetHighestDigit(batteryBank);
        var maxJoltageIdx = batteryBank.IndexOf(maxJoltage.ToString()[0]);
        
        var result = maxJoltageIdx == batteryBank.Length - 1
            ? GetHighestDigit(batteryBank[..maxJoltageIdx]) * 10 + maxJoltage
            : maxJoltage * 10 + GetHighestDigit(batteryBank[(maxJoltageIdx+1)..]);

        return result;
    }

    private static int GetHighestDigit(string batteryBank)
    {
        return batteryBank.Select(battery =>
            int.TryParse(battery.ToString(), out var joltage)
                ? joltage
                : throw new InvalidOperationException("Invalid battery format")).Max();
    }
}