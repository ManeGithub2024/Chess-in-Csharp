namespace ChessLib.Contracts
{
    public interface IGameUserInteraction
    {
        Coordinates GetMoveCoordinates(HashSet<Coordinates> availableMoves);
        Coordinates ReadCoordinates();
        void PrintValidationError(string msg);
        void PrintInfo(string msg);
        void DrawBoard(Board board);
    }
}