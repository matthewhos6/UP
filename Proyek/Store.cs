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
    public partial class Store : Form
    {
        public Store()
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

            var pos4 = this.PointToScreen(label4.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            label4.Parent = pictureBox1;
            label4.Location = pos4;
            label4.BackColor = Color.Transparent;

            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\dodoljump.mdf; Integrated Security = True; Connect Timeout = 30";

            conn = new SqlConnection(connectionString);
        }
        SqlConnection conn;
        String connStr;
        string activeuser;
        string character;
        int coinuser;

        private void Form2_Load(object sender, EventArgs e)
        {
            Select.BackColor = Color.Transparent;
            Select.Parent = pictureBox1;
            Select.Location = new Point(222, 215);

            Selected.BackColor = Color.Transparent;
            Selected.Parent = pictureBox1;
            Selected.Location = new Point(222, 215);

            pic200.BackColor = Color.Transparent;
            pic200.Parent = pictureBox1;
            pic200.Location = new Point(222, 215);

            pic300.BackColor = Color.Transparent;
            pic300.Parent = pictureBox1;
            pic300.Location = new Point(222, 215);

            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox2.Location = new Point(65, 350);

            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox1;
            pictureBox3.Location = new Point(183, 345);

            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Parent = pictureBox1;
            pictureBox4.Location = new Point(305, 345);

            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Parent = pictureBox1;
            pictureBox5.Location = new Point(pictureBox5.Location.X, pictureBox5.Location.Y);

            MrPingu.BackColor = Color.Transparent;
            MrPingu.Parent = pictureBox1;
            MrPingu.Location = new Point(25, 110);

            Birdie.BackColor = Color.Transparent;
            Birdie.Parent = pictureBox1;
            Birdie.Location = new Point(25, 93);

            Bolt.BackColor = Color.Transparent;
            Bolt.Parent = pictureBox1;
            Bolt.Location = new Point(25, 105);

            StreamWriter sw = new StreamWriter(Application.StartupPath + "/save2.txt");
            sw.Write("0");
            sw.Close();

            sw = new StreamWriter(Application.StartupPath + "/selected.txt");
            sw.Write("0");
            sw.Close();
            Selected.Visible = true;
            pic200.Visible = false;
            pic300.Visible = false;
            Select.Visible = false;



            StreamReader sr = new StreamReader(Application.StartupPath + "/save1.txt");
            while (!sr.EndOfStream)
            {
                activeuser = sr.ReadLine();

            }
            sr.Close();
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table] where username = '" + activeuser + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label4.Text = reader[1].ToString();
            }
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Menu formmenu = new Menu();
            formmenu.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Birdie.Visible = false;
            MrPingu.Visible = true;
            Bolt.Visible = false;
            label2.Text = "Mr. Pingu";
            label3.Text = "The Executive Penguin";
            StreamWriter sw = new StreamWriter(Application.StartupPath + "/save2.txt");
            sw.Write("0");
            sw.Close();
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table] where username = '" + activeuser + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[2].ToString() == "1")
                {
                    Selected.Visible = true;
                    Select.Visible = false;
                    pic200.Visible = false;
                    pic300.Visible = false;
                }
            }
            conn.Close();
            StreamReader sr = new StreamReader(Application.StartupPath + "/selected.txt");
            while (!sr.EndOfStream)
            {
                if (sr.ReadLine() == "0")
                {
                    Selected.Visible = true;
                    Select.Visible = false;
                    pic200.Visible = false;
                    pic300.Visible = false;
                }
                else
                {
                    Select.Visible = true;
                    Selected.Visible = false;
                    pic200.Visible = false;
                    pic300.Visible = false;
                }
            }
            sr.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Birdie.Visible = true;
            MrPingu.Visible = false;
            Bolt.Visible = false;
            label2.Text = "    Birdy";
            label3.Text = "Always ready for winter";
            StreamWriter sw = new StreamWriter(Application.StartupPath + "/save2.txt");
            sw.Write("1");
            sw.Close();
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table] where username = '" + activeuser + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[3].ToString() == "1")
                {
                    Selected.Visible = true;
                    Select.Visible = false;
                    pic200.Visible = false;
                    pic300.Visible = false;
                    StreamReader sr = new StreamReader(Application.StartupPath + "/selected.txt");
                    while (!sr.EndOfStream)
                    {
                        if (sr.ReadLine() == "1")
                        {
                            Selected.Visible = true;
                            Select.Visible = false;
                            pic200.Visible = false;
                            pic300.Visible = false;
                        }
                        else
                        {
                            Select.Visible = true;
                            Selected.Visible = false;
                            pic200.Visible = false;
                            pic300.Visible = false;
                        }
                    }
                    sr.Close();
                }
                else
                {
                    Selected.Visible = false;
                    Select.Visible = false;
                    pic200.Visible = true;
                    pic300.Visible = false;
                }
            }
            conn.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Birdie.Visible = false;
            MrPingu.Visible = false;
            Bolt.Visible = true;
            label2.Text = "     Bolt";
            label3.Text = "       The Yellow Guy";
            StreamWriter sw = new StreamWriter(Application.StartupPath + "/save2.txt");
            sw.Write("2");
            sw.Close();
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table] where username = '" + activeuser + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[4].ToString() == "1")
                {
                    Selected.Visible = true;
                    Select.Visible = false;
                    pic200.Visible = false;
                    pic300.Visible = false;
                    StreamReader sr = new StreamReader(Application.StartupPath + "/selected.txt");
                    while (!sr.EndOfStream)
                    {
                        if (sr.ReadLine() == "2")
                        {
                            Selected.Visible = true;
                            Select.Visible = false;
                            pic200.Visible = false;
                            pic300.Visible = false;
                        }
                        else
                        {
                            Select.Visible = true;
                            Selected.Visible = false;
                            pic200.Visible = false;
                            pic300.Visible = false;
                        }
                    }
                    sr.Close();
                }
                else
                {
                    Selected.Visible = false;
                    Select.Visible = false;
                    pic200.Visible = false;
                    pic300.Visible = true;
                }
            }
            conn.Close();        
        }

        private void Select_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Application.StartupPath + "/save2.txt");
            while (!sr.EndOfStream)
            {
                character = sr.ReadLine();
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(Application.StartupPath + "/selected.txt");
            sw.Write(character);
            sw.Close();
            Selected.Visible = true;
            pic200.Visible = false;
            pic300.Visible = false;
            Select.Visible = false;
        }

        private void pic200_Click(object sender, EventArgs e)
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
            if (coinuser >= 200)
            {
                Confirmation formconfirm = new Confirmation();
                formconfirm.Show();
                this.Close();
            }
            else
            {
                PurchaseFailed formPF = new PurchaseFailed();
                formPF.Show();
            }

        }

        private void pic300_Click(object sender, EventArgs e)
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
            if (coinuser >= 300)
            {
                Confirmation formconfirm = new Confirmation();
                formconfirm.Show();
                this.Close();
            }
            else
            {
                PurchaseFailed formPF = new PurchaseFailed();
                formPF.Show();
            }
        }
    }
}
