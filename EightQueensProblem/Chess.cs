namespace eight_queens_problem
{
    public abstract class Chess
    {
        public string Position { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public abstract char Symbol { get; }

        public Chess(string position)
        {
            Position = position;
            string[] xy = position.Split(',');
            X = int.Parse(xy[0]);
            Y = int.Parse(xy[1]);
        }

        public abstract bool OnDangerousPosition(string s);
    }
}
