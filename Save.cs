using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace chess86
{
    public partial class Save : Form
    {
        public string record = "";
        public string name;
        public Save(string record)
        {
            InitializeComponent();
            this.record = record;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                name = textBoxName.Text;
                FileStream fs = new FileStream(".\\партии\\" + name + ".txt", FileMode.Create);
                fs.Write(Encoding.Default.GetBytes(record), 0, record.Length);
                fs.Close();
                this.Close();
            }
            catch
            {
                
            }
        }
    }
}
