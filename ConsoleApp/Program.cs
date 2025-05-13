using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var board = new BoardFactory().FromFen("8/8/3k3b/1p6/4K3/R7/8/4Q3 w - - 0 1");
        var game = new Game(board, new ConsoleGameUserInteraction());
        game.GameLoop();

        //var board = new BoardFactory().FromFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        //var boardRenderer = new ConsoleBoardRenderer();
        //boardRenderer.DrawBoard(board);


        Console.ReadKey();
    }
}