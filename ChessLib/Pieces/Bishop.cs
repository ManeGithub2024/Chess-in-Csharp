namespace ChessLib.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            return base.GetPieceShiftByDiagonale();
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            return IsCellAvailableForMoveByDiagonale(target, board);
        }
    }
}
