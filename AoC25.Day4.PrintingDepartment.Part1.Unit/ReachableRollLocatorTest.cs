namespace AoC25.Day4.PrintingDepartment.Part1.Unit;

public class ReachableRollLocatorTest
{
    [Theory]
    [MemberData(nameof(GetReachableRollCount_Success_Data))]
    public void GetReachableRollCount_Success(Shelf shelf, int expectedResult)
    {
        // Arrange
        var instance = new ReachableRollLocator(4);

        // Act
        instance.GetReachableRollCount(shelf);

        // Assert
        Assert.Equal(expectedResult, instance.Count);
    }

    public static IEnumerable<object[]> GetReachableRollCount_Success_Data()
    {
        yield return
        [
            new Shelf { ShelfSchema = [[true], [false]] },
            1
        ];
        yield return
        [
            new Shelf
            {
                ShelfSchema =
                [
                    [true, false, true],
                    [false, true, false],
                    [true, false, true]
                ]
            },
            4
        ];
        yield return
        [
            new Shelf
            {
                ShelfSchema =
                [
                    [true, true, true],
                    [true, true, true],
                    [true, true, true]
                ]
            },
            4
        ];
    }
}