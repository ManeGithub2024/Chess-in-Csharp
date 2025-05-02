using ChessLib.Pieces;

namespace ChessLib.Contracts
{
    public interface IPieceFactory<out R>
        where R : Piece
    {
        R CreatePiece<T>(Coordinates coordinates, Color color);
        Piece CreatePiece(Coordinates coordinates, char fenPiece);
    }
}
