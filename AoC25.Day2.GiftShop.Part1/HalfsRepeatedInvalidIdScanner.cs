namespace AoC25.Day2.GiftShop.Part1;

public class HalfsRepeatedInvalidIdScanner : IInvalidIdScanner
{
    public IEnumerable<long> GetInvalidIds(long start, long end)
    {
        var result = new List<long>();
        
        for (var i = start; i <= end; i++)
        {
            var str = i.ToString();
            if (str.Length % 2 != 0)
                continue;
            
            if (str[..(str.Length/2)].Equals(str[(str.Length/2)..]))
                result.Add(i);
        }

        return result;
    }
}