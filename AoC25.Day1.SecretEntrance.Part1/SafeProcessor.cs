namespace AoC25.Day1.SecretEntrance.Part1;

public class SafeProcessor
{
    private const int SAFE_NUMBER_COUNT = 100;
    
    private Dial _dial = new(50, SAFE_NUMBER_COUNT);
    private int _count;
    private readonly InstructionParser _parser = new();

    public int Process(string instructions)
    {
        if (string.IsNullOrEmpty(instructions)) throw new ArgumentNullException(nameof(instructions));

        foreach (var instruction in instructions.Split('\n'))
        {
            var num = _parser.GetNumerator(instruction);
            _dial += num;
            
            if (_dial.Value == 0)
            {
                _count++;
            }
        }

        return _count;
    }
}