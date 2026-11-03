using System.Collections.Generic;
using System.Linq;

namespace EightQueensProblem;

public class Chessboard
{
    public int N { get; }
    public Dictionary<string, char> ChessPositions { get; }
    public List<string> SafePositions { get; private set; }
    public char Symbol { get; } = '.';
    public int Count { get; private set; }

    public Chessboard(int n)
    {
        N = n;
        ChessPositions = new Dictionary<string, char>();
        SafePositions = [];
        for (var x = 0; x < N; x++)
        {
            for (var y = 0; y < N; y++)
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
        var dangerousPositions = SafePositions.Where(chess.OnDangerousPosition).ToList();
        SafePositions = SafePositions.Except(dangerousPositions).ToList();
        Count++;
    }

    public string GetChessboard()
    {
        var result = string.Empty;
        for (var y = 0; y < N; y++)
        {
            for (var x = 0; x < N; x++)
            {
                result += ChessPositions[string.Join(',', x, y)];
            }
            result += '\n';
        }
        return result;
    }
}