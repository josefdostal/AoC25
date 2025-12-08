using AoC25.Day1.SecretEntrance.Part1;

namespace AoC25.Features._1_SecretEntrance.Part2;

public class SafeProcessor
{
    private const int SAFE_NUMBER_COUNT = 100;
    private readonly InstructionParser _parser = new();
    private Dial _dial = new(50, SAFE_NUMBER_COUNT);
    private int _count;

    public int Process(string instructions)
    {
        if (string.IsNullOrEmpty(instructions)) throw new ArgumentNullException(nameof(instructions));

        foreach (var instruction in instructions.Split('\n'))
        {
            var num = _parser.GetNumerator(instruction);
            if (num == 0) continue;

            IncCount(num);

            _dial += num;
        }

        return _count;
    }

    private void IncCount(int num)
    {
        var foo = Math.Abs(num) / SAFE_NUMBER_COUNT;

        if (_dial.Value != 0)
        {
            var step = num % SAFE_NUMBER_COUNT;
            var zeroCrossed =
                (num > 0 && SAFE_NUMBER_COUNT - _dial.Value <= step
                 || (num < 0 && _dial.Value <= -step));
            
            if (zeroCrossed)
                foo += 1;
        }

        _count += foo;
    }
}