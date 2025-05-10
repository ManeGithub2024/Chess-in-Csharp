using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var board = new BoardFactory().FromFen("rnbqkb1r/pp3ppp/2ppp2n/8/1P3B2/N2P4/P1P1PPPP/R2QKBNR w KQkq - 0 1");
        var game = new Game(board, new ConsoleGameUserInteraction());
        game.GameLoop();

        //var board = new BoardFactory().FromFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        //var boardRenderer = new ConsoleBoardRenderer();
        //boardRenderer.DrawBoard(board);


        Console.ReadKey();
    }
}