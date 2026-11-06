namespace EightQueens;

public abstract class Chess
{
    public string Position { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public abstract char Symbol { get; }

    protected Chess(string position)
    {
        Position = position;
        var xy = position.Split(',');
        X = int.Parse(xy[0]);
        Y = int.Parse(xy[1]);
    }

    public abstract bool OnDangerousPosition(string s);
}