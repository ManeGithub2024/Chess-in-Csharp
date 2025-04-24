namespace ChessLib
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public Rank Rank { get; set; }
        public File File { get; set; }

        internal Coordinates(File file, Rank rank)
        {
            File = file;
            Rank = rank;
        }

        public Coordinates(int file, int rank)
        {
            File = (File)file;
            Rank = (Rank)rank;
        }

        public Coordinates(char file, char rank)
        {
            File = (File)Enum.Parse(typeof(File),file.ToString().ToUpper());
            Rank = (Rank)Enum.Parse(typeof(Rank), rank.ToString().ToUpper()); ;
        }

        public Coordinates Shift(CoordinatesShift shift)
        {
            var newFileShift = (int)this.File + shift.FileShift;
            var newRankShift = (int)this.Rank + shift.RankShift;

            return new Coordinates(newFileShift, newRankShift);
        }

        public bool CanShift(CoordinatesShift shift)
        {
            var newFileShift = (int)this.File + (int)shift.FileShift;
            var newRankShift = (int)this.Rank + (int)shift.RankShift;

            if (WithinBorderBoundaries(newFileShift) && WithinBorderBoundaries(newRankShift)) {
                return true;
            }

            return false;

            bool WithinBorderBoundaries(int shift)
            {
                if (shift < 1 || shift > 8) {
                    return false;
                }

                return true;
            }
        }

        public override int GetHashCode()
        {
            // Using a multiplier of 31 is standard practice for better hash code distribution.
            var hashCode = File.GetHashCode() * 31 + Rank.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Coordinates;
            return Equals(other);
        }

        public bool Equals(Coordinates other)
        {
            if (other == null) {
                return false;
            }

            if (ReferenceEquals(this, other)) {
                return true;
            }

            return this.File.Equals(other.File) && this.Rank.Equals(other.Rank);
        }

        public override string ToString()
        {
            return $"{File}{(int)Rank}";
        }
    }
}