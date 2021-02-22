using System;
using board;

namespace xadrez_console
{
    class Screen
    {
        public static void DrawBoard(Board b)
        {
            for (int i = 0; i < b.Lines; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    if(b.GetPiece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(b.GetPiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
