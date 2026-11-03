using System;
using System.Collections.Generic;

namespace EightQueensProblem;

internal class Program
{
    private static void Main()
    {
        PrintNQueens(8);
    }

    private static void PrintNQueens(int n)
    {
        var totalChessboard = new Dictionary<int, List<Chessboard>>
        {
            [0] = [new Chessboard(n)]
        };

        for (var i = 1; i < n + 1; i++)
        {
            totalChessboard[i] = [];
            foreach (var chessboard in totalChessboard[i - 1])
            {
                if (chessboard.SafePositions.Count == 0) continue;
                foreach (var safePosition in chessboard.SafePositions)
                {
                    var x = int.Parse(safePosition.Split(',')[0]);
                    if (x != i - 1) continue;
                    var newChessboard = new Chessboard(chessboard);
                    newChessboard.PutChess(new Queen(safePosition));
                    totalChessboard[i].Add(newChessboard);
                }
            }
        }

        var successChessboards = new HashSet<string>();
        foreach (var successChessboard in totalChessboard[n])
        {
            successChessboards.Add(successChessboard.GetChessboard());
        }

        var index = 0;
        foreach (var successChessboard in successChessboards)
        {
            index++;
            Console.WriteLine(index);
            Console.WriteLine(successChessboard);
        }
    }
}