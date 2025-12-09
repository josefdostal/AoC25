namespace AoC25.Day3.Lobby.Part2;

public static class JoltageOptimizer
{
    private const int LENGTH = 12;
    public static long GetHighestJoltage(string batteryBank)
    {
        if (string.IsNullOrEmpty(batteryBank) || batteryBank.Length < LENGTH)
            throw new ArgumentException("Invalid joltage format");

        var indexes = new SortedList<int, int>();

        var highest = GetHighestDigit(batteryBank);
        indexes.Add(highest.index, highest.item);
        
        for (var i = 1; i < LENGTH; i++)
        {
            var lastIdx = indexes.ElementAt(indexes.Count - 1);
            if (batteryBank.Length - lastIdx.Key != 1)
            {
                var secondHighest = GetHighestDigit(batteryBank[(lastIdx.Key + 1)..]);
                indexes.Add(secondHighest.index + lastIdx.Key + 1, secondHighest.item);
                continue;
            }

            if (GetHighestBetweenIndexes(batteryBank, indexes))
                continue;

            var x = GetHighestDigit(batteryBank[..indexes.ElementAt(0).Key]);
            indexes.Add(x.index, x.item);
        }

        var result = indexes.Select((x, idx) => x.Value * (long)Math.Pow(10, LENGTH - 1 - idx)).Sum();

        return result;
    }

    private static bool GetHighestBetweenIndexes(string batteryBank, SortedList<int, int> indexes)
    {
        if (indexes.Count < 2)
            return false;

        for (var i = indexes.Count - 1; i > 0; i--)
        {
            if (indexes.ElementAt(i).Key - indexes.ElementAt(i - 1).Key <= 1)
                continue;
            var digit = GetHighestDigit(batteryBank[(indexes.ElementAt(i - 1).Key+1)..indexes.ElementAt(i).Key]);
            indexes.Add(digit.index + indexes.ElementAt(i-1).Key + 1, digit.item);
            return true;
        }

        return false;
    }

    public static (int item, int index) GetHighestDigit(string batteryBank)
    {
        if (string.IsNullOrEmpty(batteryBank))
            throw new ArgumentNullException(nameof(batteryBank));

        var item = 0;
        var index = 0;
        for (var i = 0; i < batteryBank.Length; i++)
        {
            if (!int.TryParse(batteryBank[i].ToString(), out var digit))
                throw new InvalidOperationException("Invalid joltage format");
            if (digit <= item) continue;

            item = digit;
            index = i;
        }

        return (item, index);
    }
}