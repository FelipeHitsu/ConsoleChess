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
    }
}
