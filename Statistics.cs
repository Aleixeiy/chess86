using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess86
{
    public partial class Statistics : Form
    {
        public int win = 0;
        public int draw = 0;
        public int lose = 0;

        public Statistics(int win, int draw, int lose)
        {
            InitializeComponent();
            this.win = win;
            this.draw = draw;
            this.lose = lose;
            int sum = win + draw + lose;
            int pw = (int)Math.Round((double)100 * win / sum);
            int pd = (int)Math.Round((double)100 * draw / sum);
            int pl = 100 - pw - pd;
            labelWin.Text = pw.ToString() + "%";
            labelDraw.Text = pd.ToString() + "%";
            labelLose.Text = pl.ToString() + "%";
        }

        private void Statistics_Paint(object sender, PaintEventArgs e)
        {
            int sum = win + draw + lose;
            if (sum != 0)
            {
                int aw = (int)Math.Round((double)360 * win / sum);
                int ad = (int)Math.Round((double)360 * draw / sum);
                int al = 360 - aw - ad;

                e.Graphics.FillPie(Brushes.Lime, 20, 20, 300, 300, -30, aw);
                e.Graphics.FillPie(Brushes.Silver, 20, 20, 300, 300, aw - 30, ad);
                e.Graphics.FillPie(Brushes.Red, 20, 20, 300, 300, aw + ad - 30, al);
            }
        }
    }
}
