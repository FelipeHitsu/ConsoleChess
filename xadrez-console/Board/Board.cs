using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines,columns];
        }

        public Piece GetPiece(int line,int column)
        {
            return Pieces[line, column];
        }

        public Piece GetPiece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public void InsertPiece(Piece p, Position pos)
        {
            if (hasPiece(pos))
                throw new BoardException("Ja existe uma peça nessa posição!");

            Pieces[pos.Line, pos.Column] = p;
            p._Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (GetPiece(pos) == null)
                return null;
            Piece aux = GetPiece(pos);
            aux._Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool isValid(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
                return false;
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!isValid(pos))
                throw new BoardException("Posição invalida!");
        }

        public bool hasPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }
    }
}
