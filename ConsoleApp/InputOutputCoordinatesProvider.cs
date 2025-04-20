using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class InputOutputCoordinatesProvider : IInputOutputCoordinatesProvider
    {
        public InputOutputCoordinatesProvider()
        {

        }

        private Coordinates ReadCoordinates()
        {
            while (true) {
                Console.WriteLine("Enter the coordinates of the piece to move. (a1)");
                var coordinate = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(coordinate) || !IsValidCoordinate(coordinate, out ChessLib.File? file, out ChessLib.Rank? rank)) {
                    continue;
                }

                return new Coordinates(file.Value, rank.Value);
            }
        }

        public Coordinates GetPickUpCoordinates(Color color, Board board)
        {
            while (true) {
                var coordinates = ReadCoordinates();

                if (board.IsCellEmpty(coordinates)) {
                    Console.WriteLine($"{coordinates} - is empty cell!");
                    continue;
                }

                var piece = board.GetPiece(coordinates);
                if (piece.Color != color) {
                    Console.WriteLine($"{color} are moving!");
                    continue;
                }

                // piece should be available to move
                var availableCells = piece.GetAvailableMoveCell(board);
                if (!availableCells.Any()) {
                    Console.WriteLine($"{piece.GetType().Name} is blocked!");
                    continue;
                }

                return coordinates;
            }
        }

        public Coordinates GetMoveCoordinates(HashSet<Coordinates> availableMoves)
        {
            while (true) {
                var coordinates = ReadCoordinates();
                if (!availableMoves.Contains(coordinates)) {
                    PresentAvailableMoves(availableMoves);
                    continue;
                }
                return coordinates;
            }
        }

        private bool IsValidCoordinate(string coordinate, out ChessLib.File? file, out ChessLib.Rank? rank)
        {
            file = new Nullable<ChessLib.File>();
            rank = new Nullable<ChessLib.Rank>();

            var word = coordinate.ToUpper();
            if (word.Length != 2) {
                return false;
            }
            var fileStr = word[0];
            var rankStr = word[1];

            if (!char.IsLetter(fileStr) || !char.IsNumber(rankStr)) {
                return false;
            }

            if (Enum.TryParse(typeof(ChessLib.File), fileStr.ToString(), out object? fileObj)) {
                file = (ChessLib.File)fileObj;

                var rankInt = int.Parse(rankStr.ToString());
                if (Enum.IsDefined(typeof(ChessLib.Rank), rankInt)) {
                    rank = (ChessLib.Rank)rankInt;

                    return true;
                }
            }

            return false;
        }

        private void PresentAvailableMoves(HashSet<Coordinates> availableMoves)
        {
            var coordinates = availableMoves.Select(c => c.ToString()).ToArray();
            var word = string.Join(", ", coordinates);
            Console.WriteLine($"Enter one of {word}");
        }
    }
}
