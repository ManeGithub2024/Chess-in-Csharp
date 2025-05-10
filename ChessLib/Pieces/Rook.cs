namespace ChessLib.Pieces
{
    public class Rook : Piece
    {
        public Rook(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            return base.GetPieceShiftByVerticalAndHorizontal();
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            return base.IsCellAvailableForMoveByVerticalAndHorizontal(target, board);
        }
    }
}
