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
        public bool InCheck { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessGame()
        {
            GameBoard = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            InCheck = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            StartPieces();
        }

        public Piece ExecuteMove(Position origin, Position destination)
        {
            Piece p = GameBoard.RemovePiece(origin);
            p.IncreaseMoveCount();
            Piece capturedPiece = GameBoard.RemovePiece(destination);
            GameBoard.InsertPiece(p, destination);
            if (capturedPiece != null)
                CapturedPieces.Add(capturedPiece);

            /*//Special move short castle
            if(p is King && destination.Column == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column + 3);
                Position towerDestination = new Position(origin.Line, origin.Column + 1);

                Piece tower = GameBoard.RemovePiece(towerOrigin);
                tower.IncreaseMoveCount();
                GameBoard.InsertPiece(tower, towerDestination);
            }
            //Special move long castle
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column - 4);
                Position towerDestination = new Position(origin.Line, origin.Column - 1);

                Piece tower = GameBoard.RemovePiece(towerOrigin);
                tower.IncreaseMoveCount();
                GameBoard.InsertPiece(tower, towerDestination);
            }*/

            return capturedPiece;
        }
        public void UndoMove(Position origin, Position destination, Piece captured)
        {
            Piece p = GameBoard.RemovePiece(destination);
            p.DecreaseMoveCount();
            if (captured != null)
            {
                GameBoard.InsertPiece(captured, destination);
                CapturedPieces.Remove(captured);
            }
            GameBoard.InsertPiece(p, origin);

            //Special move short castle
            if (p is King && destination.Column == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column + 3);
                Position towerDestination = new Position(origin.Line, origin.Column + 1);

                Piece tower = GameBoard.RemovePiece(towerDestination);
                tower.DecreaseMoveCount();
                GameBoard.InsertPiece(tower, towerOrigin);
            }
            //Special move long castle
            if (p is King && destination.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column - 4);
                Position towerDestination = new Position(origin.Line, origin.Column - 1);

                Piece tower = GameBoard.RemovePiece(towerDestination);
                tower.IncreaseMoveCount();
                GameBoard.InsertPiece(tower, towerOrigin);
            }

        }
        public void MakeMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMove(origin, destination);
            if (IsInCheck(ActualPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("Can't do this move: you will be in check");
            }
            if (IsInCheck(Opponent(ActualPlayer)))
                InCheck = true;
            else
                InCheck = false;
            if (IsInCheckMate(Opponent(ActualPlayer)))
                Finished = true;
            else
            {
                NextPlayer();
                Turn++;
            }
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
        public void ValidateDestination(Position origin, Position destination)
        {
            if (!GameBoard.GetPiece(origin).PossibleMove(destination))
                throw new BoardException("Invalid Destination Position");
        }
        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in CapturedPieces)
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
        private Color Opponent(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }
        private Piece GetKing(Color color)
        {
            foreach (Piece p in GetInGamePieces(color))
            {
                if (p is King)
                    return p;
            }
            return null;
        }
        public bool IsInCheck(Color color)
        {
            Piece K = GetKing(color);
            if (K == null)
                throw new BoardException("Fatal error, no king of " + color + " pieces on board");

            foreach (Piece p in GetInGamePieces(Opponent(color)))
            {
                bool[,] matrix = p.PossibleMoves();
                if (matrix[K._Position.Line, K._Position.Column])
                    return true;
            }
            return false;
        }
        public void InsertNewPiece(char column, int line, Piece p)
        {
            GameBoard.InsertPiece(p, new ChessPosition(column, line).ToPosition());
            Pieces.Add(p);
        }
        public bool IsInCheckMate(Color color)
        {
            if (!IsInCheck(color))
                return false;
            foreach (Piece p in GetInGamePieces(color))
            {
                bool[,] matrix = p.PossibleMoves();
                for (int i = 0; i < GameBoard.Lines; i++)
                {
                    for (int j = 0; j < GameBoard.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = p._Position;
                            Position dest = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, dest);
                            bool check = IsInCheck(color);
                            UndoMove(origin, dest, capturedPiece);
                            if (!check)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        private void StartPieces()
        {
            InsertNewPiece('a',1, new Tower(GameBoard, Color.White));
            InsertNewPiece('b',1, new Horse(GameBoard, Color.White));
            InsertNewPiece('c',1, new Bishop(GameBoard, Color.White));
            InsertNewPiece('d',1, new Queen(GameBoard, Color.White));
            InsertNewPiece('e',1, new King(GameBoard, Color.White,this));
            InsertNewPiece('f',1, new Bishop(GameBoard, Color.White));
            InsertNewPiece('g',1, new Horse(GameBoard, Color.White));
            InsertNewPiece('h',1, new Tower(GameBoard, Color.White));
            InsertNewPiece('a',2, new Pawn(GameBoard, Color.White));
            InsertNewPiece('b', 2, new Pawn(GameBoard, Color.White));
            InsertNewPiece('c', 2, new Pawn(GameBoard, Color.White));
            InsertNewPiece('d', 2, new Pawn(GameBoard, Color.White));
            InsertNewPiece('e', 2, new Pawn(GameBoard, Color.White));
            InsertNewPiece('f', 2, new Pawn(GameBoard, Color.White));
            InsertNewPiece('g', 2, new Pawn(GameBoard, Color.White));
            InsertNewPiece('h', 2, new Pawn(GameBoard, Color.White));

            InsertNewPiece('a', 8, new Tower(GameBoard, Color.Black));
            InsertNewPiece('b', 8, new Horse(GameBoard, Color.Black));
            InsertNewPiece('c', 8, new Bishop(GameBoard, Color.Black));
            InsertNewPiece('d', 8, new Queen(GameBoard, Color.Black));
            InsertNewPiece('e', 8, new King(GameBoard, Color.Black,this));
            InsertNewPiece('f', 8, new Bishop(GameBoard, Color.Black));
            InsertNewPiece('g', 8, new Horse(GameBoard, Color.Black));
            InsertNewPiece('h', 8, new Tower(GameBoard, Color.Black));
            InsertNewPiece('a', 7, new Pawn(GameBoard, Color.Black));
            InsertNewPiece('b', 7, new Pawn(GameBoard, Color.Black));
            InsertNewPiece('c', 7, new Pawn(GameBoard, Color.Black));
            InsertNewPiece('d', 7, new Pawn(GameBoard, Color.Black));
            InsertNewPiece('e', 7, new Pawn(GameBoard, Color.Black));
            InsertNewPiece('f', 7, new Pawn(GameBoard, Color.Black));
            InsertNewPiece('g', 7, new Pawn(GameBoard, Color.Black));
            InsertNewPiece('h', 7, new Pawn(GameBoard, Color.Black));

        }
    }
}
