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
    }
}
