namespace AoC25.Day2.GiftShop;

public interface IInvalidIdScanner
{
    IEnumerable<long> GetInvalidIds(long start, long end);
}