using System.Reflection.Metadata.Ecma335;

namespace ChessLib.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            var shifts = new HashSet<CoordinatesShift>();
            if (this.Color == Color.White) {
                shifts.Add(new CoordinatesShift(0, 1)); // 1 cell up                
                if (this.Coordinates.Rank == Rank.Rank2) {
                    shifts.Add(new CoordinatesShift(0, 2)); // 2 celss up
                }

                // for attack
                shifts.Add(new CoordinatesShift(-1, 1));
                shifts.Add(new CoordinatesShift(1, 1));
            }

            if (this.Color == Color.Black) {
                shifts.Add(new CoordinatesShift(0, -1)); // 1 cell down
                if (this.Coordinates.Rank == Rank.Rank7) {
                    shifts.Add(new CoordinatesShift(0, -2)); // 2 cells down
                }

                // for attack
                shifts.Add(new CoordinatesShift(-1, -1));
                shifts.Add(new CoordinatesShift(1, -1));
            }

            return shifts;
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            if (this.Coordinates.File != target.File && board.IsCellEmpty(target)) {
                return false;
            }

            if (this.Coordinates.File == target.File && !board.IsCellEmpty(target)) {
                return false;
            }

            return base.IsCellAvailableForMove(target, board);
        }
    }
}
