namespace AoC25.Day5.Cafeteria.Part2;

public class IdRange
{
    public IdRange(long start, long end)
    {
        if (start > end)
            throw new ArgumentException("Start must be smaller than end");
        Start = start;
        End = end;
    }
    
    public long Start { get; set; }
    public long End { get; set; }
}