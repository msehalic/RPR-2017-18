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
using System.Drawing.Text;
using System.Threading;
using System.Reflection;

namespace SehalicMirza17324_Z2
{
    public partial class Klinika : Form
    {
        Zadaca1RPR_17324.KlinikaKontejner klinika17324 = new Zadaca1RPR_17324.KlinikaKontejner();
        Zadaca1RPR_17324.Pacijent pacijent17324_1 = new Pacijent();
        bool JePacijent = false;
        Uposlenik uposlenik17324_1 = new Uposlenik();
        public Klinika()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.Text = "Klinika 'Dr. Sehalic'";
            Z4_Zadatak2_Pretraga z2 = new Z4_Zadatak2_Pretraga();
            z2.Show();
        }
        Rectangle rect = new Rectangle(60, 40, 60, 100);
        Rectangle rect1 = new Rectangle(40, 60, 100, 60);
        static int brojac = 0;
        private void AnimirajPuls()
        {
            brojac++;
            if (brojac % 2 == 0)
            {
                rect.Inflate(3, 5); //malo animacije
                rect1.Inflate(5, 3);
            }
            else
            {
                rect = new Rectangle(60, 40, 60, 100);
                rect1 = new Rectangle(40, 60, 100, 60);
            }
        }

        private void RefreshTimer(object o)
        {
            AnimirajPuls();
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //logo
            Graphics g = e.Graphics;
            Thread t;
            HatchBrush myHatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.White, Color.Red);
            g.SmoothingMode = SmoothingMode.AntiAlias; //da bude ljepse
            Pen pen = new Pen(Color.White, 40);
            g.DrawEllipse(pen, rect1);
            g.DrawArc(pen, 50, 50, 80, 80, 90, 360);
            if (brojac%2!=0) //malo promjene boja kod reloada
            myHatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.Red, Color.White);
            LinearGradientBrush lBrush = new LinearGradientBrush(rect, Color.Red, Color.MintCream, LinearGradientMode.BackwardDiagonal);
            g.FillRectangle(myHatchBrush, rect);
            g.FillRectangle(myHatchBrush, rect1);
            Font fnt = new Font("Book Antiqua", 12);
            g.TextRenderingHint = TextRenderingHint.AntiAlias; //da bude ljepse
            g.DrawString("Klinika", fnt, new SolidBrush(Color.IndianRed), 57, 150);
            g.DrawString("Dr 'Šehalić'", fnt, new SolidBrush(Color.IndianRed), 42, 170);
            t = (new Thread(() =>
            {
                AnimirajPuls();
                System.Threading.Timer mTimer = new System.Threading.Timer(RefreshTimer, null, 1000, 1000);
            }));
                t.Start();
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
                if (JePacijent)
                {
                    glavniMeni17324 glavniMeni17324 = new glavniMeni17324(pacijent17324_1);
                    this.Hide();
                    glavniMeni17324.Show();
                }
                else
                {
                    glavniMeni17324 glavniMeni17324 = new glavniMeni17324(uposlenik17324_1);
                    this.Hide();
                    glavniMeni17324.Show();
                }
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
            foreach (Uposlenik u in klinika17324.Uposlenici) if (u.KorisnickoIme == textboxUnosImena.Text && VerifyMd5Hash(MD5.Create(), textBoxUnosSifre.Text, u.Lozinka))
                {
                    uposlenik17324_1 = u;
                    ispravan = true;
                    break;
                }
            foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
            {
                if (p.KorisnickoIme == textboxUnosImena.Text && VerifyMd5Hash(MD5.Create(), textBoxUnosSifre.Text, p.Lozinka))
                {
                    pacijent17324_1 = p;
                    ispravan = true;
                    JePacijent = true;
                    break;
                }
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
