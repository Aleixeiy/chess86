using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace chess86
{
    public partial class StartForm : Form
    {
        public string name = "";
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((textBoxName.Text == "") && (listBoxPlayers.SelectedIndex >= 0))
            {
                name = (string)listBoxPlayers.SelectedItem;
                this.Close();
                return;
            }
            if (isCorrect(textBoxName.Text))
            {
                name = textBoxName.Text;
                addToBase(name);
                this.Close();
                return;
            }

            textBoxName.BackColor = Color.Red;
        }

        private void addToBase(string name)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string sql = "INSERT INTO players (name, win, draw, lose) VALUES (@p1, @p2, @p3, @p4)";
            MySqlCommand sqlCom = new MySqlCommand(sql, conn);
            sqlCom.Parameters.AddWithValue("p1", name);
            sqlCom.Parameters.AddWithValue("p2", 0);
            sqlCom.Parameters.AddWithValue("p3", 0);
            sqlCom.Parameters.AddWithValue("p4", 0);

            conn.Open();
            sqlCom.ExecuteNonQuery();
        }

        private bool isCorrect(string name)
        {
            if ((name.Length <= 0) || (name.Length >= 12)) return false;
            for (int i = 0; i < name.Length; i++)
                if (!(((name[i] >= 'a') && (name[i] <= 'z')) ||
                     ((name[i] >= 'A') && (name[i] <= 'Z')) ||
                     ((name[i] >= '0') && (name[i] <= '9')))) return false;
            return true;
        }

        private void textBoxName_Click(object sender, EventArgs e)
        {
            textBoxName.BackColor = Color.White;
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBUtils.GetDBConnection();
                string sql = "SELECT * FROM players";
                MySqlCommand sqlCom = new MySqlCommand(sql, conn);
                conn.Open();
                sqlCom.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCom);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                var myData = dt.Select();
                foreach (var row in myData)
                    try
                    {
                        string name = (string)row.ItemArray[1];
                        listBoxPlayers.Items.Add(name);
                    }
                    catch
                    {
                    }
            }
            catch
            {
                MessageBox.Show("Не удалось соедениться с базой данных.\nСкорее всего неверно указан IP хоста.");
            }
        }
    }
}
