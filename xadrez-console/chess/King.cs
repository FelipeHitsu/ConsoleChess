using board;
namespace chess
{
    class King : Piece
    {
        private ChessGame Game;
        public King(Board b, Color color, ChessGame game) : base(b, color)
        {
            Game = game;
        }

        private bool CanMove(Position p)
        {
            Piece piece = _Board.GetPiece(p);
            return piece == null || piece._Color != _Color;
        }
        private bool TowerCanCastle(Position position)
        {
            Piece p = _Board.GetPiece(position);
            return p != null && p is Tower && p._Color == _Color && p.MovesAmount == 0;
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

            //Castle
            /*if(MovesAmount == 0 && !Game.InCheck)
            {
                //Short
                Position T1 = new Position(position.Line, position.Column + 3);
                if (TowerCanCastle(T1))
                {
                    Position position1 = new Position(position.Line, position.Column + 1);
                    Position position2 = new Position(position.Line, position.Column + 2);

                    if(_Board.GetPiece(position1)==null && _Board.GetPiece(position2) == null)
                    {
                        matrix[position.Line, position.Column + 2] = true;
                    }
                }
                //Long
                Position T2 = new Position(position.Line, position.Column - 4);
                if (TowerCanCastle(T2))
                {
                    Position position1 = new Position(position.Line, position.Column - 1);
                    Position position2 = new Position(position.Line, position.Column - 2);
                    Position position3 = new Position(position.Line, position.Column - 3);


                    if (_Board.GetPiece(position1) == null && _Board.GetPiece(position2) == null && _Board.GetPiece(position3) == null)
                    {
                        matrix[position.Line, position.Column - 2] = true;
                    }
                }
            }*/


            return matrix;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
