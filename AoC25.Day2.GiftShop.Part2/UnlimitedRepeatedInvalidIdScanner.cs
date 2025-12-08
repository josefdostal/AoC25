using System.Text.RegularExpressions;

namespace AoC25.Day2.GiftShop.Part2;

public class UnlimitedRepeatedInvalidIdScanner : IInvalidIdScanner
{
    public IEnumerable<long> GetInvalidIds(long start, long end)
    {
        var result = new List<long>();
        for (var i = start; i <= end; i++)
        {
            var str = i.ToString();
            if (IsIdInvalid(str))
                result.Add(i);
        }

        return result;
    }

    private static bool IsIdInvalid(string id)
    {
        for (var j = 1; j <= id.Length / 2; j++)
        {
            var splits = id.Split(id[..j]);
            if ((splits.Length-1) * j == id.Length)
                return true;
        }

        return false;
    }
}