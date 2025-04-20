namespace ConsoleApp
{
    internal class BoardCellSprite
    {
        // To return to the default color
        public const string ResetColor = "\u001B[0m";

        // ANSI escape codes for background text colors
        const string WhiteBackground = "\u001B[47m";
        const string BlackBackground = "\u001B[0;100m";
        const string SelectedBackground = "\u001B[45m";

        // ANSI escape codes for text colors
        public const string BlackText = "\u001B[34m";
        public const string WhiteText = "\u001B[97m";
        public const string GrayText = "\u001B[90m";

        public Dictionary<ConsoleColor, string> BackgroundColors { get; private set; }
        public Dictionary<ConsoleColor, string> FontColors { get; private set; }

        public BoardCellSprite()
        {
            BackgroundColors = new Dictionary<ConsoleColor, string> {
                { ConsoleColor.ResetColor, ResetColor},
                { ConsoleColor.White, WhiteBackground},
                { ConsoleColor.Black, BlackBackground},
                { ConsoleColor.Gray, BlackText}                
            };

            FontColors = new Dictionary<ConsoleColor, string> {
                { ConsoleColor.ResetColor, ResetColor},
                { ConsoleColor.White, WhiteText},
                { ConsoleColor.Black, BlackText},
                { ConsoleColor.Gray, GrayText}
            };
        }
    }
}
