using ChessLib.Contracts;

namespace ChessLib
{
    public class Game
    {
        private readonly Board _board;
        private readonly IBoardRenderer _renderer;
        private readonly IInputOutputCoordinatesProvider _provider;

        public bool IsWhiteTurn { get; private set; }

        public Game(Board board, IBoardRenderer renderer, IInputOutputCoordinatesProvider provider)
        {
            _board = board;
            _renderer = renderer;
            _provider = provider;

            IsWhiteTurn = true;
        }

        public void GameLoop()
        {
            while (true) {
                _renderer.DrawBoard(_board);

                var color = IsWhiteTurn ? Color.White : Color.Black;
                var from = _provider.GetPickUpCoordinates(color, _board);

                var piece = _board.GetPiece(from);

                var possibleMoves = piece.GetAvailableMoveCell(_board);
                var to = _provider.GetMoveCoordinates(possibleMoves);

                _board.MovePiece(from, to);

                IsWhiteTurn = !IsWhiteTurn;
            }
        }
    }
}
