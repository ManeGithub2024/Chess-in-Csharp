namespace ChessLib
{
    public class Coordinates : IEquatable<Coordinates>
    {
        public File File { get; set; }
        public Rank Rank { get; set; }

        public Coordinates(File file, Rank rank)
        {
            File = file;
            Rank = rank;
        }

        public Coordinates Shift (CoordinatesShift shift) {
            var newFileShift = (int)this.File + (int)shift.FileShift;
            var newRankShift = (int)this.Rank + (int)shift.RankShift;

            return new Coordinates((File)newFileShift, (Rank)newRankShift);        
        }

        public bool CanShift(CoordinatesShift shift) {
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