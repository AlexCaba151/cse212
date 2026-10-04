/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
/// (x,y) : [left, right, up, down]
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.
/// If there is a wall, then throw an InvalidOperationException with the message
/// "Can't go that way!". If there is no wall, then the 'currX' and 'currY'
/// values should be changed.
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

    public void MoveLeft()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--;
    }

    public void MoveRight()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++;
    }

    public void MoveUp()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY--;
    }

    public void MoveDown()
    {
        var directions = _mazeMap[(_currX, _currY)];

        if (!directions[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}