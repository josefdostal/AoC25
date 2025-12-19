namespace AoC25.Day6.TrashCompactor.Part1;

public record Assignment
{
    public IList<long> Operands { get; set; } = new List<long>();
    public Operator Operator { get; set; } = null!;
}