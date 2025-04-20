using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var pickUpCoordinates = _provider.GetPickUpCoordinates(color, _board);

                var piece = _board.GetPiece(pickUpCoordinates);  
                
                var availableMoves = piece.GetAvailableMoveCell(_board);
                var moveCoordinates = _provider.GetMoveCoordinates(availableMoves);

                _board.MovePiece(pickUpCoordinates, moveCoordinates);

                _renderer.DrawBoard(_board);
                
                IsWhiteTurn = !IsWhiteTurn;
            }
        }
    }
}
