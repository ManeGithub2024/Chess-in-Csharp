
namespace ChessLib.Pieces
{
    public class Queen : Piece
    {
        public Queen(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            throw new NotImplementedException();
        }
    }
}
