using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class PrintBoard
    {
        private readonly ChessSprite _chessSprite;
        public PrintBoard()
        {
            _chessSprite = new ChessSprite();
        }
        public void Print(Board board)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var files = (ChessLib.File[])Enum.GetValues(typeof(ChessLib.File));
            var i = 1;
            foreach (var rank in (ChessLib.Rank[])Enum.GetValues(typeof(ChessLib.Rank))) {
                Console.Write($"{i++} ");
                foreach (var file in files) {
                    var coordinates = new Coordinates(file, rank);
                    var busy = board.Pieces.TryGetValue(coordinates, out var piece);
                    if (busy) {
                        var sprite = GetSprite(piece);
                        Console.Write($" {sprite} ");
                    } else {
                        Console.Write($"  ");
                    }
                }
                Console.WriteLine();
            }

            PrintBottom(files);
        }

        private string GetSprite(Piece piece)
        {
            return _chessSprite.Sprite[(piece.GetType(), piece.Color)];
        }

        private void PrintBottom(ChessLib.File[] files) {
            var filesPrint = "  ";
            foreach (var item in files) {
                filesPrint += $" {item} ";
            }
            Console.WriteLine(filesPrint);

        }
    }
}
