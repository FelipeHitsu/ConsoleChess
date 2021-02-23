using System;
using board;

namespace chess
{
    class Horse : Piece
    {
        public Horse(Board board,Color color) : base(board, color)
        {

        }

        private bool CanMove(Position p)
        {
            Piece piece = _Board.GetPiece(p);
            return piece == null || piece._Color != _Color;
        }

        public override string ToString()
        {
            return "H";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[_Board.Lines, _Board.Columns];
            Position position = new Position(0, 0);

            
            position.SetValues(_Position.Line - 1, _Position.Column - 2);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(_Position.Line - 2, _Position.Column - 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(_Position.Line - 2, _Position.Column + 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(_Position.Line - 1, _Position.Column + 2);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(_Position.Line + 1, _Position.Column + 2);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(_Position.Line + 2, _Position.Column + 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(_Position.Line + 2, _Position.Column - 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            position.SetValues(_Position.Line + 1, _Position.Column - 2);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            return matrix;
        }

    }
}
