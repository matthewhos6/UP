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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\dodoljump.mdf; Integrated Security = True; Connect Timeout = 30";

            conn = new SqlConnection(connectionString);

            this.BackColor = Color.DodgerBlue;
            this.TransparencyKey = Color.DodgerBlue;


            var pos2 = this.PointToScreen(label2.Location);
            pos2 = pictureBox2.PointToClient(pos2);
            label2.Parent = pictureBox2;
            label2.Location = pos2;
            label2.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(label3.Location);
            pos3 = pictureBox2.PointToClient(pos3);
            label3.Parent = pictureBox2;
            label3.Location = pos3;
            label3.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(label4.Location);
            pos4 = pictureBox2.PointToClient(pos4);
            label4.Parent = pictureBox2;
            label4.Location = pos4;
            label4.BackColor = Color.Transparent;

            var pos5 = this.PointToScreen(label5.Location);
            pos5 = pictureBox2.PointToClient(pos5);
            label5.Parent = pictureBox2;
            label5.Location = pos5;
            label5.BackColor = Color.Transparent;

        }
        SqlConnection conn;
        String connStr;
        string userlama;

        private void user_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
            }
            conn.Close();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            userlama = listBox1.SelectedItem.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete [table] where username = @userlama", conn);
                cmd.Parameters.AddWithValue("@userlama", userlama);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Deleted!");
                StreamWriter sw = new StreamWriter(Application.StartupPath + "/save1.txt");
                sw.Write("...");
                sw.Close();
                conn.Close();

                listBox1.Items.Clear();
                connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
                conn = new SqlConnection(connStr);
                conn.Open();
                cmd = new SqlCommand("Select * from [Table]", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString());
                }
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Select a user first!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("Select a user first!");
                }
                else
                {
                    StreamWriter sw = new StreamWriter(Application.StartupPath + "/save1.txt");
                    sw.Write(listBox1.SelectedItem.ToString());
                    sw.Close();
                    MessageBox.Show("User Loaded!");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select a user first!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please input a Username!");
            }
            else
            {
                conn.Close();
                conn.Open();
                string user = textBox1.Text;
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into [Table] (username, coin, char1, char2, char3) values (@user, @coin, @char1, @char2, @char3)", conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@coin", "0");
                    cmd.Parameters.AddWithValue("@char1", "1");
                    cmd.Parameters.AddWithValue("@char2", "0");
                    cmd.Parameters.AddWithValue("@char3", "0");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added!");
                    conn.Close();

                    listBox1.Items.Clear();
                    connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    cmd = new SqlCommand("Select * from [Table]", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("User already registered!");
                }
            }
        }
    }
}
