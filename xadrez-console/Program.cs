using System;
using board;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board ChessBoard = new Board(8, 8);
            Screen.DrawBoard(ChessBoard);

            Console.ReadLine();
        }
    }
}
