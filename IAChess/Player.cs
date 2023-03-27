using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAChess
{
    public class Player
    {
        public ChessPiece[] Pieces { get; set; }

        public Player(bool isWhite)
        {
            Image pawnImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\pawnW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\pawnB.png");
            Image bishopImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\bishopW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\bishopB.png");
            Image elephantImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\elephantW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\elephantB.png");
            Image rookImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\rookW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\rookB.png");
            Image lanceImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\lanceW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\lanceB.png");
            Image knightImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\knightW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\knightB.png");
            Image silvergeneralImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\silvergeneralW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\silvergeneralB.png");
            Image goldgeneralImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\goldgeneralW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\goldgeneralB.png");
            Image kingImage = isWhite ? Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\kingW.png") : Image.FromFile("C:\\Users\\sergi\\OneDrive\\Documents\\IA\\IAChess\\IAChess\\images\\kingB.png");

            Pieces = new ChessPiece[21];

            for (int i = 0; i < 9; i++)
            {
                Pieces[i] = new Pawn(isWhite, isWhite ? 2 : 6, i, pawnImage, isWhite ? 1 : -1);
            }

            Pieces[9] = new Bishop(isWhite, isWhite ? 1 : 7, isWhite ? 7 : 1, bishopImage, isWhite ? 8 : -8);

            Pieces[10] = new Elephant(isWhite, isWhite ? 1 : 7, 4, elephantImage, isWhite ? 7 : -7);

            Pieces[11] = new Rook(isWhite, isWhite ? 1 : 7, isWhite ? 1 : 7, rookImage, isWhite ? 10 : -10);

            Pieces[12] = new Lance(isWhite, isWhite ? 0 : 8, 0, lanceImage, isWhite ? 3 : -3);
            Pieces[13] = new Lance(isWhite, isWhite ? 0 : 8, 8, lanceImage, isWhite ? 3 : -3);

            Pieces[14] = new Knight(isWhite, isWhite ? 0 : 8, 1, knightImage, isWhite ? 4 : -4);
            Pieces[15] = new Knight(isWhite, isWhite ? 0 : 8, 7, knightImage, isWhite ? 4 : -4);

            Pieces[16] = new Silver_General(isWhite, isWhite ? 0 : 8, 2, silvergeneralImage, isWhite ? 5 : -5);
            Pieces[17] = new Silver_General(isWhite, isWhite ? 0 : 8, 6, silvergeneralImage, isWhite ? 5 : -5);

            Pieces[18] = new Gold_General(isWhite, isWhite ? 0 : 8, 3, goldgeneralImage, isWhite ? 6 : -6);
            Pieces[19] = new Gold_General(isWhite, isWhite ? 0 : 8, 5, goldgeneralImage, isWhite ? 6 : -6);

            Pieces[20] = new King(isWhite, isWhite ? 0 : 8, 4, kingImage, isWhite ? 15 : -15);

        }

        public ChessPiece isOnBoard(int row, int column)
        {
            foreach (ChessPiece piece in this.Pieces)
            {
                if (piece.Row == row && piece.Column == column)
                {
                    return piece;
                }
            }
            return null;
        }

    }
}
