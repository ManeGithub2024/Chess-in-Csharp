using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class PieceSprite
    {
        const string WhitePawn = "\u265F";
        const string WhiteRook = "\u265C";
        const string WhiteKnight = "\u265E";
        const string WhiteBishop = "\u265D";
        const string WhiteQueen = "\u265B";
        const string WhiteKing = "\u265A";

        const string BlackPawn = "\u2659";
        const string BlackRook = "\u2656";
        const string BlackKnight = "\u2658";
        const string BlackBishop = "\u2657";
        const string BlackQueen = "\u2655";
        const string BlackKing = "\u2654";

        public Dictionary<(Type, Color), string> Sprite { get; private set; }

        public PieceSprite()
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
                {(typeof(Knight), Color.Black), BlackKnight},
                {(typeof(Bishop), Color.Black), BlackBishop},
                {(typeof(Queen), Color.Black), BlackQueen},
                {(typeof(King), Color.Black), BlackKing}
            };
        }
    }
}
