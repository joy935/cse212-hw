/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        // check if the current x is at the leftmost edge of the maze
        if (_currX == 1) {
            throw new InvalidOperationException("Can't go that way!");
        // check if the left direction is blocked
        } else if (_mazeMap[(_currX, _currY)][0] == false) {
            throw new InvalidOperationException("Can't go that way!");
        // if the left direction is not blocked, move left
        } else {
            _currX--;
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        // check if the current x is at the rightmost edge of the maze
        if (_currX == 6) {
            throw new InvalidOperationException("Can't go that way!");
        // check if the right direction is blocked
        } else if (_mazeMap[(_currX, _currY)][1] == false) {
            throw new InvalidOperationException("Can't go that way!");
        // if the right direction is not blocked, move right
        } else {
            _currX++;
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        // check if the current y is at the topmost edge of the maze
        if (_currY == 1) {
            throw new InvalidOperationException("Can't go that way!");
        // check if the up direction is blocked
        } else if (_mazeMap[(_currX, _currY)][2] == false) {
            throw new InvalidOperationException("Can't go that way!");
        // if the up direction is not blocked, move up
        } else {
            _currY--;
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        // check if the current y is at the bottommost edge of the maze
        if (_currY == 6) {
            throw new InvalidOperationException("Can't go that way!");
        // check if the down direction is blocked
        } else if (_mazeMap[(_currX, _currY)][3] == false) {
            throw new InvalidOperationException("Can't go that way!");
        // if the down direction is not blocked, move down
        } else {
            _currY++;
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}