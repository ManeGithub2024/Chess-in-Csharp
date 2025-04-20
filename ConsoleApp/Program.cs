using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var board  = new Board();
        board.SetupDefaultPiecePositions();

        var printer = new BoardRender();
        printer.DrawBoard(board);

        Console.ReadKey();
    }
}