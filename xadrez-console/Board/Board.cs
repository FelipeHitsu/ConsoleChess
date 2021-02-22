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

        public void InsertPiece(Piece p, Position pos)
        {
            Pieces[pos.Line, pos.Column] = p;
            p._Position = pos;
        }
    }
}
