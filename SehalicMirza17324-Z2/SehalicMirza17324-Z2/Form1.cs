using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace SehalicMirza17324_Z2
{
    public partial class Klinika : Form
    {
        public Klinika()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = "Klinika 'Dr. Sehalic'";

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(40, 80, 100, 100);
            Pen pen = new Pen(Color.RosyBrown, 40);
            g.DrawEllipse(pen, rect);
            LinearGradientBrush lBrush = new LinearGradientBrush(rect, Color.Red, Color.MintCream, LinearGradientMode.BackwardDiagonal);
            g.FillRectangle(lBrush, rect);
            Font fnt = new Font("Verdana", 12);
            g.DrawString("Klinika", fnt, new SolidBrush(Color.GhostWhite), 57, 110);
            g.DrawString("Dr 'Šehalić'", fnt, new SolidBrush(Color.GhostWhite), 42, 130);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            this.textboxUnosImena.Text = "";
            this.textBoxUnosSifre.Text = "";
        }
    }
}
