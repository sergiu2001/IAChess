using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAChess
{
    public class Table
    {
        public int[,] values = new int[9, 9];
        public PictureBox[,] images = new PictureBox[9, 9];

        public void SetValue(int row, int column, int value, PictureBox image)
        {
            values[row, column] = value;
            images[row, column] = image;
        }
    }
}
