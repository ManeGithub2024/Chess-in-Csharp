using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class BoardAssistant
    {
        public BoardAssistant()
        {

        }

        /// <summary>
        /// The cells are on the same diagonal
        /// </summary>
        /// <param name="src"></param>
        /// <param name="trg"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinates> GetDiagonalCoordinatesBetween(Coordinates src, Coordinates trg)
        {
            var result = new List<Coordinates>();

            int fileShift = src.File < trg.File ? 1 : -1;
            int rankShift = src.Rank < trg.Rank ? 1 : -1;

            for (int fileIx = (int)src.File + fileShift, rankIx = (int)src.Rank + rankShift;
                fileIx != (int)trg.File && rankIx != (int)trg.Rank;
                fileIx += fileShift, rankIx += rankShift) {

                result.Add(new Coordinates((File)fileIx, (Rank)rankIx));
            }
            result.Add(trg);

            return result;
        }

        /// <summary>
        /// The cells are arranged in one straight line.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="trg"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinates> GetVerticalCoordinatesBetween(Coordinates src, Coordinates trg)
        {
            var result = new List<Coordinates>();
            
            int rankShift = src.Rank < trg.Rank ? 1 : -1;

            for (int rankIx = (int)src.Rank + rankShift; 
                rankIx > 0 && rankIx < 9 && 
                rankIx != (int)trg.Rank; 
                rankIx += rankShift) {

                result.Add(new Coordinates(src.File, (Rank)rankIx));
            }
            result.Add(trg);

            return result;
        }

        /// <summary>
        /// The cells are arranged in one straight line.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="trg"></param>
        /// <returns></returns>
        public static IEnumerable<Coordinates> GetHorizontalCoordinatesBetween(Coordinates src, Coordinates trg)
        {
            var result = new List<Coordinates>();

            int fileShift = src.File < trg.File ? 1 : -1;

            for (int fileIx = (int)src.File + fileShift; 
                fileIx > 0 && fileIx < 9 && 
                fileIx != (int)trg.File; fileIx += fileShift) {

                result.Add(new Coordinates((File)fileIx, src.Rank));
            }
            result.Add(trg);

            return result;
        }
    }
}
