using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class PieceSprite
    {
        // White figures
        public const string WhiteKing = "\u265A";   // ♔
        public const string WhiteQueen = "\u265B";  // ♕
        public const string WhiteRook = "\u265C";   // ♖
        public const string WhiteBishop = "\u265D"; // ♗
        public const string WhiteKnight = "\u265E"; // ♘
        public const string WhitePawn = "\u2659";   // ♟

        // Black figures
        public const string BlackKing = "\u2654";   // ♚
        public const string BlackQueen = "\u2655";  // ♛
        public const string BlackRook = "\u2656";   // ♜
        public const string BlackBishop = "\u2657"; // ♝
        public const string BlackKnight = "\u2658"; // ♞
        public const string BlackPawn = "\u265F";   // ♟

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

                //{(typeof(Pawn), Color.Black), BlackPawn},
                //{(typeof(Rook), Color.Black), BlackRook},
                //{(typeof(Knight), Color.Black), BlackKnight},
                //{(typeof(Bishop), Color.Black), BlackBishop},
                //{(typeof(Queen), Color.Black), BlackQueen},
                //{(typeof(King), Color.Black), BlackKing},

                //{(typeof(Pawn), Color.White), WhitePawn},
                //{(typeof(Rook), Color.White), WhiteRook},
                //{(typeof(Knight), Color.White), WhiteKnight},
                //{(typeof(Bishop), Color.White), WhiteBishop},
                //{(typeof(Queen), Color.White), WhiteQueen},
                //{(typeof(King), Color.White), WhiteKing}
                
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
