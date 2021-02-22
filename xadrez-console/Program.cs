using System;
using board;
using chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board ChessBoard = new Board(8, 8);
                ChessBoard.InsertPiece(new Tower(ChessBoard, Color.Black), new Position(0, 0));
                ChessBoard.InsertPiece(new Tower(ChessBoard, Color.Black), new Position(1, 3));
                ChessBoard.InsertPiece(new King(ChessBoard, Color.White), new Position(2, 4));

                Screen.DrawBoard(ChessBoard);
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
