using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace chess86
{
    public class Board
    {
        public int posX;
        public int posY;
        public int square;
        public Image img = new Bitmap("pic\\board.bmp");

        public Board(int posX, int posY, int square)
        {
            this.posX = posX;
            this.posY = posY;
            this.square = square;
        }
    }
}
