namespace AoC25.Day5.Cafeteria.Part1;

public static class FreshIngredientFilterProcessor
{
    public static int Process(ImsDb imsDb)
    {
        var myLock = new object();
        var result = 0;
        Parallel.ForEach(imsDb.IngredientIds, id =>
        {
            if (!imsDb.FreshRanges.Any(r => id >= r.from && id <= r.to)) 
                return;
            
            lock (myLock)
                result++;
        });

        return result;
    }
}