using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new Game(new Board(), new ConsoleGameUserInteraction());
        game.GameLoop();

        //var board = new BoardFactory().FromFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        //var boardRenderer = new ConsoleBoardRenderer();
        //boardRenderer.DrawBoard(board);


        Console.ReadKey();
    }
}