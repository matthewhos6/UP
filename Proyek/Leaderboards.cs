using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyek
{
    public partial class Leaderboards : Form
    {
        public Leaderboards()
        {
            InitializeComponent();
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\dodoljump.mdf; Integrated Security = True; Connect Timeout = 30";

            conn = new SqlConnection(connectionString);

            this.BackColor = Color.DodgerBlue;
            this.TransparencyKey = Color.DodgerBlue;

            var pos0 = this.PointToScreen(label1.Location);
            pos0 = pictureBox1.PointToClient(pos0);
            label1.Parent = pictureBox1;
            label1.Location = pos0;
            label1.BackColor = Color.Transparent;

            var pos1 = this.PointToScreen(label2.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label2.Parent = pictureBox1;
            label2.Location = pos1;
            label2.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(label3.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label3.Parent = pictureBox1;
            label3.Location = pos2;
            label3.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(label4.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label4.Parent = pictureBox1;
            label4.Location = pos3;
            label4.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(label5.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            label5.Parent = pictureBox1;
            label5.Location = pos4;
            label5.BackColor = Color.Transparent;

            var pos5 = this.PointToScreen(label6.Location);
            pos5 = pictureBox1.PointToClient(pos5);
            label6.Parent = pictureBox1;
            label6.Location = pos5;
            label6.BackColor = Color.Transparent;
        }
        SqlConnection conn;
        String connStr;
        int c = 0;

        private void Leaderboards_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table] Order by coin DESC", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (c == 0)
                {
                    label2.Text = "1. " + (reader[0].ToString()) + " (" + (reader[1].ToString()) + ")";
                }
                else if (c == 1)
                {
                    label3.Text = "2. " + (reader[0].ToString()) + " (" + (reader[1].ToString()) + ")";
                }
                else if (c == 2)
                {
                    label4.Text = "3. " + (reader[0].ToString()) + " (" + (reader[1].ToString()) + ")";
                }
                else if (c == 3)
                {
                    label5.Text = "4. " + (reader[0].ToString()) + " (" + (reader[1].ToString()) + ")";
                }
                else if (c == 4)
                {
                    label6.Text = "5. " + (reader[0].ToString()) + " (" + (reader[1].ToString()) + ")";
                }
                c += 1;
            }
            c = 0;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu formmenu = new Menu();
            formmenu.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Menu formmenu = new Menu();
            formmenu.Show();
            this.Close();
        }
    }
}
