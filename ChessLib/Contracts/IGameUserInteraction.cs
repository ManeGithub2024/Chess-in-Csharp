namespace ChessLib.Contracts
{
    public interface IGameUserInteraction
    {
        Coordinates GetMoveCoordinates(IEnumerable<Coordinates> possibleMoves);
        Coordinates ReadCoordinates();
        void PrintValidationError(string msg);
        void PrintInfo(string msg);
        void DrawBoard(Board board, IEnumerable<Coordinates> possibleMoves);
        void DrawBoard(Board board);
    }
}