using System;
using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board,Color color) : base(board, color) { }
        public override string ToString()
        {
            return "P";
        }
        private bool HaveEnemie(Position pos)
        {
            Piece p = _Board.GetPiece(pos);
            return p != null && p._Color != _Color;
        }
        private bool Empty(Position pos)
        {
            return _Board.GetPiece(pos) == null;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[_Board.Lines, _Board.Columns];
            
            Position position = new Position(0, 0);

            if(_Color == Color.White)
            {
                position.SetValues(_Position.Line - 1, _Position.Column);
                if (_Board.isValid(position) && Empty(position))
                    matrix[position.Line, position.Column] = true;

                position.SetValues(_Position.Line - 2, _Position.Column);
                if (_Board.isValid(position) && Empty(position) && MovesAmount == 0)
                    matrix[position.Line, position.Column] = true;

                position.SetValues(_Position.Line - 1, _Position.Column + 1);
                if (_Board.isValid(position) && HaveEnemie(position))
                    matrix[position.Line, position.Column] = true;

                position.SetValues(_Position.Line - 1, _Position.Column - 1);
                if (_Board.isValid(position) && HaveEnemie(position))
                    matrix[position.Line, position.Column] = true;

            }
            else
            {
                position.SetValues(_Position.Line + 1, _Position.Column);
                if (_Board.isValid(position) && Empty(position))
                    matrix[position.Line, position.Column] = true;

                position.SetValues(_Position.Line + 2, _Position.Column);
                if (_Board.isValid(position) && Empty(position) && MovesAmount == 0)
                    matrix[position.Line, position.Column] = true;

                position.SetValues(_Position.Line + 1, _Position.Column + 1);
                if (_Board.isValid(position) && HaveEnemie(position))
                    matrix[position.Line, position.Column] = true;

                position.SetValues(_Position.Line + 1, _Position.Column - 1);
                if (_Board.isValid(position) && HaveEnemie(position))
                    matrix[position.Line, position.Column] = true;
            }
            return matrix;
        }



    }
}
