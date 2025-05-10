using ChessLib.Contracts;
using System.Collections.Generic;

namespace ChessLib
{
    public class Game
    {
        private readonly Board _board;
        private readonly IGameUserInteraction _provider;

        public bool IsWhiteTurn { get; private set; }

        public Game(Board board, IGameUserInteraction provider)
        {
            _board = board;
            _provider = provider;

            IsWhiteTurn = true;
        }

        public void GameLoop()
        {
            // _board.SetupDefaultPiecePositions();

            while (true) {
                _provider.DrawBoard(_board);

                var color = IsWhiteTurn ? Color.White : Color.Black;

                _provider.PrintInfo($"{color} are moving!");

                var from = GetPickUpCoordinates(color, _board);

                var piece = _board.GetPiece(from);

                var possibleMoves = piece.GetAvailableMoveCells(_board);
                if (possibleMoves.Any()) {
                    _provider.DrawBoard(_board, possibleMoves);
                }

                var to = _provider.GetMoveCoordinates(possibleMoves);

                if (!_board.IsCellEmpty(to)) {
                    var victimPiece = _board.GetPiece(to);
                    _provider.PrintInfo($"{victimPiece} {to} is under attack!");
                    _board.RemovePiece(to);
                }

                _board.MovePiece(from, to);

                IsWhiteTurn = !IsWhiteTurn;
            }
        }

        private Coordinates GetPickUpCoordinates(Color color, Board board)
        {
            while (true) {
                var coordinates = _provider.ReadCoordinates();

                if (board.IsCellEmpty(coordinates)) {
                    _provider.PrintValidationError($"{coordinates} - is empty cell!");
                    continue;
                }

                var piece = board.GetPiece(coordinates);
                if (piece.Color != color) {
                    _provider.PrintValidationError($"{color} are moving!");
                    continue;
                }

                // piece should be available to move
                var availableCells = piece.GetAvailableMoveCells(board);
                if (!availableCells.Any()) {
                    _provider.PrintValidationError($"{piece.GetType().Name} is blocked!");
                    continue;
                }

                return coordinates;
            }
        }
    }
}
