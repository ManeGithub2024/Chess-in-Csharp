using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var board = new BoardFactory().FromFen("3kq1n1/p4p2/4b3/8/R5P1/2B2N2/1P6/3KQ3 w - - 0 1");
        var game = new Game(board, new ConsoleGameUserInteraction());
        game.GameLoop();

        //var board = new BoardFactory().FromFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        //var boardRenderer = new ConsoleBoardRenderer();
        //boardRenderer.DrawBoard(board);


        Console.ReadKey();
    }
}