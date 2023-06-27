namespace Common;

/// <summary>
/// Represents a maze with methods to interact with its structure and properties.
/// </summary>
public interface IMaze
{
    /// <summary>
    /// Gets the size of maze on X axis. Returns number of blocks(groups of cells)
    /// </summary>
    int MazeSizeX { get; }
    
    /// <summary>
    /// Gets the size of maze on Y axis. Returns number of blocks(groups of cells)
    /// </summary>
    int MazeSizeY { get; }

    /// <summary>
    /// Gets the block size. Returns number of cells in block side(block is a square, block size is it's side in cells)
    /// </summary>
    int BlockSize { get; }
    
    
}