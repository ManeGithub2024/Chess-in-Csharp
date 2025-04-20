
namespace ChessLib.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            throw new NotImplementedException();
        }
    }
}
