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
        private readonly ICoordinaesProvider _provider;

        public bool IsWhiteTurn { get; private set; }

        public Game(Board board, IBoardRenderer renderer, ICoordinaesProvider provider)
        {
            _board = board;
            _renderer = renderer;
            _provider = provider;

            IsWhiteTurn = true;
        }

        public void GameLoop()
        {
            while (true) {
                // render
                _renderer.DrawBoard(_board);
                
                // input
                
                // make move
                
                // pass move
                IsWhiteTurn = false;
            }
        }
    }
}
