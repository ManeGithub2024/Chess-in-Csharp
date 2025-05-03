using ChessLib;
using ChessLib.Contracts;

namespace ConsoleApp
{
    public class ConsoleGameUserInteraction : IGameUserInteraction
    {
        private readonly ConsoleBoardRenderer _consoleBoardRenderer;

        public ConsoleGameUserInteraction()
        {
            _consoleBoardRenderer = new ConsoleBoardRenderer();
        }

        public void DrawBoard(Board board) => _consoleBoardRenderer.DrawBoard(board);

        public void DrawBoard(Board board, IEnumerable<Coordinates> possibleMoves) => _consoleBoardRenderer.DrawBoard(board, possibleMoves);

        public Coordinates GetMoveCoordinates(IEnumerable<Coordinates> availableMoves)
        {
            while (true) {
                PrintAvailableMoves(availableMoves);
                var coordinates = ReadCoordinates();
                if (!availableMoves.Contains(coordinates)) {
                    continue;
                }
                return coordinates;
            }
        }

        public Coordinates ReadCoordinates()
        {
            while (true) {
                PrintValidationError("Enter the coordinates of the piece to move. (a1)");
                var coordinate = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(coordinate) || !IsValidCoordinate(coordinate)) {
                    continue;
                }

                return new Coordinates(coordinate[0], coordinate[1]);
            }
        }

        public void PrintValidationError(string msg)
        {
            Console.WriteLine(msg);
        }

        public void PrintInfo(string msg)
        {
            Console.WriteLine(msg);
        }


        private bool IsValidCoordinate(string coordinate)
        {
            var word = coordinate.ToUpper();
            if (word.Length != 2) {
                return false;
            }
            var fileChr = word[0];
            var rankChr = word[1];

            if (CoordinatesUtil.IsValidFile(fileChr) && CoordinatesUtil.IsValidRank(rankChr)) {
                return true;
            }

            return false;
        }

        private void PrintAvailableMoves(IEnumerable<Coordinates> availableMoves)
        {
            var availableCoordinates = availableMoves.Select(c => c.ToString()).ToArray();
            var availableCoordinatesStr = string.Join(", ", availableCoordinates);
            PrintInfo($"Enter one of {availableCoordinatesStr}");
        }
    }
}
