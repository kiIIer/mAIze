using Common;

namespace TestCommon;

public class TestArrayMaze
{
    [Test]
    [TestCase(5, 5, 5)]
    [TestCase(1, 2, 3)]
    [TestCase(3, 2, 1)]
    [TestCase(1, 10, 50)]
    [TestCase(12, 23, 44)]
    public void TestConstructor(int sizeX, int sizeY, int blockSize)
    {
        // Arrange.
        var random = new Random(sizeX + sizeY + blockSize);
        var storage = new[] { random.NextInt64() };

        // Act.
        var maze = new ArrayMaze(sizeX, sizeY, blockSize, storage);

        // Assert.
        Assert.Multiple(() =>
        {
            Assert.That(maze.MazeSizeX, Is.EqualTo(sizeX), nameof(maze.MazeSizeX));
            Assert.That(maze.MazeSizeY, Is.EqualTo(sizeY), nameof(maze.MazeSizeY));
            Assert.That(maze.BlockSize, Is.EqualTo(blockSize), nameof(maze.BlockSize));
            Assert.That(maze.Storage, Is.EqualTo(storage), nameof(maze.Storage));
        });
    }

    [Test]
    [TestCase(8, 8, new[] { 1L << 0 }, 0, 0, true)]
    [TestCase(8, 8, new[] { 1L << 1 }, 1, 0, true)]
    [TestCase(8, 8, new[] { 1L << 2 }, 2, 0, true)]
    [TestCase(8, 8, new[] { 1L << 3 }, 3, 0, true)]
    [TestCase(8, 8, new[] { 1L << (0 + 8 * 1) }, 0, 1, true)]
    [TestCase(8, 8, new[] { 1L << (1 + 8 * 1) }, 1, 1, true)]
    [TestCase(8, 8, new[] { 1L << (4 + 8 * 4) }, 4, 4, true)]
    [TestCase(8, 8, new[] { 1L }, 1, 5, false)]
    [TestCase(8, 8, new[] { 1L }, 2, 4, false)]
    [TestCase(8, 8, new[] { 1L }, 3, 3, false)]
    [TestCase(8, 8, new[] { 1L }, 4, 2, false)]
    [TestCase(8, 16, new[] { 0L, 1L }, 0, 8, true)]
    [TestCase(16, 8, new[] { 0L, 1L }, 0, 4, true)]
    public void TestIsWallBlock(int sizeX, int sizeY, long[] storage, int x, int y, bool expected)
    {
        // Arrange.
        var arrayMaze = new ArrayMaze(sizeX, sizeY, 1, storage);

        // Act.
        bool actual = arrayMaze.IsWallBlock(x, y);

        // Assert.
        Assert.That(actual, Is.EqualTo(expected), nameof(arrayMaze.IsWallBlock));
    }

    [Test]
    [TestCase(8, 8, 1, new[] { 1L << 0 }, 0, 0, true)]
    [TestCase(8, 8, 2, new[] { 1L << 1 }, 3, 0, true)]
    [TestCase(8, 8, 3, new[] { 1L << 2 }, 7, 0, true)]
    [TestCase(8, 8, 4, new[] { 1L << 3 }, 13, 0, true)]
    [TestCase(8, 8, 5, new[] { 1L << (0 + 8 * 1) }, 0, 5, true)]
    [TestCase(8, 8, 5, new[] { 1L << (1 + 8 * 1) }, 6, 8, true)]
    [TestCase(8, 8, 5, new[] { 1L << (4 + 8 * 4) }, 21, 22, true)]
    [TestCase(8, 8, 5, new[] { 1L }, 12, 5, false)]
    [TestCase(8, 8, 5, new[] { 1L }, 12, 4, false)]
    [TestCase(8, 8, 5, new[] { 1L }, 23, 3, false)]
    [TestCase(8, 8, 5, new[] { 1L }, 14, 2, false)]
    [TestCase(8, 16, 5, new[] { 0L, 1L }, 0, 41, true)]
    [TestCase(16, 8, 5, new[] { 0L, 1L }, 0, 23, true)]
    public void TestIsWallCell(int sizeX, int sizeY, int blockSize, long[] storage, int x, int y, bool expected)
    {
        // Arrange.
        var arrayMaze = new ArrayMaze(sizeX, sizeY, blockSize, storage);

        // Act.
        bool actual = arrayMaze.IsWallCell(x, y);

        // Assert.
        Assert.That(actual, Is.EqualTo(expected), nameof(arrayMaze.IsWallCell));
    }
}