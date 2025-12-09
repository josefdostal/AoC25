namespace AoC25.Day3.Lobby;

public static class InputParser
{
    public static IEnumerable<string> GetBatteryBanks(string input)
    {
        return input.Split('\n');
    }
}