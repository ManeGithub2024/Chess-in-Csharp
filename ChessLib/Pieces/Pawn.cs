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
    }
}
