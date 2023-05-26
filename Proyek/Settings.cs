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

namespace Proyek
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.BackColor = Color.DimGray;
            this.TransparencyKey = Color.DimGray;

        }
        string set1;
        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Parent = pictureBox1;
            pictureBox4.Location = new Point(pictureBox4.Location.X, pictureBox4.Location.Y);

            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Parent = pictureBox1;
            pictureBox5.Location = new Point(pictureBox5.Location.X, pictureBox5.Location.Y);

            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Parent = pictureBox1;
            pictureBox6.Location = new Point(pictureBox6.Location.X, pictureBox6.Location.Y);

            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Parent = pictureBox1;
            pictureBox7.Location = new Point(pictureBox7.Location.X, pictureBox7.Location.Y);

            var pos1 = this.PointToScreen(label1.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label1.Parent = pictureBox1;
            label1.Location = pos1;
            label1.BackColor = Color.Transparent;


            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;

            StreamReader sr = new StreamReader(Application.StartupPath + "/settings1.txt");
            while (!sr.EndOfStream)
            {
                set1 = sr.ReadLine();
            }
            sr.Close();
            if (set1 == "mute")
            {
                pictureBox6.Visible = true;
                pictureBox4.Visible = false;
            }
            else
            {
                pictureBox6.Visible = false;
                pictureBox4.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a user first!");


        }

        //private void btnSong1_MouseEnter(object sender, EventArgs e)
        //{
        //    this.btnSong1.BackgroundImage =
        //        ((System.Drawing.Image)(Properties.Resources.satisfactionH));
        //}

        //private void btnSong1_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnSong1.BackgroundImage =
        //        ((System.Drawing.Image)(Properties.Resources.satisfaction));
        //}

        //private void btnSong1_Click(object sender, EventArgs e)
        //{
        //    nowPlaying1.Visible = Enabled;
        //    nowPlaying2.Visible = false;
        //    nowPlaying5.Visible = false;

        //    this.btnSong1.BackgroundImage =
        //        ((System.Drawing.Image)(Properties.Resources.satisfactionH));

        //    axWindowsMediaPlayer1.URL =
        //        @"C:\MediaFile\music\ArethaFranklin\(I Can't Get No) Satisfaction.mp3";
        //}

        //private void btnSong2_Click(object sender, EventArgs e)
        //{
        //    this.btnSong1.BackgroundImage =
        //        ((System.Drawing.Image)(Properties.Resources.satisfaction));
        //    axWindowsMediaPlayer1.URL = @"C:\MediaFile\music\ArethaFranklin\Come To Me.mp3";
        //    nowPlaying1.Visible = false;
        //    nowPlaying2.Visible = Enabled;
        //    nowPlaying5.Visible = false;
        //}

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox6.Visible = true;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox7.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox6.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox7.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Visible)
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "/settings1.txt");
                sw.Write("mute");
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "/settings1.txt");
                sw.Write("not muted");
                sw.Close();
            }
            if (pictureBox7.Visible)
            {

            }
            Menu formmenu = new Menu();
            formmenu.Show();
            this.Close();
        }
    }
}
