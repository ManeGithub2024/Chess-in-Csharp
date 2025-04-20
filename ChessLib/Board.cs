using ChessLib.Pieces;

namespace ChessLib
{
    public class Board
    {
        private readonly IPieceFactory<Piece> _pieceFactory = new PieceFactory();
        public Dictionary<Coordinates, Piece> Pieces { get; private set; }
        

        public Board()
        {
            Pieces = new Dictionary<Coordinates, Piece>();
        }

        public void SetPiece(Coordinates coordinates, Piece piece)
        {
            piece.Coordinates = coordinates;
            Pieces.Add(coordinates, piece);
        }

        public void SetupDefaultPiecePositions()
        {
            // setup pawn
            SetupPawn<Pawn>(Color.White, Rank.Rank2);
            SetupPawn<Pawn>(Color.Black, Rank.Rank7);

        }

        private void SetupPawn<T>(Color color, Rank rank)
            where T : Piece
        {
            var allFileValues = (File[])Enum.GetValues(typeof(File));
            foreach (File file in allFileValues) {
                var coordinates = new Coordinates(file, rank);
                var piece = _pieceFactory.CreatePiece<T>(coordinates, color);
                SetPiece(coordinates, piece);
            }
        }
    }
}
