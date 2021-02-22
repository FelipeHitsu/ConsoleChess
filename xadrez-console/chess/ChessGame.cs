using System;
using board;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class ChessGame
    {
        public Board GameBoard { get; private set; }
        private int Turn;
        private Color ActualPlayer;
        public bool Finished { get; private set; }

        public ChessGame()
        {
            GameBoard = new Board(8,8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            StartPieces();
        }

        public void ExecuteMove(Position origin,Position destination)
        {
            Piece p = GameBoard.RemovePiece(origin);
            p.IncreaseMoveCount();
            Piece captured = GameBoard.RemovePiece(destination);
            GameBoard.InsertPiece(p, destination);
        }

        private void StartPieces()
        {
            GameBoard.InsertPiece(new Tower(GameBoard, Color.White), new ChessPosition('a', 1).ToPosition()); 
            GameBoard.InsertPiece(new Tower(GameBoard, Color.White), new ChessPosition('h', 1).ToPosition());
            GameBoard.InsertPiece(new King(GameBoard, Color.White), new ChessPosition('d', 1).ToPosition());
        }
    }
}
