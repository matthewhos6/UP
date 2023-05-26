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
    public partial class FormCopyright : Form
    {
        public FormCopyright()
        {
            InitializeComponent();
            this.BackColor = Color.DodgerBlue;
            this.TransparencyKey = Color.DodgerBlue;

            var pos1 = this.PointToScreen(label6.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            label6.Parent = pictureBox1;
            label6.Location = pos1;
            label6.BackColor = Color.Transparent;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Menu formmenu = new Menu();
            formmenu.Show();
            this.Close();
        }
    }
}
