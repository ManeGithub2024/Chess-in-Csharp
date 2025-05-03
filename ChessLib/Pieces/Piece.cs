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

        public IEnumerable<Coordinates> GetAvailableMoveCell(Board board)
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

        private bool IsCellAvailableForMove(Coordinates coordinates, Board board)
        {
            var isCellEmpty = board.IsCellEmpty(coordinates);
            if (isCellEmpty) {
                return true;
            }

            var piece = board.GetPiece(coordinates);
            var isEnemy = piece?.Color != this.Color;

            return isEnemy;
        }
    }
}
