using board;
namespace chess
{
    class King : Piece
    {
        public King(Board b, Color color) : base(b, color)
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
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            //Right above
            position.SetValues(_Position.Line - 1, _Position.Column + 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            //Right
            position.SetValues(_Position.Line, _Position.Column + 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            //Right down
            position.SetValues(_Position.Line + 1, _Position.Column + 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            //Down
            position.SetValues(_Position.Line + 1, _Position.Column);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            //Left Down
            position.SetValues(_Position.Line + 1, _Position.Column - 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            //Left
            position.SetValues(_Position.Line, _Position.Column - 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            //Left Above
            position.SetValues(_Position.Line - 1, _Position.Column - 1);
            if (_Board.isValid(position) && CanMove(position))
                matrix[position.Line, position.Column] = true;

            return matrix;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
