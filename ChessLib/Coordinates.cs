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
    }
}