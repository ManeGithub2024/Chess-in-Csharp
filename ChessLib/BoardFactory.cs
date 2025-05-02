using ChessLib.Contracts;
using ChessLib.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class BoardFactory
    {
        private readonly IPieceFactory<Piece> _pieceFactory;

        public BoardFactory() {
            _pieceFactory = new PieceFactory();
        }
        
        /// <summary>
        /// FEN (Forsyth–Edwards Notation) рядок — це стандартний текстовий формат для опису конкретної позиції шахової гри.
        /// </summary>
        /// <param name="fen">rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1</param>
        /// <returns></returns>
        public Board FromFen(string fen) {

            var board = new Board();

            string[] parts = fen.Split(' ');
            string piecePosition = parts[0];
            
            string[] fenRows = piecePosition.Split("/");

            for (int i = 0; i < fenRows.Length; i++) {
                string row = fenRows[i];
                int rank = 8 - i;

                int fileIndex = 1;
                for (int j = 0; j < row.Length; j++) { 
                    char fenChr = row[j];
                    if (char.IsNumber(fenChr)) {
                        fileIndex += int.Parse(fenChr.ToString());
                    } else {
                        var coordinates = new Coordinates(fileIndex, rank);
                        var piece = _pieceFactory.CreatePiece(coordinates, fenChr);
                        board.SetPiece(coordinates, piece);
                        
                        fileIndex++;
                    }                
                }
            }
            
            return board;
        }
    }
}
