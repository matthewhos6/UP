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
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
            this.BackColor = Color.DodgerBlue;
            this.TransparencyKey = Color.DodgerBlue;

            var pos1 = this.PointToScreen(label1.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label1.Parent = pictureBox1;
            label1.Location = pos1;
            label1.BackColor = Color.Transparent;
        }

        private void Tutorial_Load(object sender, EventArgs e)
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
