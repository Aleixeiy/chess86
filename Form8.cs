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
    public partial class Form8 : Form
    {
        public char f;
        public byte l1;
        public byte n1;
        public byte l2;
        public byte n2;
        public Form8(byte l1, byte n1, byte l2, byte n2)
        {
            InitializeComponent();
            this.l1 = l1;
            this.n1 = n1;
            this.l2 = l2;
            this.n2 = n2;
        }

        private void pictureQ_Click(object sender, EventArgs e)
        {
            f = 'q';
            this.Close();
        }

        private void pictureR_Click(object sender, EventArgs e)
        {
            f = 'r';
            this.Close();
        }

        private void pictureB_Click(object sender, EventArgs e)
        {
            f = 'b';
            this.Close();
        }

        private void pictureN_Click(object sender, EventArgs e)
        {
            f = 'n';
            this.Close();
        }
    }
}
