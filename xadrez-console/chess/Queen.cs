using System;
using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString()
        {
            return "Q";
        }
        private bool CanMove(Position p)
        {
            Piece piece = _Board.GetPiece(p);
            return piece == null || piece._Color != _Color;
        }
        public override bool[,] PossibleMoves()
        {

            bool[,] matrix = new bool[_Board.Lines, _Board.Columns];
            Position position = new Position(0, 0);

            //Above
            position.SetValues(_Position.Line - 1, _Position.Column);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                {
                    break;

                }
                position.Line = position.Line - 1;
            }

            //Down
            position.SetValues(_Position.Line + 1, _Position.Column);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.Line = position.Line + 1;
            }

            //Right
            position.SetValues(_Position.Line, _Position.Column + 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.Column = position.Column + 1;
            }

            //Left
            position.SetValues(_Position.Line, _Position.Column - 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.Column = position.Column - 1;
            }

            //Above Left
            position.SetValues(_Position.Line - 1, _Position.Column - 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                {
                    break;

                }
                position.SetValues(position.Line - 1, position.Column - 1);
            }

            //Above Right
            position.SetValues(_Position.Line - 1, _Position.Column + 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.SetValues(_Position.Line - 1, _Position.Column + 1);
            }

            //Down Right
            position.SetValues(_Position.Line + 1, _Position.Column + 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.SetValues(_Position.Line + 1, _Position.Column + 1);
            }

            //Down Left
            position.SetValues(_Position.Line + 1, _Position.Column - 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.SetValues(_Position.Line + 1, _Position.Column - 1);
            }

            return matrix;
        }
    }
}
