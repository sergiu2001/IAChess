using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAChess
{
    public abstract class ChessPiece
    {
        public bool IsWhite { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public Image Image { get; set; }
        public int Value { get; set; }

        public ChessPiece(bool isWhite, int row, int column, Image image, int value)
        {
            IsWhite = isWhite;
            Row = row;
            Column = column;
            Image = image;
            Value = value;
        }

        public abstract void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos);
        public abstract ChessPiece Promote(bool white, int row, int col);

    }

    public class King : ChessPiece
    {
        public King(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }
            pos[toRow, toColumn] = 0;



        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Elephant : ChessPiece
    {
        public Elephant(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                }

                if (IsWhite)
                {
                    if (toRow - 1 >= 0)
                    {
                        pos[toRow - 1, toColumn] = 0;
                    }
                }
                else
                {
                    if (toRow + 1 <= 8)
                    {
                        pos[toRow + 1, toColumn] = 0;
                    }
                }

                pos[toRow, toColumn] = 0;
            }
        }

        public bool CanPromote()
        {
            if (IsWhite)
            {
                return Row >= 5;
            }
            else
            {
                return Row <= 3;
            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            if (CanPromote())
            {
                return new Prince(white, row, col, white ? Image.FromFile("images\\princeW.png") : Image.FromFile("images\\princeB.png"), white ? 14 : -14);
            }
            return null;
        }
    }

    public class Prince : ChessPiece
    {
        public Prince(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }

                        else
                        {
                            pos[i, j] = 0;
                        }
                    }
                }

                pos[toRow, toColumn] = 0;

            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Gold_General : ChessPiece
    {
        public Gold_General(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                        else
                        {
                            pos[i, j] = 0;
                        }
                    }
                }

                if (IsWhite)
                {
                    if (toRow - 1 >= 0 && toColumn - 1 >= 0)
                    {
                        pos[toRow - 1, toColumn - 1] = 0;
                    }

                    if (toRow - 1 >= 0 && toColumn + 1 <= 8)
                    {
                        pos[toRow - 1, toColumn + 1] = 0;
                    }
                }
                else
                {
                    if (toRow + 1 <= 8 && toColumn - 1 >= 0)
                    {
                        pos[toRow + 1, toColumn - 1] = 0;
                    }

                    if (toRow + 1 <= 8 && toColumn + 1 <= 8)
                    {
                        pos[toRow + 1, toColumn + 1] = 0;
                    }
                }

                pos[toRow, toColumn] = 0;

            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Silver_General : ChessPiece
    {
        public Silver_General(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) == 1 && Math.Abs(j - toColumn) == 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }

            if (IsWhite)
            {
                if (toRow + 1 <= 8)
                {
                    pos[toRow + 1, toColumn] = (tablePos[toRow + 1, toColumn] > 0) ? 0 : 1;
                }
            }
            else
            {
                if (toRow - 1 >= 0)
                {
                    pos[toRow - 1, toColumn] = (tablePos[toRow - 1, toColumn] < 0) ? 0 : 1;
                }
            }

            if (toColumn - 1 >= 0)
            {
                pos[toRow, toColumn - 1] = 0;
            }

            if (toColumn + 1 <= 8)
            {
                pos[toRow, toColumn + 1] = 0;
            }
            pos[toRow, toColumn] = 0;

        }

        public bool CanPromote()
        {
            if (IsWhite)
            {
                return Row >= 5;
            }
            else
            {
                return Row <= 3;
            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            if (CanPromote())
            {
                return new Gold_General(white, row, col, white ? Image.FromFile("images\\goldgeneralW.png") : Image.FromFile("images\\goldgeneralB.png"), white ? 6 : -6);
            }
            return null;
        }
    }

    public class Whole : ChessPiece
    {
        public Whole(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }

            if (IsWhite)
            {
                if (toRow - 1 >= 0 && toColumn - 1 >= 0)
                {
                    pos[toRow - 1, toColumn - 1] = 0;
                }

                if (toRow - 1 >= 0 && toColumn + 1 <= 8)
                {
                    pos[toRow - 1, toColumn + 1] = 0;
                }
            }
            else
            {
                if (toRow + 1 <= 8 && toColumn - 1 >= 0)
                {
                    pos[toRow + 1, toColumn - 1] = 0;
                }

                if (toRow + 1 <= 8 && toColumn + 1 <= 8)
                {
                    pos[toRow + 1, toColumn + 1] = 0;
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Rook : ChessPiece
    {
        public Rook(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            bool Up = true, Right = true, Down = true, Left = true;
            if (toRow - 1 >= 0)
            {
                for (int i = toRow - 1; i >= 0 && Up; i--)
                {
                    if (IsWhite)
                    {
                        if (tablePos[i, toColumn] != 0)
                        {
                            pos[i, toColumn] = (tablePos[i, toColumn] > 0) ? 0 : -1;
                            Up = false;
                        }
                    }
                    else
                    {
                        if (tablePos[i, toColumn] != 0)
                        {
                            pos[i, toColumn] = (tablePos[i, toColumn] < 0) ? 0 : -1;
                            Up = false;
                        }
                    }
                    if (tablePos[i, toColumn] == 0)
                    {
                        pos[i, toColumn] = 1;
                    }
                }
            }
            if (toColumn + 1 < 9)
            {
                for (int i = toColumn + 1; i < 9 && Right; i++)
                {
                    if (IsWhite)
                    {
                        if (tablePos[toRow, i] != 0)
                        {
                            pos[toRow, i] = (tablePos[toRow, i] > 0) ? 0 : -1;
                            Right = false;
                        }
                    }
                    else
                    {
                        if (tablePos[toRow, i] != 0)
                        {
                            pos[toRow, i] = (tablePos[toRow, i] < 0) ? 0 : -1;
                            Right = false;
                        }
                    }
                    if (tablePos[toRow, i] == 0)
                    {
                        pos[toRow, i] = 1;
                    }
                }
            }
            if (toRow + 1 < 9)
            {
                for (int i = toRow + 1; i < 9 && Down; i++)
                {
                    if (IsWhite)
                    {
                        if (tablePos[i, toColumn] != 0)
                        {
                            pos[i, toColumn] = (tablePos[i, toColumn] > 0) ? 0 : -1;
                            Down = false;
                        }
                    }
                    else
                    {
                        if (tablePos[i, toColumn] != 0)
                        {
                            pos[i, toColumn] = (tablePos[i, toColumn] < 0) ? 0 : -1;
                            Down = false;
                        }
                    }
                    if (tablePos[i, toColumn] == 0)
                    {
                        pos[i, toColumn] = 1;
                    }
                }
            }
            if (toColumn - 1 >= 0)
            {
                for (int i = toColumn - 1; i >= 0 && Left; i--)
                {
                    if (IsWhite)
                    {
                        if (tablePos[toRow, i] != 0)
                        {
                            pos[toRow, i] = (tablePos[toRow, i] > 0) ? 0 : -1;
                            Left = false;
                        }
                    }
                    else
                    {
                        if (tablePos[toRow, i] != 0)
                        {
                            pos[toRow, i] = (tablePos[toRow, i] < 0) ? 0 : -1;
                            Left = false;
                        }
                    }
                    if (tablePos[toRow, i] == 0)
                    {
                        pos[toRow, i] = 1;
                    }
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public bool CanPromote()
        {
            if (IsWhite)
            {
                return Row >= 5;
            }
            else
            {
                return Row <= 3;
            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            if (CanPromote())
            {
                return new Dragon(white, row, col, white ? Image.FromFile("images\\dragonW.png") : Image.FromFile("images\\dragonB.png"), white ? 12 : -12);
            }
            return null;
        }
    }

    public class Dragon : ChessPiece
    {
        public Dragon(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((i == toRow || j == toColumn) && (Math.Abs(i - toRow) == 1 && Math.Abs(j - toColumn) == 1))
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Lance : ChessPiece
    {
        public Lance(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            bool Fwd = true;
            if (toRow - 1 >= 0 && !IsWhite)
            {
                for (int i = toRow - 1; i >= 0 && Fwd; i--)
                {
                    if (tablePos[i, toColumn] != 0)
                    {
                        pos[i, toColumn] = (tablePos[i, toColumn] < 0) ? 0 : -1;
                        Fwd = false;
                    }
                    if (tablePos[i, toColumn] == 0)
                    {
                        pos[i, toColumn] = 1;
                    }
                }
            }
            if (toRow + 1 < 9 && IsWhite)
            {
                for (int i = toRow + 1; i < 9 && Fwd; i++)
                {
                    if (tablePos[i, toColumn] != 0)
                    {
                        pos[i, toColumn] = (tablePos[i, toColumn] > 0) ? 0 : -1;
                        Fwd = false;
                    }
                    if (tablePos[i, toColumn] == 0)
                    {
                        pos[i, toColumn] = 1;
                    }
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public bool CanPromote()
        {
            if (IsWhite)
            {
                return Row >= 5;
            }
            else
            {
                return Row <= 3;
            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            if (CanPromote())
            {
                return new Apricot(white, row, col, white ? Image.FromFile("images\\apricotW.png") : Image.FromFile("images\\apricotB.png"), white ? 6 : -6);
            }
            return null;
        }
    }

    public class Apricot : ChessPiece
    {
        public Apricot(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }

            if (IsWhite)
            {
                if (toRow - 1 >= 0 && toColumn - 1 >= 0)
                {
                    pos[toRow - 1, toColumn - 1] = 0;
                }

                if (toRow - 1 >= 0 && toColumn + 1 <= 8)
                {
                    pos[toRow - 1, toColumn + 1] = 0;
                }
            }
            else
            {
                if (toRow + 1 <= 8 && toColumn - 1 >= 0)
                {
                    pos[toRow + 1, toColumn - 1] = 0;
                }

                if (toRow + 1 <= 8 && toColumn + 1 <= 8)
                {
                    pos[toRow + 1, toColumn + 1] = 0;
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Knight : ChessPiece
    {
        public Knight(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    pos[i, j] = 0;
                }
            }
            int wPos1 = toRow + 2, bPos1 = toRow - 2, wbPos1 = toColumn - 1, wbPos2 = toColumn + 1;

            if (IsWhite)
            {
                if (wPos1 <= 8 && wbPos1 >= 0)
                {
                    pos[wPos1, wbPos1] = (tablePos[wPos1, wbPos1] > 0) ? 0 : (tablePos[wPos1, wbPos1] < 0) ? -1 : 1;
                }
                if (wPos1 <= 8 && wbPos2 <= 8)
                {
                    pos[wPos1, wbPos2] = (tablePos[wPos1, wbPos2] > 0) ? 0 : (tablePos[wPos1, wbPos2] < 0) ? -1 : 1;
                }
            }
            else
            {
                if (bPos1 >= 0 && wbPos1 >= 0)
                {
                    pos[bPos1, wbPos1] = (tablePos[bPos1, wbPos1] < 0) ? 0 : (tablePos[bPos1, wbPos2] > 0) ? -1 : 1;
                }
                if (bPos1 >= 0 && wbPos2 <= 8)
                {
                    pos[bPos1, wbPos2] = (tablePos[bPos1, wbPos2] < 0) ? 0 : (tablePos[bPos1, wbPos2] > 0) ? -1 : 1;
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public bool CanPromote()
        {
            if (IsWhite)
            {
                return Row >= 5;
            }
            else
            {
                return Row <= 3;
            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            if (CanPromote())
            {
                return new Scepter(white, row, col, white ? Image.FromFile("images\\scepterW.png") : Image.FromFile("images\\scepterB.png"), white ? 6 : -6);
            }
            return null;
        }
    }

    public class Scepter : ChessPiece
    {
        public Scepter(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }

            if (IsWhite)
            {
                if (toRow - 1 >= 0 && toColumn - 1 >= 0)
                {
                    pos[toRow - 1, toColumn - 1] = 0;
                }

                if (toRow - 1 >= 0 && toColumn + 1 <= 8)
                {
                    pos[toRow - 1, toColumn + 1] = 0;
                }
            }
            else
            {
                if (toRow + 1 <= 8 && toColumn - 1 >= 0)
                {
                    pos[toRow + 1, toColumn - 1] = 0;
                }

                if (toRow + 1 <= 8 && toColumn + 1 <= 8)
                {
                    pos[toRow + 1, toColumn + 1] = 0;
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Bishop : ChessPiece
    {
        public Bishop(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            bool UpLeft = true, UpRight = true, DownRight = true, DownLeft = true;

            if (toRow - 1 >= 0 && toColumn - 1 >= 0)
            {
                for (int i = toRow - 1; i >= 0 && UpLeft; i--)
                {
                    for (int j = toColumn - 1; j >= 0 && UpLeft; j--)
                    {
                        if (i - toRow == j - toColumn)
                        {
                            if (IsWhite)
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                                    UpLeft = false;
                                }
                            }
                            else
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                                    UpLeft = false;
                                }
                            }
                            if (tablePos[i, j] == 0)
                            {
                                pos[i, j] = 1;
                            }
                        }
                    }
                }
            }

            if (toRow - 1 >= 0 && toColumn + 1 < 9)
            {
                for (int i = toRow - 1; i >= 0 && UpRight; i--)
                {
                    for (int j = toColumn + 1; j < 9 && UpRight; j++)
                    {
                        if (i - toRow == -(j - toColumn))
                        {
                            if (IsWhite)
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                                    UpRight = false;
                                }
                            }
                            else
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                                    UpRight = false;
                                }
                            }
                            if (tablePos[i, j] == 0)
                            {
                                pos[i, j] = 1;
                            }
                        }
                    }
                }
            }

            if (toRow + 1 < 9 && toColumn + 1 < 9)
            {
                for (int i = toRow + 1; i < 9 && DownRight; i++)
                {
                    for (int j = toColumn + 1; j < 9 && DownRight; j++)
                    {
                        if (i - toRow == j - toColumn)
                        {
                            if (IsWhite)
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                                    DownRight = false;
                                }
                            }
                            else
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                                    DownRight = false;
                                }
                            }
                            if (tablePos[i, j] == 0)
                            {
                                pos[i, j] = 1;
                            }
                        }
                    }
                }
            }

            if (toRow + 1 < 9 && toColumn - 1 >= 0)
            {
                for (int i = toRow + 1; i < 9 && DownLeft; i++)
                {
                    for (int j = toColumn - 1; j >= 0 && DownLeft; j--)
                    {
                        if (i - toRow == -(j - toColumn))
                        {
                            if (IsWhite)
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                                    DownLeft = false;
                                }
                            }
                            else
                            {
                                if (tablePos[i, j] != 0)
                                {
                                    pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                                    DownLeft = false;
                                }
                            }
                            if (tablePos[i, j] == 0)
                            {
                                pos[i, j] = 1;
                            }
                        }
                    }
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public bool CanPromote()
        {
            if (IsWhite)
            {
                return Row >= 5;
            }
            else
            {
                return Row <= 3;
            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            if (CanPromote())
            {
                return new Horse(white, row, col, white ? Image.FromFile("images\\horseW.png") : Image.FromFile("images\\horseB.png"), white ? 10 : -10);
            }
            return null;
        }
    }

    public class Horse : ChessPiece
    {
        public Horse(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((i == j || i + j == 8) && (i == toRow && Math.Abs(j - toColumn) == 1) && (j == toColumn && Math.Abs(i - toRow) == 1))
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }

    public class Pawn : ChessPiece
    {
        public Pawn(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    pos[i, j] = 0;
                }
            }

            int wPos1 = toRow + 1, bPos1 = toRow - 1;

            if (IsWhite)
            {
                if (wPos1 <= 8)
                {
                    pos[wPos1, toColumn] = (tablePos[wPos1, toColumn] > 0) ? 0 : (tablePos[wPos1, toColumn] < 0) ? -1 : 1;
                }
            }
            else
            {
                if (bPos1 >= 0)
                {
                    pos[bPos1, toColumn] = (tablePos[bPos1, toColumn] < 0) ? 0 : (tablePos[bPos1, toColumn] > 0) ? -1 : 1;
                }
            }

            pos[toRow, toColumn] = 0;

        }

        public bool CanPromote()
        {
            if (IsWhite)
            {
                return Row >= 5;
            }
            else
            {
                return Row <= 3;
            }
        }

        public override ChessPiece Promote(bool white, int row, int col)
        {
            if (CanPromote())
            {
                return new Tokin(white, row, col, white ? Image.FromFile("images\\tokinW.png") : Image.FromFile("images\\tokinB.png"), white ? 6 : -6);
            }
            return null;
        }
    }

    public class Tokin : ChessPiece
    {
        public Tokin(bool isWhite, int row, int column, Image image, int value) : base(isWhite, row, column, image, value)
        {
        }

        public override void IsValidMove(int toRow, int toColumn, int[,] tablePos, out int[,] pos)
        {
            pos = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Math.Abs(i - toRow) <= 1 && Math.Abs(j - toColumn) <= 1)
                    {
                        if (IsWhite)
                        {
                            pos[i, j] = (tablePos[i, j] > 0) ? 0 : -1;
                        }
                        else
                        {
                            pos[i, j] = (tablePos[i, j] < 0) ? 0 : -1;
                        }
                        if (tablePos[i, j] == 0)
                        {
                            pos[i, j] = 1;
                        }
                    }
                    else
                    {
                        pos[i, j] = 0;
                    }
                }
            }

            if (IsWhite)
            {
                if (toRow - 1 >= 0 && toColumn - 1 >= 0)
                {
                    pos[toRow - 1, toColumn - 1] = 0;
                }

                if (toRow - 1 >= 0 && toColumn + 1 <= 8)
                {
                    pos[toRow - 1, toColumn + 1] = 0;
                }
            }
            else
            {
                if (toRow + 1 <= 8 && toColumn - 1 >= 0)
                {
                    pos[toRow + 1, toColumn - 1] = 0;
                }

                if (toRow + 1 <= 8 && toColumn + 1 <= 8)
                {
                    pos[toRow + 1, toColumn + 1] = 0;
                }
            }

            pos[toRow, toColumn] = 0;

        }


        public override ChessPiece Promote(bool white, int row, int col)
        {
            return null;
        }
    }
}

