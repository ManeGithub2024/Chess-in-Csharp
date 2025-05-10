namespace ChessLib.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            // bottom-left to top-right
            for (int i = -8; i <= 8; i++) {
                if (i == 0) {
                    continue;
                }
                result.Add(new CoordinatesShift(i, i));
            }

            // top-left to bottom-right
            for (int i = -8; i <= 8; i++) {
                if (i == 0) {
                    continue;
                }
                result.Add(new CoordinatesShift(i, -i));
            }

            return result;
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            var result = base.IsCellAvailableForMove(target, board);
            if (result) {
                var coordinates = BoardAssistant.GetDiagonalCoordinatesBetween(this.Coordinates, target);
                foreach (var item in coordinates) {
                    if (!board.IsCellEmpty(item))
                    {
                        return target.Equals(item) && IsEnemy(item, board);
                    }
                }
            }

            return result;
        }
    }
}
