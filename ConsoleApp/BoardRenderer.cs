using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class BoardRenderer
    {
        private readonly PieceSprite _chessSprite;
        private readonly BoardCellSprite _boardCellSprite;

        public BoardRenderer()
        {
            _chessSprite = new PieceSprite();
            _boardCellSprite = new BoardCellSprite();
        }

        public void DrawBoard(Board board)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Console.WriteLine("  +---+---+---+---+---+---+---+---+");

            var files = (ChessLib.File[])Enum.GetValues(typeof(ChessLib.File));
            var rankLength = Enum.GetValues(typeof(Rank)).Length;

            for (int i = rankLength; i > 0; i--) {
                Console.Write($" {i}|");
                foreach (var file in files) {
                    var coordinates = new Coordinates(file, (Rank)i);
                    var _ = board.Pieces.TryGetValue(coordinates, out var piece);
                    var square = GetCellSprite(IsBlack(coordinates), piece);
                    Console.Write(square);
                }
                Console.WriteLine();
                // Console.WriteLine("  +---+---+---+---+---+---+---+---+");
            }

            // Console.WriteLine("    A   B   C   D   E   F   G   H");
            Console.WriteLine("    A  B  C  D  E  F  G  H");
        }

        // odd/even = black/white
        private bool IsBlack(Coordinates coordinates)
        {
            var parity = ((int)coordinates.File + (int)coordinates.Rank) % 2;
            return parity == 0;
        }

        /// <summary>
        /// Apply cell color and cell content depend on piece
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="isCellBlack"></param>
        /// <returns></returns>
        private string GetCellSprite(bool isCellBlack, Piece piece)
        {
            string symbol = "   ";
            if (piece != null) {
                var sprite = _chessSprite.Sprite[(piece.GetType(), piece.Color)];
                symbol = $" {sprite} ";
            }

            string cellColor;
            if (isCellBlack) {
                if (piece != null) {
                    if (piece.Color == Color.Black) {
                        cellColor = _boardCellSprite.BackgroundColors[ConsoleColor.Black] + _boardCellSprite.FontColors[ConsoleColor.Black] + symbol;
                    } else {
                        cellColor = _boardCellSprite.BackgroundColors[ConsoleColor.Black] + _boardCellSprite.FontColors[ConsoleColor.White] + symbol;
                    }
                } else {
                    cellColor = _boardCellSprite.BackgroundColors[ConsoleColor.Black] + symbol;
                }
            } else {
                if (piece != null) {
                    if (piece.Color == Color.Black) {
                        cellColor = _boardCellSprite.BackgroundColors[ConsoleColor.Gray] + _boardCellSprite.FontColors[ConsoleColor.Black] + symbol;
                    } else {
                        cellColor = _boardCellSprite.BackgroundColors[ConsoleColor.Gray] + _boardCellSprite.FontColors[ConsoleColor.White] + symbol;
                    }
                } else {
                    cellColor = _boardCellSprite.BackgroundColors[ConsoleColor.Gray] + symbol;
                }
            }

            return cellColor + _boardCellSprite.BackgroundColors[ConsoleColor.ResetColor];
        }
    }
}
