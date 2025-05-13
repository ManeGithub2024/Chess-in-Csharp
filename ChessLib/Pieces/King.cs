namespace ChessLib.Pieces
{
    public class King : Piece
    {
        public King(Coordinates coordinates, Color color) : base(coordinates, color)
        {

        }

        protected override HashSet<CoordinatesShift> GetPieceShift()
        {
            var result = new HashSet<CoordinatesShift>() {
                { new CoordinatesShift(-1, 0) },
                { new CoordinatesShift(1, 0) },
                { new CoordinatesShift(-1, 1) },
                { new CoordinatesShift(1, 1) },
                { new CoordinatesShift(0, 1) },

                { new CoordinatesShift(-1, -1) },
                { new CoordinatesShift(1, -1) },
                { new CoordinatesShift(0, -1) },
            };

            return result;
        }

        protected override bool IsCellAvailableForMove(Coordinates target, Board board)
        {
            // the cell under attack is forbidden
            var available = base.IsCellAvailableForMove(target, board);
            if (available) {
                var enemies = board.GetEnemies(this.Color);
                var enemyKing = enemies.Where(p => p.GetType() == typeof(King)).First();

                int distance = ChebyshevDistance(target, enemyKing.Coordinates);
                if (distance > 1) {
                    var isTargetUnderAttack = BoardAssistant.IsTargetUnderAttack(this.Color, target, board); 
                        available = isTargetUnderAttack ? false : true;
                }

                if (distance == 1) {
                    // enemyKing is blocking the target cell
                    available = false;
                }
            }

            return available;
        }

        /// <summary>
        /// The Chebyshev distance reflects the minimum number of moves the king can make.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private static int ChebyshevDistance(Coordinates p1, Coordinates p2)
        {
            return Math.Max(Math.Abs(p1.File - p2.File), Math.Abs(p1.Rank - p2.Rank));
        }

        public static double EuclideanDistance(Coordinates p1, Coordinates p2)
        {
            var deltaFile = (int)p1.File - (int)p2.File;
            var deltaRank = (int)p1.Rank - (int)p2.Rank;
            return Math.Sqrt(deltaFile * deltaFile + deltaRank * deltaRank);
        }
    }
}
