using System.Numerics;

namespace Common;

public class ArrayMaze : IMaze
{
    public int MazeSizeX { get; }
    public int MazeSizeY { get; }
    public int BlockSize { get; }

    private long[] _storage;

    // sizeof gives bytes, bytes * 8 = bits 
    private const int BitsInLong = sizeof(long) * 8;

    public ArrayMaze(int mazeSizeX, int mazeSizeY, int blockSize)
    {
        MazeSizeX = mazeSizeX;
        MazeSizeY = mazeSizeY;
        BlockSize = blockSize;

        var bitsNeeded = mazeSizeX * mazeSizeY;
        var elementsNeeded = (int)Math.Ceiling((double)bitsNeeded / BitsInLong);

        this._storage = new long[elementsNeeded];
    }

    public ArrayMaze() : this(100, 100, 5)
    {
    }

    public bool IsWallBlock(int x, int y)
    {
        // This part is tricky, so i'll guide you through it

        // First we need to know which bit we need.
        // Because we have coordinates pointing to a specific bit,
        // We skip y number of rows, there are this.MazeSizeX bits in a row.
        // Now we are at the start of proper row, so we just skip X bits, to get to ours.
        int bitIndex = y * this.MazeSizeX + x;

        // This floor division will give us index of long in which we have our bit
        int longIndex = bitIndex / BitsInLong;

        // And remainder will give index of bit in the long
        int bitInLongIndex = bitIndex % BitsInLong;

        // Now we get that long, and do bitwise and like this 1101 & 0100 = 0100
        // Because we need bool, we just compare it to the same bit
        // If there was 1, they are the same, so true, of there was zero,
        // they are not the same and we have false
        return (this._storage[longIndex] & (1 << bitInLongIndex)) == (1 << bitInLongIndex);
    }

    public bool IsWallCell(int x, int y)
    {
        throw new NotImplementedException();
    }
}