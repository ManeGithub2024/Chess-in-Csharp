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

        public Game(Board board, IBoardRenderer renderer)
        {
            _board = board;
            _renderer = renderer;
        }

        public void GameLoop()
        {
            while (true) {
                // render
                // input
                // make move
                // pass move
            }
        }
    }
}
