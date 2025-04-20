using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class BoardRender
    {
        private readonly PieceSprite _chessSprite;
        private readonly BoardCellSprite _boardCellSprite;

        public BoardRender()
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
        /// Apply cell color depend on piece
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
                cellColor = _boardCellSprite.FontColors[ConsoleColor.White] + _boardCellSprite.BackgroundColors[ConsoleColor.Black] + symbol + _boardCellSprite.BackgroundColors[ConsoleColor.ResetColor];
            } else {
                if (piece?.Color == Color.White) {
                    cellColor = _boardCellSprite.FontColors[ConsoleColor.Black] + _boardCellSprite.BackgroundColors[ConsoleColor.White] + symbol + _boardCellSprite.BackgroundColors[ConsoleColor.ResetColor];
                } else {
                    cellColor = _boardCellSprite.FontColors[ConsoleColor.Gray] + _boardCellSprite.BackgroundColors[ConsoleColor.White] + symbol + _boardCellSprite.BackgroundColors[ConsoleColor.ResetColor];
                }
            }
            //cellColor += "|";

            return cellColor;
        }
    }
}
