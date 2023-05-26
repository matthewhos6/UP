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
using System.Media;
using WMPLib;

namespace Proyek
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        System.Media.SoundPlayer mediaPlayer1 = new System.Media.SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\backsound.wav");
        public Form1()
        {
            InitializeComponent();
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\dodoljump.mdf; Integrated Security = True; Connect Timeout = 30";

            conn = new SqlConnection(connectionString);
        }
        string set1;
        SqlConnection conn;
        String connStr;
        string activeuser;
        string character;
        int countdown;
        int xplayer = 130;
        int yplayer = 380;

        //n dan j untuk menghitung berapa lama player jatuh/ naik
        int n = 0;
        int j = 0;

        Random rnd = new Random();
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Rectangle> coins = new List<Rectangle>();
        List<Rectangle> bombs = new List<Rectangle>();

        Bitmap chr;
        Bitmap coin;
        Bitmap bomb;

        int totalcoin = 0;
        int coinchange = 1;
        int randomcoin;
        int coinremove;
        int bombremove;

        bool go = false;
        bool dapat;
        bool kena;

        //Replay
        bool replay = false;
        int rep = 0;
        int timepress = 0;
        int ttime = 0;
        int playermove = 0;
        int entc = 0;
        int entb = 0;
        int entc1 = 0;
        int entb1 = 0;
        List<int> rx = new List<int>();
        List<int> ry = new List<int>();
        List<int> timepressed = new List<int>();
        List<int> entcs = new List<int>();
        List<int> entbs = new List<int>();
        List<int> px = new List<int>();


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (go)
            {
                if (yplayer >= 600)
                {
                    label2.Text = "Game Over !";
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    timer1.Stop();
                    timer2.Stop();
                    platform.Stop();
                }
                Graphics g = e.Graphics;
                Rectangle rect = new Rectangle(xplayer, yplayer, 30, 30);
                if (character == "0")
                {
                    g.DrawImage(chr, xplayer, yplayer, 50, 50);
                }
                else if (character == "1")
                {
                    g.DrawImage(chr, xplayer, yplayer, 54, 43);
                }
                else if (character == "2")
                {
                    g.DrawImage(chr, xplayer, yplayer, 69, 46);
                }
                g.DrawImage(coin, -23, -26, 110, 110);
                SolidBrush brushBlack = new SolidBrush(Color.Transparent);
                int z = 0;
                dapat = false;
                foreach (var i in coins)
                {
                    if (coins[z].Y >= 600 || coins[z].Y <= -50)
                    {

                    }
                    else
                    {
                        g.FillRectangle(brushBlack, coins[z]);
                        g.DrawImage(coin, coins[z].X, coins[z].Y, 110, 110);
                    }
                    if (rect.IntersectsWith(coins[z]))
                    {
                        dapat = true;
                        coinremove = z;
                    }
                    z += 1;
                }
                if (dapat)
                {
                    coins.RemoveAt(coinremove);
                    totalcoin += 1;
                    label3.Text = "X" + totalcoin;
                    dapat = false;
                }
                try
                {
                    if (coins[0].Y >= 850)
                    {
                        coins.RemoveAt(0);
                    }
                }
                catch (Exception)
                {

                }

                //////////////////////////////////////////////////////////////////////////
                z = 0;
                kena = false;
                foreach (var i in bombs)
                {
                    if (bombs[z].Y >= 600 || bombs[z].Y <= -50)
                    {

                    }
                    else
                    {
                        g.FillRectangle(brushBlack, bombs[z]);
                        g.DrawImage(bomb, bombs[z].X, bombs[z].Y, 55, 58);
                    }
                    if (rect.IntersectsWith(bombs[z]))
                    {
                        kena = true;
                        bombremove = z;
                    }
                    z += 1;
                }
                if (kena)
                {
                    bombs.RemoveAt(bombremove);
                    label2.Text = "Game Over !";
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    timer1.Stop();
                    timer2.Stop();
                    platform.Stop();
                }
                try
                {
                    if (bombs[0].Y >= 850)
                    {
                        bombs.RemoveAt(0);
                    }
                }
                catch (Exception)
                {

                }
                //////////////////////////////////////////////////////////////////////////
                z = 0;
                foreach (var i in rectangles)
                {
                    if (rectangles[z].Y >= 600 || rectangles[z].Y <= -50)
                    {

                    }
                    else
                    {
                        g.FillRectangle(brushBlack, rectangles[z]);
                        g.DrawImage(Resources.platformn, rectangles[z].X, rectangles[z].Y, 136, 30);
                    }
                    if (rect.IntersectsWith(rectangles[z]))
                    {
                        timer1.Start();
                        j = 0;
                        timer2.Stop();
                    }
                    z += 1;
                }
                try
                {
                    if (rectangles[0].Y >= 850)
                    {
                        rectangles.RemoveAt(0);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //TIMER 1 PLAYER KE ATAS, PLATFORM KE BAWAH
            if (n <= 10)
            {
                if (yplayer < 200)
                {
                    yplayer -= 1;
                    n += 1;
                    for (int i = 0; i < rectangles.Count; i++)
                    {
                        Rectangle tempRect = rectangles[i];
                        tempRect.Y += 12;
                        rectangles[i] = tempRect;
                    }
                    for (int i = 0; i < coins.Count; i++)
                    {
                        Rectangle tempRect = coins[i];
                        tempRect.Y += 12;
                        coins[i] = tempRect;
                    }
                    for (int i = 0; i < bombs.Count; i++)
                    {
                        Rectangle tempRect = bombs[i];
                        tempRect.Y += 12;
                        bombs[i] = tempRect;
                    }
                }
                else
                {
                    yplayer -= 7;
                    n += 1;
                    for (int i = 0; i < rectangles.Count; i++)
                    {
                        Rectangle tempRect = rectangles[i];
                        tempRect.Y += 10;
                        rectangles[i] = tempRect;
                    }
                    for (int i = 0; i < coins.Count; i++)
                    {
                        Rectangle tempRect = coins[i];
                        tempRect.Y += 10;
                        coins[i] = tempRect;
                    }
                    for (int i = 0; i < bombs.Count; i++)
                    {
                        Rectangle tempRect = bombs[i];
                        tempRect.Y += 10;
                        bombs[i] = tempRect;
                    }
                }
            }
            else if (n >= 10 && n <= 20)
            {
                yplayer -= 4;
                n += 1;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Rectangle tempRect = rectangles[i];
                    tempRect.Y += 7;
                    rectangles[i] = tempRect;
                }
                for (int i = 0; i < coins.Count; i++)
                {
                    Rectangle tempRect = coins[i];
                    tempRect.Y += 7;
                    coins[i] = tempRect;
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Rectangle tempRect = bombs[i];
                    tempRect.Y += 7;
                    bombs[i] = tempRect;
                }
            }
            else if (n >= 20 && n <= 30)
            {
                yplayer -= 2;
                n += 1;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Rectangle tempRect = rectangles[i];
                    tempRect.Y += 5;
                    rectangles[i] = tempRect;
                }
                for (int i = 0; i < coins.Count; i++)
                {
                    Rectangle tempRect = coins[i];
                    tempRect.Y += 5;
                    coins[i] = tempRect;
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Rectangle tempRect = bombs[i];
                    tempRect.Y += 5;
                    bombs[i] = tempRect;
                }
            }
            else if (n >= 30 && n <= 41)
            {
                yplayer -= 1;
                n += 1;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Rectangle tempRect = rectangles[i];
                    tempRect.Y += 4;
                    rectangles[i] = tempRect;
                }
                for (int i = 0; i < coins.Count; i++)
                {
                    Rectangle tempRect = coins[i];
                    tempRect.Y += 4;
                    coins[i] = tempRect;
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Rectangle tempRect = bombs[i];
                    tempRect.Y += 4;
                    bombs[i] = tempRect;
                }
            }
            else if (n >= 40)
            {
                timer2.Start();
                n = 0;
                timer1.Stop();
            }
            this.Invalidate();
            timepress += 20;
            if (replay)
            {
                try
                {
                    if (timepressed[ttime] == timepress)
                    {
                        ttime += 1;
                        xplayer = px[playermove];                     
                        if (px[playermove] < px[playermove - 1])
                        {
                            if (character == "0")
                            {
                                chr = new Bitmap(Resources.l);
                            }
                            else if (character == "1")
                            {
                                chr = new Bitmap(Resources.l1);
                            }
                            else if (character == "2")
                            {
                                chr = new Bitmap(Resources.l2);
                            }
                        }
                        else
                        {
                            if (character == "0")
                            {
                                chr = new Bitmap(Resources.r);
                            }
                            else if (character == "1")
                            {
                                chr = new Bitmap(Resources.r1);
                            }
                            else if (character == "2")
                            {
                                chr = new Bitmap(Resources.r2);
                            }
                        }
                        playermove += 1;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //KENDALIKAN PLAYER
            if (pictureBox1.Visible == false && replay == false)
            {
                if (e.KeyCode == Keys.D)
                {
                    if (character == "0")
                    {
                        chr = new Bitmap(Resources.r);
                    }
                    else if (character == "1")
                    {
                        chr = new Bitmap(Resources.r1);
                    }
                    else if (character == "2")
                    {
                        chr = new Bitmap(Resources.r2);
                    }
                    if (xplayer > 380)
                    {
                        xplayer -= 400;
                    }
                    else
                    {
                        xplayer += 17;
                    }
                }
                else if (e.KeyCode == Keys.A)
                {
                    if (character == "0")
                    {
                        chr = new Bitmap(Resources.l);
                    }
                    else if (character == "1")
                    {
                        chr = new Bitmap(Resources.l1);
                    }
                    else if (character == "2")
                    {
                        chr = new Bitmap(Resources.l2);
                    }
                    if (xplayer < 1)
                    {
                        xplayer += 400;
                    }
                    else
                    {
                        xplayer -= 17;
                    }
                }
                px.Add(xplayer);
                timepressed.Add(timepress);
            }
            else
            {

            }          
            this.Invalidate();          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //TIMER 2 PLAYER KE BAWAH, PLATFORM KE ATAS
            if (j <= 10)
            {
                yplayer += 1;
                j += 1;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Rectangle tempRect = rectangles[i];
                    tempRect.Y -= 1;
                    rectangles[i] = tempRect;
                }
                for (int i = 0; i < coins.Count; i++)
                {
                    Rectangle tempRect = coins[i];
                    tempRect.Y -= 1;
                    coins[i] = tempRect;
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Rectangle tempRect = bombs[i];
                    tempRect.Y -= 1;
                    bombs[i] = tempRect;
                }
            }
            else if (j >= 10 && j <= 20)
            {
                yplayer += 2;
                j += 1;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Rectangle tempRect = rectangles[i];
                    tempRect.Y -= 2;
                    rectangles[i] = tempRect;
                }
                for (int i = 0; i < coins.Count; i++)
                {
                    Rectangle tempRect = coins[i];
                    tempRect.Y -= 2;
                    coins[i] = tempRect;
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Rectangle tempRect = bombs[i];
                    tempRect.Y -= 2;
                    bombs[i] = tempRect;
                }
            }
            else if (j >= 20 && j <= 30)
            {
                yplayer += 4;
                j += 1;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Rectangle tempRect = rectangles[i];
                    tempRect.Y -= 4;
                    rectangles[i] = tempRect;
                }
                for (int i = 0; i < coins.Count; i++)
                {
                    Rectangle tempRect = coins[i];
                    tempRect.Y -= 4;
                    coins[i] = tempRect;
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Rectangle tempRect = bombs[i];
                    tempRect.Y -= 4;
                    bombs[i] = tempRect;
                }
            }
            else if (j >= 30)
            {
                yplayer += 7;
                j += 1;
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Rectangle tempRect = rectangles[i];
                    tempRect.Y -= 7;
                    rectangles[i] = tempRect;
                }
                for (int i = 0; i < coins.Count; i++)
                {
                    Rectangle tempRect = coins[i];
                    tempRect.Y -= 7;
                    coins[i] = tempRect;
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Rectangle tempRect = bombs[i];
                    tempRect.Y -= 7;
                    bombs[i] = tempRect;
                }
            }
            this.Invalidate();
            timepress += 20;
            if (replay)
            {
                try
                {
                    if (timepressed[ttime] == timepress)
                    {
                        ttime += 1;
                        xplayer = px[playermove];
                        playermove += 1;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (countdown < 1)
            {

            }
            else
            {
                if (countdown == 1)
                {
                    countdown -= 1;
                    label1.Text = "GO!";
                    label1.Visible = false;
                    label3.Visible = true;
                    go = true;
                    platform.Interval = 2000;
                    timer2.Start();
                    timer4.Start();
                }
                else
                {
                    countdown -= 1;
                    label1.Text = countdown.ToString();
                }
            }
            if (go == true && replay == false)
            {
                if (yplayer < 200)
                {
                    int tempx = rnd.Next(0, 320);
                    int tempy = rnd.Next(-150, 221);
                    rx.Add(tempx);
                    ry.Add(tempy);
                    Rectangle rects = new Rectangle(tempx, tempy, 120, 15);
                    rectangles.Add(rects);
                    if (1 == randomcoin || 2 == randomcoin)
                    {
                        Rectangle coin = new Rectangle(tempx += 10, tempy -= 100, 50, 20);
                        coins.Add(coin);
                        entcs.Add(entc);
                    }
                    else if (3 == randomcoin)
                    {
                        Rectangle bomb = new Rectangle(tempx += 40, tempy -= 60, 50, 20);
                        bombs.Add(bomb);
                        entbs.Add(entb);
                    }
                }
                else
                {
                    int tempx = rnd.Next(0, 320);
                    int tempy = rnd.Next(-200, 221);
                    rx.Add(tempx);
                    ry.Add(tempy);
                    Rectangle rects = new Rectangle(tempx, tempy, 120, 15);
                    rectangles.Add(rects);
                    if (1 == randomcoin || 2 == randomcoin || 3 == randomcoin)
                    {
                        Rectangle coin = new Rectangle(tempx += 10, tempy -= 100, 50, 20);
                        coins.Add(coin);
                        entcs.Add(entc);
                    }
                    else if (3 == randomcoin)
                    {
                        Rectangle bomb = new Rectangle(tempx += 40, tempy -= 60, 50, 20);
                        bombs.Add(bomb);
                        entbs.Add(entb);
                    }
                }
                this.Invalidate();
                entc += 10;
                entb += 10;

            }
            else if (go == true && replay == true)
            {
                entc += 10;
                entb += 10;
                try
                {
                    if (entcs[entc1] == entc)
                    {
                        Rectangle coin = new Rectangle(rx[rep] -= 40, ry[rep] -= 250, 50, 20);
                        coins.Add(coin);
                        entc1 += 1;
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    if (entbs[entb1] == entb)
                    {
                        Rectangle bomb = new Rectangle(rx[rep] -= 10, ry[rep] -= 210, 50, 20);
                        bombs.Add(bomb);
                        entb1 += 1;
                    }
                }
                catch (Exception)
                {

                }
                try
                {
                    Rectangle rects = new Rectangle(rx[rep], ry[rep] += 50, 120, 15);
                    rectangles.Add(rects);
                    rep += 1;
                }
                catch (Exception)
                {

                }
                this.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\backsound.wav";
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

            sr = new StreamReader(Application.StartupPath + "/selected.txt");
            while (!sr.EndOfStream)
            {
                character = sr.ReadLine();
            }
            sr.Close();
            if (character == "0")
            {
                chr = new Bitmap(Resources.r);
            }
            else if (character == "1")
            {
                chr = new Bitmap(Resources.r1);
            }
            else if (character == "2")
            {
                chr = new Bitmap(Resources.r2);
            }
            label3.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            countdown = 4;
            platform.Start();
            platform.Interval = 1000;
            Rectangle rects = new Rectangle(140, 510, 200, 15);
            rectangles.Add(rects);
            rects = new Rectangle(60, 300, 200, 15);
            rectangles.Add(rects);
            rects = new Rectangle(180, 100, 200, 15);
            rectangles.Add(rects);
            coin = new Bitmap(Resources.c6);
            bomb = new Bitmap(Resources.bom);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            randomcoin = rnd.Next(1, 10);
            if (coinchange == 1)
            {
                coin = new Bitmap(Resources.c1);
                coinchange += 1;
            }
            else if (coinchange == 2)
            {
                coin = new Bitmap(Resources.c2);
                coinchange += 1;
            }
            else if (coinchange == 3)
            {
                coin = new Bitmap(Resources.c3);
                coinchange += 1;
            }
            else if (coinchange == 4)
            {
                coin = new Bitmap(Resources.c4);
                coinchange += 1;
            }
            else if (coinchange == 5)
            {
                coin = new Bitmap(Resources.c5);
                coinchange += 1;
            }
            else if (coinchange == 6)
            {
                coin = new Bitmap(Resources.c6);
                coinchange = 1;
            }
            this.Invalidate();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamReader sr = new StreamReader(Application.StartupPath + "/save1.txt");
            while (!sr.EndOfStream)
            {
                activeuser = sr.ReadLine();

            }
            sr.Close();
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select coin from [Table] where username = '" + activeuser + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                totalcoin += Convert.ToInt32(reader[0]);
            }
            conn.Close();
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + "\\dodoljump.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            conn.Open();
            cmd = new SqlCommand("update [table] set coin = '" + totalcoin + "'"+ " where username = '" + activeuser + "'", conn);
            reader = cmd.ExecuteReader();
            conn.Close();
            Menu formenu = new Menu();
            formenu.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            totalcoin = 0;
            replay = false;
            rx.Clear();
            ry.Clear();
            timepressed.Clear();
            entcs.Clear();
            entbs.Clear();
            px.Clear();
            rep = 0;
            timepress = 0;
            ttime = 0;
            playermove = 0;
            entc = 0;
            entb = 0;
            entc1 = 0;
            entb1 = 0;
            label3.Visible = false;
            go = false;
            label2.Text = "";
            label1.Text = "3";
            label3.Text = "X" + totalcoin;
            label1.Visible = true;
            rectangles.Clear();
            coins.Clear();
            bombs.Clear();
            xplayer = 130;
            yplayer = 380;
            n = 0;
            j = 0;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            timer1.Stop();
            timer2.Stop();
            countdown = 4;
            platform.Interval = 1000;
            Rectangle rects = new Rectangle(140, 510, 200, 15);
            rectangles.Add(rects);
            rects = new Rectangle(60, 300, 200, 15);
            rectangles.Add(rects);
            rects = new Rectangle(180, 100, 200, 15);
            rectangles.Add(rects);
            if (character == "0")
            {
                chr = new Bitmap(Resources.r);
            }
            else if (character == "1")
            {
                chr = new Bitmap(Resources.r1);
            }
            else if (character == "2")
            {
                chr = new Bitmap(Resources.r2);
            }
            platform.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            rep = 0;
            timepress = 0;
            ttime = 0;
            playermove = 0;
            entc = 0;
            entb = 0;
            entc1 = 0;
            entb1 = 0;
            replay = true;
            label3.Visible = false;
            totalcoin = 0;
            go = false;
            label2.Text = "";
            label1.Text = "3";
            label3.Text = "X" + totalcoin;
            label1.Visible = true;
            rectangles.Clear();
            coins.Clear();
            bombs.Clear();
            xplayer = 130;
            yplayer = 380;
            n = 0;
            j = 0;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            timer1.Stop();
            timer2.Stop();
            countdown = 4;
            platform.Interval = 1000;
            Rectangle rects = new Rectangle(140, 510, 200, 15);
            rectangles.Add(rects);
            rects = new Rectangle(60, 300, 200, 15);
            rectangles.Add(rects);
            rects = new Rectangle(180, 100, 200, 15);
            rectangles.Add(rects);
            if (character == "0")
            {
                chr = new Bitmap(Resources.r);
            }
            else if (character == "1")
            {
                chr = new Bitmap(Resources.r1);
            }
            else if (character == "2")
            {
                chr = new Bitmap(Resources.r2);
            }
            platform.Start();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
