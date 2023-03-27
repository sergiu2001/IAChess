using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAChess
{
    public partial class Form1 : Form
    {
        Player playerW = new Player(true);
        Player playerB = new Player(false);
        Table chessTable = new Table();

        int selectedPieceRow, selectedPieceCol;
        ChessPiece selectedPiece;
        public Form1()
        {
            InitializeComponent();
        }

        private void tlpChessboard_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            bool isDarkSquare = ((e.Row % 2 == 0) && (e.Column % 2 == 0)) || ((e.Row % 2 == 1) && (e.Column % 2 == 1));

            if (isDarkSquare)
            {
                e.Graphics.FillRectangle(Brushes.LightPink, e.CellBounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Magenta, e.CellBounds);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int row = 0; row < tlpChessboard.RowCount; row++)
            {
                for (int col = 0; col < tlpChessboard.ColumnCount; col++)
                {
                    ChessPiece pieceW = playerW.isOnBoard(row, col);
                    ChessPiece pieceB = playerB.isOnBoard(row, col);
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.BackColor = Color.Transparent;
                    pictureBox.Margin = new Padding(0);
                    if (pieceW != null)
                    {
                        pictureBox.Image = pieceW.Image;
                        tlpChessboard.Controls.Add(pictureBox, pieceW.Column, pieceW.Row);
                        chessTable.SetValue(pieceW.Row, pieceW.Column, pieceW.Value, pictureBox);
                    }
                    else if (pieceB != null)
                    {
                        pictureBox.Image = pieceB.Image;
                        tlpChessboard.Controls.Add(pictureBox, pieceB.Column, pieceB.Row);
                        chessTable.SetValue(pieceB.Row, pieceB.Column, pieceB.Value, pictureBox);
                    }
                    else
                    {
                        tlpChessboard.Controls.Add(pictureBox, col, row);
                        chessTable.SetValue(row, col, 0, pictureBox);
                    }
                }
            }


            foreach (Control c in this.tlpChessboard.Controls)
            {
                c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
            }


        }

        public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e)
        {
            int cellRow = tlpChessboard.GetRow((Control)sender);
            int cellColumn = tlpChessboard.GetColumn((Control)sender);
            PictureBox pictureBox = (PictureBox)sender;
            if (tlpChessboard.GetControlFromPosition(cellColumn, cellRow).BackColor == Color.Transparent && chessTable.values[cellRow, cellColumn] != 0)
            {
                for (int i = 0; i < tlpChessboard.RowCount; i++)
                {
                    for (int j = 0; j < tlpChessboard.ColumnCount; j++)
                    {
                        tlpChessboard.GetControlFromPosition(j, i).BackColor = Color.Transparent;
                    }
                }
                selectedPieceRow = cellRow;
                selectedPieceCol = cellColumn;

                if (pictureBox.Image != null)
                {
                    pictureBox.BackColor = Color.FromArgb(170, 50, 55, 59);

                    selectedPiece = (playerW.isOnBoard(cellRow, cellColumn) != null) ? (playerW.isOnBoard(cellRow, cellColumn)) : (playerB.isOnBoard(cellRow, cellColumn));
                    int[,] pos;
                    selectedPiece.IsValidMove(cellRow, cellColumn, chessTable.values, out pos);
                    for (int i = 0; i < pos.GetLength(0); i++)
                    {
                        for (int j = 0; j < pos.GetLength(1); j++)
                        {
                            if (pos[i, j] == 1)
                            {
                                tlpChessboard.GetControlFromPosition(j, i).BackColor = Color.FromArgb(244, 184, 96);
                            }
                            if (pos[i, j] == -1)
                            {
                                tlpChessboard.GetControlFromPosition(j, i).BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            else
            {
                if (tlpChessboard.GetControlFromPosition(cellColumn, cellRow).BackColor == Color.FromArgb(244, 184, 96) && chessTable.values[cellRow, cellColumn] == 0)
                {
                    chessTable.values[cellRow, cellColumn] = chessTable.values[selectedPieceRow, selectedPieceCol];
                    chessTable.images[cellRow, cellColumn].Image = chessTable.images[selectedPieceRow, selectedPieceCol].Image;
                    selectedPiece.Row = cellRow;
                    selectedPiece.Column = cellColumn;

                    chessTable.values[selectedPieceRow, selectedPieceCol] = 0;
                    chessTable.images[selectedPieceRow, selectedPieceCol].Image = null;
                    selectedPieceCol = -1;
                    selectedPieceRow = -1;
                    selectedPiece = null;

                }
                if (tlpChessboard.GetControlFromPosition(cellColumn, cellRow).BackColor == Color.Red)
                {

                }
                for (int i = 0; i < tlpChessboard.RowCount; i++)
                {
                    for (int j = 0; j < tlpChessboard.ColumnCount; j++)
                    {
                        tlpChessboard.GetControlFromPosition(j, i).BackColor = Color.Transparent;
                    }
                }
            }

            MessageBox.Show("Cell chosen: (" + cellRow + ", " + cellColumn + ")");
        }

    }
}
