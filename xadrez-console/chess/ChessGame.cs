using System;
using board;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    class ChessGame
    {
        public Board GameBoard { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
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

        public void MakeMove(Position origin,Position destination)
        {
            ExecuteMove(origin, destination);
            NextPlayer();
            Turn++;
        }

        private void NextPlayer()
        {
            if (ActualPlayer == Color.White)
                ActualPlayer = Color.Black;
            else
                ActualPlayer = Color.White;
        }

        public void ValidateOriginPosition(Position p)
        {
            if (GameBoard.GetPiece(p) == null)
                throw new BoardException("Empty position");
            if (ActualPlayer != GameBoard.GetPiece(p)._Color)
                throw new BoardException("Wrong color piece selected");
            if (!GameBoard.GetPiece(p).CanMove())
                throw new BoardException("The selected piece can't move");
        }
        public void ValidateDestination(Position origin,Position destination)
        {
            if (!GameBoard.GetPiece(origin).CanMoveTo(destination))
                throw new BoardException("Invalid Destination Position");
        }
        private void StartPieces()
        {
            GameBoard.InsertPiece(new Tower(GameBoard, Color.White), new ChessPosition('a', 1).ToPosition()); 
            GameBoard.InsertPiece(new Tower(GameBoard, Color.White), new ChessPosition('h', 1).ToPosition());
            GameBoard.InsertPiece(new King(GameBoard, Color.White), new ChessPosition('d', 1).ToPosition());

            GameBoard.InsertPiece(new Tower(GameBoard, Color.Black), new ChessPosition('a', 8).ToPosition());
            GameBoard.InsertPiece(new Tower(GameBoard, Color.Black), new ChessPosition('h', 8).ToPosition());
            GameBoard.InsertPiece(new King(GameBoard, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
