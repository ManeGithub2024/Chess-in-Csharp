namespace ChessLib.Pieces
{
    public class Knight : Piece
    {
        public Knight(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            var result = new HashSet<CoordinatesShift>() {
                { new CoordinatesShift(1, 2) },
                { new CoordinatesShift(2, 1) },
                { new CoordinatesShift(2, -1) },
                { new CoordinatesShift(1, -2) },

                { new CoordinatesShift(-2, -1) },
                { new CoordinatesShift(-1, -2) },
                { new CoordinatesShift(-2, 1) },
                { new CoordinatesShift(-1, 2) },
            };

            return result;
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            return base.IsCellAvailableForMove(target, board);
        }
    }
}
