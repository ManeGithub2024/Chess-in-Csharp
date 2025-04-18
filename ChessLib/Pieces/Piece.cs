namespace ChessLib.Pieces
{
    public abstract class Piece
    {
        protected Piece(Coordinates coordinates, Color color)
        {
            Color = color;
            Coordinates = coordinates;
        }

        public Color Color { get; private set; }
        public Coordinates Coordinates { get; set; }
    }
}
