using System;
using System.Threading;
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
                    //Debug
                    /*for(int i = 0; i < game.GameBoard.Lines; i++)
                    {
                        for (int j = 0;j < game.GameBoard.Columns; j++)
                        {
                            Console.Clear();
                            //Screen.DrawBoard(game.GameBoard);
                            Position position = new Position(i,j);
                            game.GameBoard.InsertPiece(new Tower(game.GameBoard, Color.White),position);
                            Console.Write("Position: ");
                            Console.WriteLine("Position: " + position);
                            bool[,] PossiblePositions = game.GameBoard.GetPiece(position).PossibleMoves();
                            Screen.DrawBoard(game.GameBoard,PossiblePositions);
                            Thread.Sleep(1000);
                            game.GameBoard.RemovePiece(position);
                        }
                    }*/


                    //GameLoop
                    Console.Clear();
                    Screen.DrawBoard(game.GameBoard);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    bool[,] PossiblePositions = game.GameBoard.GetPiece(origin).PossibleMoves();
                    Console.Clear();
                    Screen.DrawBoard(game.GameBoard,PossiblePositions);
                    Console.Write("Destino: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    game.ExecuteMove(origin, destination);
                }


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
