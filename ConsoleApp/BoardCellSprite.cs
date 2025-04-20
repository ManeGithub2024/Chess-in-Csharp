using ChessLib;
using ChessLib.Pieces;

namespace ConsoleApp
{
    internal class BoardCellSprite
    {
        // To return to the default color
        public const string ResetColor = "\u001B[0m";

        // ANSI escape codes for background text colors
        const string WhiteBackground = "\u001B[47m";
        const string BlackBackground = "\u001B[40m";

        // ANSI escape codes for text colors
        public const string BlackText = "\u001B[30m";
        public const string WhiteText = "\u001B[37m";
        public const string GrayText = "\u001B[90m";

        public Dictionary<ConsoleColor, string> BackgroundColors { get; private set; }
        public Dictionary<ConsoleColor, string> FontColors { get; private set; }

        public BoardCellSprite()
        {
            BackgroundColors = new Dictionary<ConsoleColor, string> {                
                { ConsoleColor.White, WhiteBackground},
                { ConsoleColor.Black, BlackBackground},
                { ConsoleColor.ResetColor, ResetColor}
            };

            FontColors = new Dictionary<ConsoleColor, string> {
                { ConsoleColor.ResetColor, ResetColor},
                { ConsoleColor.White, WhiteText},
                { ConsoleColor.Black, BlackText},
                { ConsoleColor.Gray, BlackText}
            };
        }
    }
}
