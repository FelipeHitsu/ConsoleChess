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
                ChessGame game = new ChessGame();

                while (!game.Finished)
                {
                    Console.Clear();
                    Screen.DrawBoard(game.GameBoard);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destino: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    game.ExecuteMove(origin, destination);
                }

                
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
