using ChessLib;
using ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new Game(new Board(), new ConsoleGameUserInteraction());
        game.GameLoop();

        Console.ReadKey();
    }
}