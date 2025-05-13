using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var defaultBoard = new Board();
        defaultBoard.SetupDefaultPiecePositions();

        var fenBoard = new BoardFactory().FromFen("8/8/2KB4/3Pb3/1r2k3/8/2R5/8 b - - 0 59");
        
        var game = new Game(fenBoard, new ConsoleGameUserInteraction());
        //var game = new Game(defaultBoard, new ConsoleGameUserInteraction());
        game.GameLoop();
        
        Console.ReadKey();
    }
}