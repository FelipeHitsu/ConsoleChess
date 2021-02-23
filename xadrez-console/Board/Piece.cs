namespace board
{
    abstract class Piece
    {
        public Position _Position { get; set; }
        public Color _Color { get; protected set; }
        public int MovesAmount { get; protected set; }
        public Board _Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            _Position = null;
            _Color = color;
            _Board = board;
            MovesAmount = 0;
        }
        public abstract bool[,] PossibleMoves();
        public void IncreaseMoveCount()
        {
            MovesAmount ++;
        }

        public bool CanMove()
        {
            bool[,] matrix = PossibleMoves();
            for(int i = 0; i < _Board.Lines; i++)
            {
                for(int j = 0; j < _Board.Columns; j++)
                {
                    if (matrix[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool CanMoveTo(Position p)
        {
            return PossibleMoves()[p.Line, p.Column];
        }
    }
}
