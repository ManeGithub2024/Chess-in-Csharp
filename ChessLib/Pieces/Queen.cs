namespace ChessLib.Pieces
{
    public class Queen : Piece
    {
        public Queen(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            var verticalAndHorizontal = GetPieceShiftByVerticalAndHorizontal();
            var diagonale = GetPieceShiftByDiagonale();
            verticalAndHorizontal.UnionWith(diagonale);

            return verticalAndHorizontal;
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            IEnumerable<Coordinates> coordinates = new List<Coordinates>();

            if (this.Coordinates.File == target.File) {
                coordinates = BoardAssistant.GetVerticalCoordinatesBetween(this.Coordinates, target);
            } else if (this.Coordinates.Rank == target.Rank) {
                coordinates = BoardAssistant.GetHorizontalCoordinatesBetween(this.Coordinates, target);
            } else {
                coordinates = BoardAssistant.GetDiagonalCoordinatesBetween(this.Coordinates, target);
            }

            foreach (var item in coordinates) {
                if (!board.IsCellEmpty(item)) {
                    var result = target.Equals(item) && IsEnemy(item, board);
                    return result;
                }
            }

            return true;
        }
    }
}
