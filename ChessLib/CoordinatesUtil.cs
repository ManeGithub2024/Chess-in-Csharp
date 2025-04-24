namespace ChessLib
{
    public static class CoordinatesUtil
    {
        public static bool IsValidFile(char fileChr) 
        {
            if (!char.IsLetter(fileChr)) {
                return false;
            }

            var result = Enum.TryParse(typeof(File), fileChr.ToString(), out object _);
            return result;        
        }

        public static bool IsValidRank(char rankChr)
        {
            if (!char.IsNumber(rankChr)) {
                return false;
            }

            var result = Enum.TryParse(typeof(Rank), rankChr.ToString(), out object _);
            return result;
        }
    }
}