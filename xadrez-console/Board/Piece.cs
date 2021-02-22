namespace board
{
    class Piece
    {
        public Position _Position { get; set; }
        public Color _Color { get; protected set; }
        public int MovesAmount { get; protected set; }
        public Board _Board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            _Position = position;
            _Color = color;
            _Board = board;
            MovesAmount = 0;
        }
    }
}
