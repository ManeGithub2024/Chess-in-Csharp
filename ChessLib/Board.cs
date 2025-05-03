using ChessLib.Contracts;
using ChessLib.Pieces;

namespace ChessLib
{
    public class Board
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        private readonly IPieceFactory<Piece> _pieceFactory;
        private readonly Dictionary<Coordinates, Piece> _pieces;

        public Board()
        {
            _pieces = new Dictionary<Coordinates, Piece>();
            _pieceFactory = new PieceFactory();

            Height = Enum.GetValues(typeof(Rank)).Length;
            Width = Enum.GetValues(typeof(File)).Length;
        }

        public Piece GetPiece(Coordinates coordinates)
        {
            var _= _pieces.TryGetValue(coordinates, out var piece);
            return piece;
        }

        public Piece GetPiece(int file, int rank)
        {
            var _ = _pieces.TryGetValue(new Coordinates(file, rank), out var piece);
            return piece;
        }

        public bool IsHighLighted(int file, int rank, IEnumerable<Coordinates> possibleMoves)
        {            
            var isHighLighted = possibleMoves.Any(x=> x.Equals(new Coordinates(file, rank)));
            return isHighLighted;
        }

        public void SetPiece(Coordinates coordinates, Piece piece)
        {
            piece.Coordinates = coordinates;
            _pieces.Add(coordinates, piece);
        }

        public void RemovePiece(Coordinates coordinates)
        {
            _pieces.Remove(coordinates);
        }

        public void MovePiece(Coordinates from, Coordinates to)
        {
            var piece = _pieces[from];
            RemovePiece(from);
            SetPiece(to, piece);
        }

        public bool IsCellEmpty(Coordinates coordinates)
        {
            return !this._pieces.ContainsKey(coordinates);
        }

        public void SetupDefaultPiecePositions()
        {
            SetupPawn<Pawn>(Color.White, Rank.Rank2);
            SetupPawn<Pawn>(Color.Black, Rank.Rank7);

            Setup<Rook>(new Coordinates(File.A, Rank.Rank1), Color.White);
            Setup<Rook>(new Coordinates(File.H, Rank.Rank1), Color.White);
            Setup<Rook>(new Coordinates(File.A, Rank.Rank8), Color.Black);
            Setup<Rook>(new Coordinates(File.H, Rank.Rank8), Color.Black);

            Setup<Knight>(new Coordinates(File.B, Rank.Rank1), Color.White);
            Setup<Knight>(new Coordinates(File.G, Rank.Rank1), Color.White);
            Setup<Knight>(new Coordinates(File.B, Rank.Rank8), Color.Black);
            Setup<Knight>(new Coordinates(File.G, Rank.Rank8), Color.Black);

            Setup<Bishop>(new Coordinates(File.C, Rank.Rank1), Color.White);
            Setup<Bishop>(new Coordinates(File.F, Rank.Rank1), Color.White);
            Setup<Bishop>(new Coordinates(File.C, Rank.Rank8), Color.Black);
            Setup<Bishop>(new Coordinates(File.F, Rank.Rank8), Color.Black);

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
