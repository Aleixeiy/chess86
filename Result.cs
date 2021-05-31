using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace chess86
{
    public partial class Result : Form
    {
        public string name = "";
        public Result(int i, string name)
        {
            this.name = name;
            InitializeComponent();
            string res = "";
            if (i == 0) { labelResult.Text = "Вы проиграли!"; res = "lose"; }
            if (i == 1) { labelResult.Text = "Ничья!"; res = "draw"; }
            if (i == 2) { labelResult.Text = "Вы победили!"; res = "win"; }

            updatePlayer(res);
        }

        private void updatePlayer(string res)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string sql = "UPDATE players SET " + res + " = (" + res + " + 1) WHERE name = '" + name + "';";
            MySqlCommand sqlCom = new MySqlCommand(sql, conn);

            conn.Open();
            sqlCom.ExecuteNonQuery();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
