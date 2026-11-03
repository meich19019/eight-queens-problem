using System.Collections.Generic;
using System.Linq;

namespace eight_queens_problem
{
    public class Chessboard
    {
        public int N { get; }
        public Dictionary<string, char> ChessPositions { get; }
        public List<string> SafePositions { get; private set; }
        public char Symbol { get; } = '.';
        public int Count { get; private set; } = 0;

        public Chessboard(int n)
        {
            N = n;
            ChessPositions = new Dictionary<string, char>();
            SafePositions = new List<string>();
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    ChessPositions[string.Join(',', x, y)] = Symbol;
                    SafePositions.Add(string.Join(',', x, y));
                }
            }
        }

        public Chessboard(Chessboard chessboard)
        {
            N = chessboard.N;
            ChessPositions = new Dictionary<string, char>(chessboard.ChessPositions);
            SafePositions = new List<string>(chessboard.SafePositions);
            Symbol = chessboard.Symbol;
            Count = chessboard.Count;
        }

        public void PutChess(Chess chess)
        {
            ChessPositions[string.Join(',', chess.X, chess.Y)] = chess.Symbol;
            List<string> dangerousPositions = new List<string>();
            foreach (string safePosition in SafePositions)
            {
                if (chess.OnDangerousPosition(safePosition))
                {
                    dangerousPositions.Add(safePosition);
                }
            }
            SafePositions = SafePositions.Except(dangerousPositions).ToList();
            Count++;
        }

        public string GetChessboard()
        {
            string result = string.Empty;
            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    result += ChessPositions[string.Join(',', x, y)];
                }
                result += '\n';
            }
            return result;
        }
    }
}
