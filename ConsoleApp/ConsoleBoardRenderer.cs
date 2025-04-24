using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class ConsoleBoardRenderer
    {
        private readonly PieceSprite _chessSprite;
        private readonly BoardCellSprite _boardCellSprite;

        public ConsoleBoardRenderer()
        {
            _chessSprite = new PieceSprite();
            _boardCellSprite = new BoardCellSprite();
        }

        public void DrawBoard(Board board)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for (int rank = board.Height; rank > 0; rank--) {
                Console.Write($" {rank}|");
                for (int file = 1; file <= board.Width; file++) {
                    var piece = board.GetPiece(file, rank);
                    var square = GetCellSprite(file, rank, piece);
                    Console.Write(square);
                }
                Console.WriteLine();
            }
            Console.WriteLine("    A  B  C  D  E  F  G  H");
        }

        // Apply cell color and cell content depend on piece
        private string GetCellSprite(int file, int rank, Piece piece)
        {
            var isCellBlack = IsCellBlack(file,rank);
            string symbol = "   ";
            if (piece != null) {
                var sprite = _chessSprite.Sprite[(piece.GetType(), piece.Color)];
                symbol = $" {sprite} ";
            }

            var background = _boardCellSprite.BackgroundColors[ConsoleColor.White];

            if (isCellBlack) {
                background = _boardCellSprite.BackgroundColors[ConsoleColor.Black];
            }
            if (piece?.Color == Color.Black) {
                symbol = _boardCellSprite.FontColors[ConsoleColor.Black] + symbol;
            }

            var cellColor = background + symbol + _boardCellSprite.BackgroundColors[ConsoleColor.ResetColor];

            return cellColor;
        }

        // odd/even = black/white
        private bool IsCellBlack(int file, int rank) => (file + rank) % 2 == 0;
    }
}
