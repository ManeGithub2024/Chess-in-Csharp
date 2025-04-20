namespace ChessLib
{
    public class CoordinatesShift
    {
        public int FileShift { get; private set; }
        public int RankShift { get; private set; }

        public CoordinatesShift(int file, int rank)
        {
            FileShift = file;
            RankShift = rank;
        }
    }
}
