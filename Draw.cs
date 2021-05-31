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
    public partial class Draw : Form
    {
        public bool draw = false;

        public Draw()
        {
            InitializeComponent();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            draw = true;
            this.Close();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            draw = false;
            this.Close();
        }
    }
}
