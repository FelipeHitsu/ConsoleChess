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
                Console.Write(8 - i + " ");
                for (int j = 0; j < b.Columns; j++)
                {
                    if(b.GetPiece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        DrawPiece(b.GetPiece(i,j));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void DrawPiece(Piece p)
        {
            if(p._Color == Color.White)
                Console.Write(p + " ");
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(p + " ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
