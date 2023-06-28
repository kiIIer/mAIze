using Common;

namespace TestCommon;

public class TestIMaze
{
    [Test]
    [TestCase(5, 5, 25)]
    [TestCase(4, 5, 20)]
    [TestCase(3, 5, 15)]
    [TestCase(2, 5, 10)]
    [TestCase(2, 3, 6)]
    [TestCase(2, 2, 4)]
    public void TestMazeSizeXInCells(int sizeX, int blockSize, int expected)
    {
        // Arrange.
        IMaze maze = new ArrayMaze(sizeX, 1, blockSize, new[] { 0L });

        // Act.
        int actual = maze.XCells;

        // Assert.
        Assert.That(actual, Is.EqualTo(expected), nameof(maze.XCells));
    }

    [Test]
    [TestCase(5, 5, 25)]
    [TestCase(4, 5, 20)]
    [TestCase(3, 5, 15)]
    [TestCase(2, 5, 10)]
    [TestCase(2, 3, 6)]
    [TestCase(2, 2, 4)]
    public void TestMazeSizeYInCells(int sizeY, int blockSize, int expected)
    {
        // Arrange.
        IMaze maze = new ArrayMaze(1, sizeY, blockSize, new[] { 0L });

        // Act.
        int actual = maze.YCells;

        // Assert.
        Assert.That(actual, Is.EqualTo(expected), nameof(maze.YCells));
    }
}