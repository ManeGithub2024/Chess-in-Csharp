namespace ChessLib.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            throw new NotImplementedException();
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
