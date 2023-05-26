using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using WMPLib;

namespace Proyek
{
    public partial class Menu : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        System.Media.SoundPlayer mediaPlayer1 = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\backsound.wav");

        WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        System.Media.SoundPlayer mediaPlayer2 = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\buttonlo.wav");

        public Menu()
        {
            InitializeComponent();

            this.BackColor = Color.DimGray;
            this.TransparencyKey = Color.DimGray;

            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\dodoljump.mdf; Integrated Security = True; Connect Timeout = 30";

            conn = new SqlConnection(connectionString);

            var pos1 = this.PointToScreen(label1.Location);
            pos1 = pictureBox2.PointToClient(pos1);
            label1.Parent = pictureBox2;
            label1.Location = pos1;
            label1.BackColor = Color.Transparent;

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

            var pos6 = this.PointToScreen(label6.Location);
            pos6 = pictureBox2.PointToClient(pos6);
            label6.Parent = pictureBox2;
            label6.Location = pos6;
            label6.BackColor = Color.Transparent;

            var pos7 = this.PointToScreen(label7.Location);
            pos7 = pictureBox2.PointToClient(pos7);
            label7.Parent = pictureBox2;
            label7.Location = pos7;
            label7.BackColor = Color.Transparent;

            //var pos6 = this.PointToScreen(label6.Location);
            //pos6 = pictureBox2.PointToClient(pos6);
            //label6.Parent = pictureBox2;
            //label6.Location = pos6;
            //label6.BackColor = Color.Transparent;
        }
        SqlConnection conn;
        String connStr;
        int change;
        Bitmap coin;
        string activeuser;
        string set1;

        private void Menu_Load(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\backsound.wav";
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "/settings1.txt");
                while (!sr.EndOfStream)
                {
                    set1 = sr.ReadLine();
                }
                sr.Close();

                if (set1 == "mute")
                {
                    mediaPlayer1.Stop();
                }
                else
                {
                    mediaPlayer1.PlayLooping();
                }
            }
            catch (Exception)
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "/settings1.txt");
                sw.Write("not muted");
                sw.Close();
                mediaPlayer1.PlayLooping();
            }

            change = 1;
            coin = new Bitmap(Resources.c6);
            timer1.Start();

            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Parent = pictureBox2;
            pictureBox8.Location = new Point(pictureBox8.Location.X, pictureBox8.Location.Y);
            pictureBox8.BringToFront();

            //pictureBox9.BackColor = Color.Transparent;
            //pictureBox9.Parent = pictureBox2;
            //pictureBox9.Location = new Point(pictureBox9.Location.X, pictureBox9.Location.Y);

            //pictureBox10.BackColor = Color.Transparent;
            //pictureBox10.Parent = pictureBox2;
            //pictureBox10.Location = new Point(pictureBox10.Location.X, pictureBox10.Location.Y);

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Parent = pictureBox2;
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);

            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Parent = pictureBox2;
            pictureBox4.Location = new Point(pictureBox4.Location.X, pictureBox4.Location.Y);

            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Parent = pictureBox2;
            pictureBox5.Location = new Point(pictureBox5.Location.X, pictureBox5.Location.Y);

            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Parent = pictureBox2;
            pictureBox6.Location = new Point(pictureBox6.Location.X, pictureBox6.Location.Y);

            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Parent = pictureBox2;
            pictureBox7.Location = new Point(pictureBox7.Location.X, pictureBox7.Location.Y);


            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox2;
            pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y);

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (change == 1)
            {
                coin = new Bitmap(Resources.c1);
                change += 1;
            }
            else if (change == 2)
            {
                coin = new Bitmap(Resources.c2);
                change += 1;
            }
            else if (change == 3)
            {
                coin = new Bitmap(Resources.c3);
                change += 1;
            }
            else if (change == 4)
            {
                coin = new Bitmap(Resources.c4);
                change += 1;
            }
            else if (change == 5)
            {
                coin = new Bitmap(Resources.c5);
                change += 1;
            }
            else if (change == 6)
            {
                coin = new Bitmap(Resources.c6);
                change = 1;
            }
            this.Invalidate();
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "/save1.txt");
                while (!sr.EndOfStream)
                {
                    activeuser = sr.ReadLine();

                }
                sr.Close();
                label2.Text = "Hi, " + activeuser;
            }
            catch (Exception)
            {
                label2.Text = "...";
            }
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from [Table] where username = '" + activeuser + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = " " + (reader[1].ToString());
            }
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            user formuser = new user();
            formuser.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Settings FormSettings = new Settings();
            FormSettings.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Tutorial formtutor = new Tutorial();
            formtutor.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 formplay = new Form1();
            formplay.Show();
            this.Hide();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Parent = pictureBox2;
            pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y);
            pictureBox3.Show();
            pictureBox3.BringToFront();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Hide();
            pictureBox3.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 formplay = new Form1();
            formplay.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 formplay = new Form1();
            formplay.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            FormCopyright copyright = new FormCopyright();
            copyright.Show();
            this.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            mediaPlayer1.Play();
            Form1 formplay = new Form1();
            formplay.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Store formshop = new Store();
            formshop.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Store formshop = new Store();
            formshop.Show();
            this.Hide();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            Store formshop = new Store();
            formshop.Show();
            this.Hide();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Hide();
            pictureBox6.BringToFront();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Parent = pictureBox2;
            pictureBox6.Location = new Point(pictureBox4.Location.X, pictureBox4.Location.Y);
            pictureBox6.Show();
            pictureBox6.BringToFront();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Parent = pictureBox2;
            pictureBox7.Location = new Point(pictureBox7.Location.X, pictureBox7.Location.Y);
            pictureBox7.Show();
            pictureBox7.BringToFront();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Hide();
            pictureBox7.BringToFront();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Leaderboards formlead = new Leaderboards();
            formlead.Show();
            this.Hide();
        }
    }
}
