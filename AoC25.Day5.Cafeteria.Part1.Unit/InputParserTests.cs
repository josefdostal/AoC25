using FluentAssertions;

namespace AoC25.Day5.Cafeteria.Part1.Unit;

public class InputParserTests
{
    [Fact]
    public void Parse_Success()
    {
        // Arrange
        const string input = """
                             1-2
                             2-3

                             1
                             2
                             3
                             """;
        var expected = new ImsDb
        {
            FreshRanges = [(1, 2), (2, 3)],
            IngredientIds = [1, 2, 3]
        };
        
        // Act
        var result = InputParser.Parse(input);

        // Assert
        result.FreshRanges.Should().BeEquivalentTo(expected.FreshRanges);
        result.IngredientIds.Should().BeEquivalentTo(expected.IngredientIds);
    }
}