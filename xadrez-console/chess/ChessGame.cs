using System;
using board;
using System.Collections.Generic;


namespace chess
{
    class ChessGame
    {
        public Board GameBoard { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessGame()
        {
            GameBoard = new Board(8,8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            StartPieces();
        }

        public void ExecuteMove(Position origin,Position destination)
        {
            Piece p = GameBoard.RemovePiece(origin);
            p.IncreaseMoveCount();
            Piece capturedPiece = GameBoard.RemovePiece(destination);
            GameBoard.InsertPiece(p, destination);
            if (capturedPiece != null)
                CapturedPieces.Add(capturedPiece);
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
        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in CapturedPieces)
            {
                if (p._Color == color)
                    aux.Add(p);
            }
            return aux;
        }
        public HashSet<Piece> GetInGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in Pieces)
            {
                if (p._Color == color)
                    aux.Add(p);
            }
            aux.ExceptWith(GetCapturedPieces(color));
            return aux;
        }
        public void InsertNewPiece(char column,int line,Piece p)
        {
            GameBoard.InsertPiece(p, new ChessPosition(column, line).ToPosition());
            Pieces.Add(p);
        }
        private void StartPieces()
        {
            InsertNewPiece('c', 1, new Tower(GameBoard, Color.White));
            InsertNewPiece('c', 2, new Tower(GameBoard, Color.White));
            InsertNewPiece('d', 2, new Tower(GameBoard, Color.White));
            InsertNewPiece('e', 2, new Tower(GameBoard, Color.White));
            InsertNewPiece('e', 1, new Tower(GameBoard, Color.White));
            InsertNewPiece('d', 1, new King(GameBoard, Color.White));

            InsertNewPiece('c', 7, new Tower(GameBoard, Color.Black));
            InsertNewPiece('c', 8, new Tower(GameBoard, Color.Black));
            InsertNewPiece('d', 7, new Tower(GameBoard, Color.Black));
            InsertNewPiece('e', 7, new Tower(GameBoard, Color.Black));
            InsertNewPiece('e', 8, new Tower(GameBoard, Color.Black));
            InsertNewPiece('d', 8, new King(GameBoard, Color.Black));
        }
    }
}
