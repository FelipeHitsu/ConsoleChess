using System;
using System.Collections.Generic;
using board;
using chess;

namespace xadrez_console
{
    class Screen
    {
        public static void DrawGame(ChessGame game)
        {
            DrawBoard(game.GameBoard);
            Console.WriteLine();
            DrawCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Turn: " + game.Turn);
            if (!game.Finished)
            {
                Console.WriteLine("Waiting for move: " + game.ActualPlayer);
                if (game.InCheck)
                    Console.WriteLine("Check !");
            }
            else
            {
                Console.WriteLine("CheckMate !");
                Console.WriteLine("Winner: " + game.ActualPlayer.ToString().ToUpper());
            }
        }
        public static void DrawCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            DrawHashSet(game.GetCapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            DrawHashSet(game.GetCapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void DrawHashSet(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece p in pieces)
                Console.Write(p + " ");
            Console.Write("]");
        }
        public static void DrawBoard(Board b)
        {
            for (int i = 0; i < b.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < b.Columns; j++)
                {
                    DrawPiece(b.GetPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void DrawBoard(Board b,bool [,] possiblePositions)
        {
            ConsoleColor OriginalBackgroundColor = Console.BackgroundColor;
            ConsoleColor MarkedBackgroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < b.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < b.Columns; j++)
                {
                    if (possiblePositions[i, j])
                        Console.BackgroundColor = MarkedBackgroundColor;
                    else
                        Console.BackgroundColor = OriginalBackgroundColor;

                    DrawPiece(b.GetPiece(i, j));
                    Console.BackgroundColor = OriginalBackgroundColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = OriginalBackgroundColor;
        }

        public static void DrawPiece(Piece p)
        {
            if (p == null)
                Console.Write("- ");
            else
            {
                if (p._Color == Color.White)
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

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
    }
}
