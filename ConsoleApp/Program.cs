using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var board  = new Board();
        board.SetupDefaultPiecePositions();

        var printer = new BoardRenderer();
        printer.DrawBoard(board);

        var knight = board.GetPiece(new Coordinates(ChessLib.File.B, Rank.Rank1));
        var moves = knight.GetAvailableMoveCell(board);

        var provider = new InputOutputCoordinatesProvider();
        var cc = provider.GetPickUpCoordinates(Color.White, board);


        Console.ReadKey();
    }
}