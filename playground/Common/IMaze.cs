namespace Common;

/// <summary>
/// Represents a maze with methods to interact with its structure and properties.
/// </summary>
public interface IMaze
{
    /// <summary>
    /// Gets the size of maze on X axis. Returns number of blocks(groups of cells).
    /// </summary>
    int XBlocks { get; }

    /// <summary>
    /// Gets the size of maze on Y axis. Returns number of blocks(groups of cells).
    /// </summary>
    int YBlocks { get; }

    /// <summary>
    /// Gets the block size. Returns number of cells in block side(block is a square, block size is it's side in cells).
    /// </summary>
    int BlockSize { get; }

    /// <summary>
    /// Gets the size of maze on X axis in cells. Returns number of cells.
    /// </summary>
    int XCells => XBlocks * BlockSize;

    /// <summary>
    /// Gets the size of maze on X axis in cells. Returns number of cells.
    /// </summary>
    int YCells => YBlocks * BlockSize;

    /// <summary>
    /// Checks if specified position (x; y) is a wall block in the maze.
    /// <param name="x">The X coordinate of block.</param>
    /// <param name="y">The Y coordinate of block.</param>
    /// <returns>True if block is a wall; otherwise, false.</returns>
    /// </summary>
    bool IsWallBlock(int x, int y);

    /// <summary>
    /// Checks if specified position (x; y) is a wall cell in the maze.
    /// <param name="x">The X coordinate of cell.</param>
    /// <param name="y">The Y coordinate of cell.</param>
    /// <returns>True if cell is a wall; otherwise, false.</returns>
    /// </summary>
    bool IsWallCell(int x, int y);
}