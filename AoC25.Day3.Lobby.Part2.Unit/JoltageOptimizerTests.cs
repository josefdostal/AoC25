namespace AoC25.Day3.Lobby.Part2.Unit;

public class JoltageOptimizerTests
{
    [Theory]
    [InlineData("1234", 4, 3)]
    [InlineData("4321", 4, 0)]
    [InlineData("4444", 4, 0)]
    public void GetHighestDigit_Success(string input, int expectedItem, int expectedIndex)
    {
        // Assert
        var (item, index) = JoltageOptimizer.GetHighestDigit(input);

        // Act
        Assert.Equal(expectedItem, item);
        Assert.Equal(expectedIndex, index);
    }

    [Fact]
    public void GetHighestDigit_EmptyInput_Throw()
    {
        // Arrange
        var data = "";
        
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => JoltageOptimizer.GetHighestDigit(data));
    }
}