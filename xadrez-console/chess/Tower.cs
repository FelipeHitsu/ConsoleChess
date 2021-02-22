using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Board b, Color color) : base(b, color)
        {

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
            while(_Board.isValid(position) && CanMove(position))
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
            position.SetValues(_Position.Line , _Position.Column + 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.Column = position.Column + 1;
            }

            //Left
            position.SetValues(_Position.Line , _Position.Column - 1);
            while (_Board.isValid(position) && CanMove(position))
            {
                matrix[position.Line, position.Column] = true;
                if (_Board.GetPiece(position) != null && _Board.GetPiece(position)._Color != _Color)
                    break;
                position.Column = position.Column - 1;
            }

            return matrix;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
