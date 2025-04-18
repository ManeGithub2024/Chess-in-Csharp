using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var board  = new Board();
        board.SetupDefaultPiecePositions();
        var printer = new PrintBoard();
        printer.Print(board);

        Console.ReadKey();
    }
}