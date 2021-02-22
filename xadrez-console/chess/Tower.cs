using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Board b, Color color) : base(b, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
