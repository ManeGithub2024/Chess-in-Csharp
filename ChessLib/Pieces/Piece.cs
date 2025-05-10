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

        protected virtual bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            var isCellEmpty = board.IsCellEmpty(target);
            if (isCellEmpty) {
                return true;
            }

            return IsEnemy(target, board);
        }

        protected bool IsEnemy(Coordinates target, Board board) {
            var piece = board.GetPiece(target);
            var isEnemy = piece?.Color != this.Color;

            return isEnemy;
        }
    }
}
