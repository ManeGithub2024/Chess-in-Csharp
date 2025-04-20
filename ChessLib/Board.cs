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
            SetupPawn<Pawn>(Color.White, Rank.Rank2);
            SetupPawn<Pawn>(Color.Black, Rank.Rank7);

            Setup<Rook>(new Coordinates(File.A, Rank.Rank1), Color.White);
            Setup<Rook>(new Coordinates(File.H, Rank.Rank1), Color.White);
            Setup<Rook>(new Coordinates(File.A, Rank.Rank8), Color.Black);
            Setup<Rook>(new Coordinates(File.H, Rank.Rank8), Color.Black);

            Setup<Bishop>(new Coordinates(File.B, Rank.Rank1), Color.White);
            Setup<Bishop>(new Coordinates(File.G, Rank.Rank1), Color.White);
            Setup<Bishop>(new Coordinates(File.B, Rank.Rank8), Color.Black);
            Setup<Bishop>(new Coordinates(File.G, Rank.Rank8), Color.Black);

            Setup<Knight>(new Coordinates(File.C, Rank.Rank1), Color.White);
            Setup<Knight>(new Coordinates(File.F, Rank.Rank1), Color.White);
            Setup<Knight>(new Coordinates(File.C, Rank.Rank8), Color.Black);
            Setup<Knight>(new Coordinates(File.F, Rank.Rank8), Color.Black);

            Setup<Queen>(new Coordinates(File.D, Rank.Rank1), Color.White);
            Setup<King>(new Coordinates(File.E, Rank.Rank1), Color.White);
            Setup<Queen>(new Coordinates(File.D, Rank.Rank8), Color.Black);
            Setup<King>(new Coordinates(File.E, Rank.Rank8), Color.Black);
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

        private void Setup<T>(Coordinates coordinates, Color color)
            where T : Piece
        {
            var piece = _pieceFactory.CreatePiece<T>(coordinates, color);
            SetPiece(coordinates, piece);
        }
    }
}
