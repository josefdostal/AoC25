namespace AoC25.Day4.PrintingDepartment.Part1.Unit;

public class InputParserTest
{
    [Fact]
    public void Parse_Success()
    {
        // Arrange
        const string input = """
                             @@@
                             .@@
                             ..@
                             ...
                             """;
        var expectedShelfSchema = new bool[][]
        {
            [true, true, true],
            [false, true, true],
            [false, false, true],
            [false, false, false]
        };
        var instance = new InputParser();

        // Act
        var result = instance.Parse(input);

        // Assert
        Assert.Equal(expectedShelfSchema, result.ShelfSchema);
    }

    [Fact]
    public void Parse_InvalidInputFormat_Throws()
    {
        // Arrange
        const string input = "x";
        var instance = new InputParser();

        // Act + Assert
        Assert.Throws<ArgumentException>(() => instance.Parse(input));
    }
}