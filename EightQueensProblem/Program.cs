using System;
using System.Collections.Generic;
using System.Linq;

namespace eight_queens_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNQueens(8);
        }

        public static void PrintNQueens(int n)
        {
            Dictionary<int, List<Chessboard>> totalChessboard = new Dictionary<int, List<Chessboard>>();
            totalChessboard[0] = new List<Chessboard>();
            totalChessboard[0].Add(new Chessboard(n));
            for (int i = 1; i < n + 1; i++)
            {
                totalChessboard[i] = new List<Chessboard>();
                foreach (Chessboard chessboard in totalChessboard[i - 1])
                {
                    if (chessboard.SafePositions.Any())
                    {
                        foreach (string safePosition in chessboard.SafePositions)
                        {
                            int x = int.Parse(safePosition.Split(',')[0]);
                            if (x == i - 1)
                            {
                                Chessboard newChessboard = new Chessboard(chessboard);
                                newChessboard.PutChess(new Queen(safePosition));
                                totalChessboard[i].Add(newChessboard);
                            }
                        }
                    }
                }
            }

            HashSet<string> successChessboards = new HashSet<string>();
            foreach (Chessboard successChessboard in totalChessboard[n])
            {
                successChessboards.Add(successChessboard.GetChessboard());
            }

            int index = 0;
            foreach (string successChessboard in successChessboards)
            {
                index++;
                Console.WriteLine(index);
                Console.WriteLine(successChessboard);
            }
        }
    }
}
