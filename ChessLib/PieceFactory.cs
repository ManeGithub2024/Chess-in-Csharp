using ChessLib.Contracts;
using ChessLib.Pieces;

namespace ChessLib
{
    public class PieceFactory : IPieceFactory<Piece>
    {
        public Piece CreatePiece<T>(Coordinates coordinates, Color color)
        {
            var pieceType = typeof(T);
            switch (pieceType) {
                case Type pawnType when pawnType == typeof(Pawn):
                    return new Pawn(coordinates, color);
                case Type rookType when rookType == typeof(Rook):
                    return new Rook(coordinates, color);
                case Type knightType when knightType == typeof(Knight):
                    return new Knight(coordinates, color);
                case Type bishopType when bishopType == typeof(Bishop):
                    return new Bishop(coordinates, color);
                case Type queenType when queenType == typeof(Queen):
                    return new Queen(coordinates, color);
                case Type kingType when kingType == typeof(King):
                    return new King(coordinates, color);
                default:
                    throw new ArgumentException($"Unknown Piece type: {pieceType.Name}");
            }
        }

        public Piece CreatePiece(Coordinates coordinates, char fenPiece)
        {
            switch (fenPiece) {
                case 'p':
                    return CreatePiece<Pawn>(coordinates, Color.Black);
                case 'P':
                    return CreatePiece<Pawn>(coordinates, Color.White);
                case 'r':
                    return CreatePiece<Rook>(coordinates, Color.Black);
                case 'R':
                    return CreatePiece<Rook>(coordinates, Color.White);
                case 'n':
                    return CreatePiece<Knight>(coordinates, Color.Black);
                case 'N':
                    return CreatePiece<Knight>(coordinates, Color.White);
                case 'b':
                    return CreatePiece<Bishop>(coordinates, Color.Black);
                case 'B':
                    return CreatePiece<Bishop>(coordinates, Color.White);
                case 'q':
                    return CreatePiece<Queen>(coordinates, Color.Black);
                case 'Q':
                    return CreatePiece<Queen>(coordinates, Color.White);
                case 'k':
                    return CreatePiece<King>(coordinates, Color.Black);
                case 'K':
                    return CreatePiece<King>(coordinates, Color.White);
                default:
                    throw new ArgumentException($"Unknown Piece type: {fenPiece}");
            }
        }
    }
}
