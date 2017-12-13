﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SehalicMirza17324_Z2
{
    public partial class glavniMeni17324 : Form
    {
        public glavniMeni17324()
        {
            InitializeComponent();
        }

        private void glavniMeni17324_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.Text = "Klinika 'Dr. Sehalic'";
        }
        private void Izadji(object sender, EventArgs e)
        {
            this.Close();
        }

        private void glavniMeni17324_FormClosed(object sender, FormClosedEventArgs e)
        {
            Klinika klinika17324 = new Klinika();
            klinika17324.Show();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_Validated(object sender, EventArgs e)
        {
            errorProvider2.SetError(maskedTextBox1, "");
            toolStripStatusLabel2.Text = "";
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!(maskedTextBox1.Text.Length == 13))
            {
                maskedTextBox1.Select(0, maskedTextBox1.Text.Length);
                this.errorProvider2.SetError(maskedTextBox1, "Neispravan maticni broj!");
                toolStripStatusLabel2.Text = "Neispravan maticni broj!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
            else
            {
                //provjerimo sada prvi dio maticnog broja
                string datumUString = dateTimePicker1.Value.Date.ToString("ddMMyyyy");
                datumUString = datumUString.Remove(4, 1); //cifra hiljadica godine rodjenja
                string maticniUString = maskedTextBox1.Text.Substring(0, maskedTextBox1.Text.Length - 6); //skratimo 6 posljednjih cifara
                if (datumUString.Equals(maticniUString) == false)
                {
                    maskedTextBox1.Select(0, maskedTextBox1.Text.Length);
                    this.errorProvider2.SetError(maskedTextBox1, "Neispravan maticni broj!");
                    toolStripStatusLabel2.Text = "Neispravan maticni broj!";
                    toolStripStatusLabel2.ForeColor = Color.Red;
                }
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(maskedTextBox1, "");
        }


        private void textBox1_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(textBox1, "");
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(textBox2, "");
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                textBox1.Select(0, textBox1.Text.Length);
                this.errorProvider2.SetError(textBox1, "Unijeli ste prazno ime!");
                toolStripStatusLabel2.Text = "Unijeli ste prazno ime!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                textBox2.Select(0, textBox2.Text.Length);
                this.errorProvider2.SetError(textBox2, "Unijeli ste prazno prezime!");
                toolStripStatusLabel2.Text = "Unijeli ste prazno prezime!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_Validating(textBox1, new CancelEventArgs());
            textBox2_Validating(textBox2, new CancelEventArgs());
            maskedTextBox1_Validating(maskedTextBox1, new CancelEventArgs());
            textBoxAdresa_Validating(textBoxAdresa, new CancelEventArgs());
            //DODATI
            //SVE
            //KONTROLE
            //KOJE
            //TREBA
            //VALIDIRATI!
        }

        private void groupBoxBrisanjePacijenata_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxAdresa_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxAdresa.Text.Equals(""))
            {
                textBoxAdresa.Select(0, textBoxAdresa.Text.Length);
                this.errorProvider2.SetError(textBoxAdresa, "Unijeli ste praznu adresu!");
                toolStripStatusLabel2.Text = "Unijeli ste prazno prezime!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxAdresa_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(textBoxAdresa, "");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
