using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class PieceSprite
    {
        // Figures Unicode sprite
        public const string King = "\u265A";   // ♔
        public const string Queen = "\u265B";  // ♕
        public const string Rook = "\u265C";   // ♖
        public const string Bishop = "\u265D"; // ♗
        public const string Knight = "\u265E"; // ♘
        public const string Pawn = "\u2659";   // ♟

        public Dictionary<(Type, Color), string> Sprite { get; private set; }

        public PieceSprite()
        {
            Sprite = new Dictionary<(Type, Color), string>()
            {                
                {(typeof(Pawn), Color.Black), Pawn},
                {(typeof(Rook), Color.Black), Rook},
                {(typeof(Knight), Color.Black), Knight},
                {(typeof(Bishop), Color.Black), Bishop},
                {(typeof(Queen), Color.Black), Queen},
                {(typeof(King), Color.Black), King},

                {(typeof(Pawn), Color.White), Pawn},
                {(typeof(Rook), Color.White), Rook},
                {(typeof(Knight), Color.White), Knight},
                {(typeof(Bishop), Color.White), Bishop},
                {(typeof(Queen), Color.White), Queen},
                {(typeof(King), Color.White), King}
            };
        }
    }
}
