using ChessLib.Pieces;

namespace ChessLib
{
    public interface IPieceFactory<out R>
        where R : Piece
    {
        R CreatePiece<T>(Coordinates coordinates, Color color);
    }
}
