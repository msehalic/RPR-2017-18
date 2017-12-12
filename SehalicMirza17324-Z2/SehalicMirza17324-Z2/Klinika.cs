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
using System.Security.Cryptography;
using Zadaca1RPR_17324;
using Doktori;
namespace SehalicMirza17324_Z2
{
    public partial class Klinika : Form
    {
        Zadaca1RPR_17324.KlinikaKontejner klinika17324 = new Zadaca1RPR_17324.KlinikaKontejner();
        public Klinika()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
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
            toolStripStatusLabel1.Text = "";
            errorProvider1.SetError(textBoxUnosSifre, "");
            this.textboxUnosImena.Text = "";
            this.textBoxUnosSifre.Text = "";
        }
        private void buttonPrijava_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(textBoxUnosSifre) == "")
            {
                glavniMeni17324 glavniMeni17324 = new glavniMeni17324();
                this.Hide();
                glavniMeni17324.Show();
            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void textBoxUnosSifre_Validating(object sender, CancelEventArgs e)
        {
            bool ispravan = false;
            foreach (Uposlenik u in klinika17324.uposlenici) if (u.KorisnickoIme == textboxUnosImena.Text && VerifyMd5Hash(MD5.Create(), textBoxUnosSifre.Text, u.Lozinka))
                {
                    ispravan = true;
                }
            if (textBoxUnosSifre.Text == "") ispravan = false; // prazan string
            if (!ispravan)
            {
                //e.Cancel = true; //ova metoda je previse zla
                textBoxUnosSifre.Select(0, textBoxUnosSifre.Text.Length);
                this.errorProvider1.SetError(textBoxUnosSifre, "Neispravna sifra!");
                toolStripStatusLabel1.Text = "Neispravna sifra!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
           // if (buttonOdustani_Click) e.Cancel = false;
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBoxUnosSifre, "");
            toolStripStatusLabel1.Text = "";
        }

        private void Klinika_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            Application.Exit();
        }

        private void textBoxUnosSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBoxUnosSifre_Validating(textBoxUnosSifre, new CancelEventArgs());
                buttonPrijava_Click(buttonPrijava, new EventArgs());
            }
        }

        private void textBoxUnosSifre_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            errorProvider1.SetError(textBoxUnosSifre, "");
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
