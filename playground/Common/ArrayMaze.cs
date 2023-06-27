using System.Numerics;

namespace Common;

public class ArrayMaze : IMaze
{
    public int MazeSizeX { get; }
    public int MazeSizeY { get; }
    public int BlockSize { get; }

    public ArrayMaze(int mazeSizeX, int mazeSizeY, int blockSize)
    {
        MazeSizeX = mazeSizeX;
        MazeSizeY = mazeSizeY;
        BlockSize = blockSize;

        var bitsNeeded = mazeSizeX * mazeSizeY;
        var elementsNeeded = (double)bitsNeeded / sizeof(long);
    }

    public ArrayMaze() : this(100, 100, 5)
    {
    }

    public bool IsWallBlock(int x, int y)
    {
        throw new NotImplementedException();
    }

    public bool IsWallCell(int x, int y)
    {
        throw new NotImplementedException();
    }
}