using System;

namespace EightQueens;

public class Queen(string position) : Chess(position)
{
    public override char Symbol => 'Q';

    public override bool OnDangerousPosition(string position)
    {
        var xy = position.Split(',');
        var x = int.Parse(xy[0]);
        var y = int.Parse(xy[1]);
        var onVerticalLine = x == X;
        var onHorizontalLine = y == Y;
        var onCrossLine = Math.Abs(x - X) == Math.Abs(y - Y);
        return onVerticalLine || onHorizontalLine || onCrossLine;
    }
}