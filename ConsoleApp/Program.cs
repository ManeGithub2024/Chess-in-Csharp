using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var board = new Board();
        board.SetupDefaultPiecePositions();

        var game = new Game(board, new BoardRenderer(), new InputOutputCoordinatesProvider());
        game.GameLoop();

        Console.ReadKey();
    }
}