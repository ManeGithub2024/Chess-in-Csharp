
using ChessLib.Pieces;

namespace ChessLib
{
    public interface IInputOutputCoordinatesProvider
    {
        Coordinates GetPickUpCoordinates(Color color, Board board);
        Coordinates GetMoveCoordinates(HashSet<Coordinates> availableMoves);
    }
}