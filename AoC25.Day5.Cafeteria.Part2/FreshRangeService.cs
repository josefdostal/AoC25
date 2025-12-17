namespace AoC25.Day5.Cafeteria.Part2;

public static class FreshRangeService
{
    public static long GetFreshRangeCount(ImsDb db)
    {
        var result = db.FreshRanges.Sum(range =>
        {
            var result = range.End - range.Start + 1;
            return result;
        });

        return result;
    }

    public static void OptimizeFreshRange(ImsDb db)
    {
        var resultRange = new List<IdRange>();
        var q = new Queue<IdRange>(db.FreshRanges);
        
        while (q.TryDequeue(out var i))
        {
            var mergeableRange = q.FirstOrDefault(x =>
                (i.Start <= x.Start && i.End >= x.Start)
                || (i.End >= x.End && i.Start <= x.End)
                || (i.Start >= x.Start && i.End <= x.End)
                || (i.Start <= x.Start && i.End >= x.End));

            if (mergeableRange == null)
            {
                resultRange.Add(new IdRange(i.Start, i.End));
                continue;
            }
            mergeableRange.Start = Math.Min(i.Start, mergeableRange.Start);
            mergeableRange.End = Math.Max(i.End, mergeableRange.End);
        }

        db.FreshRanges = resultRange.ToArray();
    }
}