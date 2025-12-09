namespace AoC25.Day3.Lobby.Part2.Unit;

public class AscSortedListTests
{
    [Theory]
    [MemberData(nameof(AddData))]
    public void Add_Success(List<int> initial, int add, List<int> expectedResult)
    {
        // Arrange
        var list = new AscSortedList<int>(initial);

        // Act
        list.Add(add);

        // Assert
        Assert.Equal(expectedResult, list.ToList());
    }

    public static IEnumerable<object[]> AddData()
    {
        yield return [new List<int> { 1, 2, 3, 4 }, 5, new List<int> { 1, 2, 3, 4, 5 }];
        yield return [new List<int> { 1, 2, 4 }, 3, new List<int> { 1, 2, 3, 4 }];
        yield return [new List<int> { 4, 4 }, 3, new List<int> { 3, 4, 4 }];
        yield return [new List<int> { 4, 4 }, 4, new List<int> { 4, 4, 4 }];
    }

    [Theory]
    [MemberData(nameof(IndexData))]
    public void Ctor_Success(List<int> initial, List<int> expectedResult)
    {
        // Act
        var list = new AscSortedList<int>(initial);

        // Assert
        Assert.Equal(expectedResult, list.ToList());
    }

    public static IEnumerable<object[]> IndexData()
    {
        yield return [new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 }];
        yield return [new List<int> { 3, 1, 2 }, new List<int> { 1, 2, 3 }];
    }
}