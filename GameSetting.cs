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
    public partial class GameSetting : Form
    {
        public int minute = 1;
        public char color;
        public GameSetting()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            minute = (int)nmcMinute.Value;
            if (cmbColor.Text == "Белые") color = 'w'; else
            if (cmbColor.Text == "Чёрные") color = 'b'; else
            {
                Random r = new Random();
                double d = r.Next();
                byte b = (byte)Math.Round(d);
                if (b == 1) color = 'w';
                else
                    color = 'b';
            }
            this.Close();
        }
    }
}
