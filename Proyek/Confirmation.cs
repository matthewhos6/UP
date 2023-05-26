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
using System.IO;

namespace Proyek
{
    public partial class Confirmation : Form
    {
        public Confirmation()
        {
            InitializeComponent();
            this.BackColor = Color.DodgerBlue;
            this.TransparencyKey = Color.DodgerBlue;

            var pos1 = this.PointToScreen(label1.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label1.Parent = pictureBox1;
            label1.Location = pos1;
            label1.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(label2.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label2.Parent = pictureBox1;
            label2.Location = pos2;
            label2.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(label3.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label3.Parent = pictureBox1;
            label3.Location = pos3;
            label3.BackColor = Color.Transparent;
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\dodoljump.mdf; Integrated Security = True; Connect Timeout = 30";

            conn = new SqlConnection(connectionString);
        }
        SqlConnection conn;
        String connStr;
        string character;
        string activeuser;
        int coinuser;
        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox2.Location  = new Point(55, 110);

            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Parent = pictureBox1;
            pictureBox4.Location = new Point(55, 110);

            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Parent = pictureBox1;
            pictureBox5.Location = new Point(55, 110);

            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox1;
            pictureBox3.Location = new Point(171, 137);

            StreamReader sr = new StreamReader(Application.StartupPath + "/save2.txt");
            while (!sr.EndOfStream)
            {
                character = sr.ReadLine();

            }
            sr.Close();
            if (character == "0")
            {
                pictureBox2.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                label3.Text = "100";
            }
            else if (character == "1")
            {
                pictureBox4.Visible = true;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                label3.Text = "200";
            }
            else if (character == "2")
            {
                pictureBox5.Visible = true;
                pictureBox2.Visible = false;
                pictureBox4.Visible = false;
                label3.Text = "300";
            }

            sr = new StreamReader(Application.StartupPath + "/save1.txt");
            while (!sr.EndOfStream)
            {
                activeuser = sr.ReadLine();

            }
            sr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table] where username = '" + activeuser + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                coinuser = Convert.ToInt32(reader[1]);
            }
            conn.Close();
            conn.Open();
            int coin = coinuser - Convert.ToInt32(label3.Text);
            if (character == "1")
            {
                cmd = new SqlCommand("update [table] set coin = @coin, char2 = 1 where username = '" + activeuser + "'", conn);
            }
            else if (character == "2")
            {
                cmd = new SqlCommand("update [table] set coin = @coin, char3 = 1 where username = '" + activeuser + "'", conn);
            }          
            cmd.Parameters.AddWithValue("@coin", coin);
            cmd.ExecuteNonQuery();
            conn.Close();
            Store formstore = new Store();
            formstore.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Store formstore = new Store();
            formstore.Show();
            this.Close();
        }
    }
}
