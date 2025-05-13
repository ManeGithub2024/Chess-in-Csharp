
namespace ChessLib.Pieces
{
    public abstract class Piece
    {
        public Color Color { get; private set; }
        public Coordinates Coordinates { get; set; }

        protected Piece(Coordinates coordinates, Color color)
        {
            Color = color;
            Coordinates = coordinates;
        }

        protected abstract HashSet<CoordinatesShift> GetPieceShift();

        public IEnumerable<Coordinates> GetAvailableMoveCells(Board board)
        {
            var result = new HashSet<Coordinates>();
            var shifts = GetPieceShift();
            foreach (var shift in shifts) {
                if (Coordinates.CanShift(shift)) {
                    var newCoordinates = Coordinates.Shift(shift);

                    if (IsCellAvailableForMove(newCoordinates, board)) {
                        result.Add(newCoordinates);
                    }
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name}";
        }

        protected HashSet<CoordinatesShift> GetPieceShiftByDiagonale()
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

        protected HashSet<CoordinatesShift> GetPieceShiftByVerticalAndHorizontal()
        {
            HashSet<CoordinatesShift> result = new HashSet<CoordinatesShift>();

            // left to right
            for (int i = -8; i <= 8; i++) {
                if (i == 0) {
                    continue;
                }
                result.Add(new CoordinatesShift(i, 0));
            }

            // bottom to top
            for (int i = -8; i <= 8; i++) {
                if (i == 0) {
                    continue;
                }
                result.Add(new CoordinatesShift(0, i));
            }

            return result;
        }

        protected virtual bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            return IsCellAvailable(target, board);
        }

        protected bool IsCellAvailableForMoveByDiagonale(Coordinates target, Board board)
        {
            var result = IsCellAvailable(target, board);
            if (result) {
                var coordinates = BoardAssistant.GetDiagonalCoordinatesBetween(this.Coordinates, target);
                foreach (var item in coordinates) {
                    if (!board.IsCellEmpty(item)) {
                        return target.Equals(item) && IsEnemy(item, board);
                    }
                }
            }

            return result;
        }

        protected bool IsCellAvailableForMoveByVerticalAndHorizontal(Coordinates target, Board board)
        {
            var result = IsCellAvailable(target, board);
            if (result) {
                IEnumerable<Coordinates> coordinates = new List<Coordinates>();

                if (this.Coordinates.File.Equals(target.File)) {
                    coordinates = BoardAssistant.GetVerticalCoordinatesBetween(this.Coordinates, target);
                } else if (this.Coordinates.Rank.Equals(target.Rank)) {
                    coordinates = BoardAssistant.GetHorizontalCoordinatesBetween(this.Coordinates, target);
                }

                foreach (var item in coordinates) {
                    if (!board.IsCellEmpty(item)) {
                        return target.Equals(item) && IsEnemy(item, board);
                    }
                }
            }

            return result;
        }

        private bool IsCellAvailable(Coordinates target, Board board)
        {
            var isCellEmpty = board.IsCellEmpty(target);
            if (isCellEmpty) {
                return true;
            }

            return IsEnemy(target, board);
        }

        protected bool IsEnemy(Coordinates target, Board board)
        {
            var piece = board.GetPiece(target);
            var isEnemy = piece?.Color != this.Color;

            return isEnemy;
        }
    }
}
