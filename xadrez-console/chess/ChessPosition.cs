using board;
namespace chess
{
    class ChessPosition
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public ChessPosition(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }
        public Position toPosition()
        {
            return new Position(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return ""+Coluna+Linha;
        }
    }
}
