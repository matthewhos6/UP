using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 130;
        int y = 260;
        int n = 0;
        int j = 0;
        int xp = 130;
        int yp = 350;
        Random rnd = new Random();
        List<Rectangle> rectangles = new List<Rectangle>();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brushy = new SolidBrush(Color.Yellow);
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(x, y, 30, 30);
            g.FillRectangle(brushy, rect);
            SolidBrush brushBlack = new SolidBrush(Color.Black);
            Rectangle rects = new Rectangle(xp, yp, 120, 30);
            g.FillRectangle(brushBlack, rects);
            rectangles.Add(rects);
            int z = 0;
            foreach (var i in rectangles)
            {
                g.FillRectangle(brushBlack, rectangles[z]);
                if (rect.IntersectsWith(rectangles[z]))
                {
                    timer1.Start();
                    j = 0;
                    timer2.Stop();
                }
                z += 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (n <= 10)
            {
                y -= 7;
                n += 1;

            }
            else if (n >= 10 && n <= 20)
            {
                y -= 4;
                n += 1;
            }
            else if (n >= 20 && n <= 30)
            {
                y -= 2;
                n += 1;
            }
            else if (n >= 30 && n <= 41)
            {
                y -= 1;
                n += 1;
            }
            else if (n >= 40)
            {
                SolidBrush brushBlack = new SolidBrush(Color.Black);
                xp = rnd.Next(0,284);
                yp = rnd.Next(42,421);
                Rectangle rects = new Rectangle(xp, yp, 120, 30);
                rectangles.Add(rects);
                timer2.Start();
                n = 0;
                timer1.Stop();
            }
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                if (x > 250)
                {
                    x -= 300;
                }
                else
                {
                    x += 25;
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (x < 1)
                {
                    x += 300;
                }
                else
                {
                    x -= 25;
                }
            }         
            this.Invalidate();
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (j <= 10)
            {
                y += 1;
                j += 1;
            }
            else if (j >= 10 && j <= 20)
            {
                y += 2;
                j += 1;
            }
            else if (j >= 20 && j <= 30)
            {
                y += 4;
                j += 1;
            }
            else if (j >= 30)
            {
                y += 7;
                j += 1;
            }
            this.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button1.Hide();
        }
    }
}
