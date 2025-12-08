namespace AoC25.Day1.SecretEntrance.Part1;

public class Dial(int initValue, int numberCount)
{
    public int Value { get; private set; } = initValue;

    private readonly int _numberCount = numberCount;

    public static Dial operator +(Dial a, int b)
    {
        a.Value = (a._numberCount + (a.Value + b) % a._numberCount) % a._numberCount;
        return a;
    }
}