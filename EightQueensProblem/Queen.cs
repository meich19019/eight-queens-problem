using System;
namespace eight_queens_problem
{
    public class Queen : Chess
    {
        public Queen(string position) : base(position) { }
        public override char Symbol { get; } = 'Q';

        public override bool OnDangerousPosition(string position)
        {
            string[] xy = position.Split(',');
            int x = int.Parse(xy[0]);
            int y = int.Parse(xy[1]);
            bool onVerticalLine = x == X;
            bool onHorizontalLine = y == Y;
            bool onCrossLine = Math.Abs(x - X) == Math.Abs(y - Y);
            return onVerticalLine || onHorizontalLine || onCrossLine;
        }
    }
}
