using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class ChessSprite
    {
        public const string WhitePawn = "\u265F";
        public const string WhiteRook = "\u265C";
        public const string WhiteKnight = "\u265E";
        public const string WhiteBishop = "\u265D";
        public const string WhiteQueen = "\u265B";
        public const string WhiteKing = "\u265A";

        public const string BlackPawn = "\u2659";
        public const string BlackRook = "\u2656";
        public const string BlackKnight = "\u2658";
        public const string BlackBishop = "\u2657";
        public const string BlackQueen = "\u2655";
        public const string BlackKing = "\u2654";

        public Dictionary<(Type, Color), string> Sprite { get; private set; }

        public ChessSprite()
        {
            Sprite = new Dictionary<(Type, Color), string>()
            {
                {(typeof(Pawn), Color.White), WhitePawn},
                {(typeof(Rook), Color.White), WhiteRook},
                {(typeof(Knight), Color.White), WhiteKnight},
                {(typeof(Bishop), Color.White), WhiteBishop},
                {(typeof(Queen), Color.White), WhiteQueen},
                {(typeof(King), Color.White), WhiteKing},
                {(typeof(Pawn), Color.Black), BlackPawn},
                {(typeof(Rook), Color.Black), BlackRook},
                {(typeof(Knight), Color.Black), BlackKing},
                {(typeof(Bishop), Color.Black), BlackBishop},
                {(typeof(Queen), Color.Black), BlackQueen},
                {(typeof(King), Color.Black), BlackKing}
            };
        }
    }
}
