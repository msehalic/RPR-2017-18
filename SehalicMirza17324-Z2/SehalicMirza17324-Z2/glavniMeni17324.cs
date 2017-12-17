using System;
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
        Zadaca1RPR_17324.KlinikaKontejner klinika17324 = new Zadaca1RPR_17324.KlinikaKontejner();
        public glavniMeni17324()
        {
            InitializeComponent();
        }

        private void glavniMeni17324_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.Text = "Klinika 'Dr. Sehalic'";
           if (checkBoxHitanSlucaj.Checked==false) groupBoxHitniSlucajevi.Enabled = false;
            if (radioButtonZiv.Checked == false) groupBoxZiv.Enabled = false;
            if (radioButtonMrtav.Checked == false) groupBoxMrtav.Enabled = false;
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
            textBoxMisljenjeDoktora_Validating(textBoxMisljenjeDoktora, new CancelEventArgs());
            textBoxPostupak_Validating(textBoxPostupak, new CancelEventArgs());
            textBoxTerapija_Validating(textBoxTerapija, new CancelEventArgs());
            textBoxUzrokSmrti_Validating(textBoxUzrokSmrti, new CancelEventArgs());
            groupBoxBracnoStanje_Validating(groupBoxBracnoStanje, new CancelEventArgs());
            groupBoxZivMrtav_Validating(groupBoxZivMrtav, new CancelEventArgs());
            //DODATI
            //SVE
            //KONTROLE
            //KOJE
            //TREBA
            //VALIDIRATI!
            if (errorProvider2.GetError(textBox1) == "" && errorProvider2.GetError(textBox2) == "" && errorProvider2.GetError(maskedTextBox1) == "" && errorProvider2.GetError(textBoxAdresa) == "" && errorProvider2.GetError(textBoxUzrokSmrti)=="" && errorProvider2.GetError(textBoxMisljenjeDoktora)=="" && errorProvider2.GetError(textBoxPostupak)=="" && errorProvider2.GetError(textBoxTerapija)=="" && errorProvider2.GetError(groupBoxZivMrtav)=="")
            {
                string bracnoStanjePacijenta = "";

                if (radioButtonUdovac.Checked) bracnoStanjePacijenta = radioButtonUdovac.Text;
                else if (radioButtonRazveden.Checked) bracnoStanjePacijenta = radioButtonRazveden.Text;
                else if (radioButtonOzenjen.Checked) bracnoStanjePacijenta = radioButtonOzenjen.Text;
                else if (radioButtonNeozenjen.Checked) bracnoStanjePacijenta = radioButtonNeozenjen.Text;
                bool greska = false;
                string pogresniMaticniBroj="";
                char pol = 'M';
                if (radioButtonZ.Checked) pol = 'Z';
                Zadaca1RPR_17324.Pacijent p = new Zadaca1RPR_17324.Pacijent(textBox1.Text, textBox2.Text, textBoxAdresa.Text, bracnoStanjePacijenta, dateTimePicker1.Value.Date, pol, Convert.ToUInt64(maskedTextBox1.Text));
                foreach (Zadaca1RPR_17324.Pacijent pacijent17324 in klinika17324.Pacijenti)
                {
                    if (pacijent17324.MaticniBroj == Convert.ToUInt64(maskedTextBox1.Text))
                    {
                        textBoxInfo.Text = "Vec postoji pacijent sa identicnim JMBG kao " + textBox1.Text + " " + textBox2.Text;
                        textBoxInfo.ForeColor = Color.Red;
                        greska = true;
                        pogresniMaticniBroj = maskedTextBox1.Text;
                    }
                }
                if (maskedTextBox1.Text!=pogresniMaticniBroj) greska = false;
                if (greska == false)
                {
                    klinika17324.Pacijenti.Add(p);
                    klinika17324.UnosPodataka(p, checkBoxDermatolog.Checked, checkBoxKardiolog.Checked, checkBoxOrtoped.Checked, checkBoxStomatolog.Checked);
                    textBoxInfo.Text = "Uspjesno dodan pacijent " + p.Ime + " " + p.Prezime;
                    textBoxInfo.ForeColor = Color.Green; //malo lijepog dizajna
                }
                //TREBA JOS U SETTERE DODATI 
                //VALIDACIJU
                //OBAVEZNO
            }
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
                toolStripStatusLabel2.Text = "Unijeli ste praznu adresu!";
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

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBoxAdresa.Text = "";
            maskedTextBox1.Text = "";
            textBoxInfo.Text = "";
            userControlUnosSlike1.Resetiraj();
            checkBoxDermatolog.Checked = false;
            checkBoxKardiolog.Checked = false;
            checkBoxOrtoped.Checked = false;
            checkBoxStomatolog.Checked = false;
            checkBoxHitanSlucaj.Checked = false;
            textBoxUzrokSmrti.Text = "";
            textBoxPostupak.Text = "";
            textBoxMisljenjeDoktora.Text = "";
            textBoxTerapija.Text = "";
            radioButtonZiv.Checked = false;
            radioButtonMrtav.Checked = false;
            checkBoxObdukcija.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            userControlUnosSlike1 = new KontrolaZaUnosSlike.UserControlUnosSlike();
            errorProvider2.Clear();
        }

        private void groupBoxUnosPacijenata_Enter(object sender, EventArgs e)
        {

        }

        private void checkBoxHitanSlucaj_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxHitniSlucajevi.Enabled = checkBoxHitanSlucaj.Checked;
        }


        private void checkBoxZiv_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxZiv.Enabled = radioButtonZiv.Checked;
        }

        private void checkBoxMrtav_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxMrtav.Enabled = radioButtonMrtav.Checked;
        }

        private void groupBoxMrtav_Enter(object sender, EventArgs e)
        {
            groupBoxObdukcija.Enabled = false;
        }

        private void checkBoxObdukcija_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxObdukcija.Enabled = checkBoxObdukcija.Checked;
        }

        private void groupBoxBracnoStanje_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxBracnoStanje_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonNeozenjen.Checked == false && radioButtonOzenjen.Checked == false && radioButtonRazveden.Checked == false && radioButtonUdovac.Checked == false)
            {
                this.errorProvider2.SetError(groupBoxBracnoStanje, "Niste odabrali bračno stanje!");
                toolStripStatusLabel2.Text = "Niste odabrali bračno stanje!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void groupBoxBracnoStanje_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(groupBoxBracnoStanje, "");
        }

        private void groupBoxZivMrtav_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonMrtav.Checked==false && radioButtonZiv.Checked==false && checkBoxHitanSlucaj.Checked==true)
            {
                this.errorProvider2.SetError(groupBoxZivMrtav, "Niste odabrali životni status pacijenta!");
                toolStripStatusLabel2.Text = "Niste odabrali životni status pacijenta!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void groupBoxZivMrtav_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(groupBoxZivMrtav, "");
        }

        private void textBoxPostupak_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonZiv.Checked==true && textBoxPostupak.Text.Length==0)
            {
                this.errorProvider2.SetError(textBoxPostupak, "Niste unijeli detalje o postupku pregleda hitnog pacijenta!");
                toolStripStatusLabel2.Text = "Niste unijeli detalje o postupku pregleda hitnog pacijenta!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxPostupak_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(textBoxPostupak, "");
        }


        private void textBoxTerapija_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(textBoxTerapija, "");
        }

        private void textBoxTerapija_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonZiv.Checked == true && textBoxTerapija.Text.Length == 0)
            {
                this.errorProvider2.SetError(textBoxTerapija, "Niste unijeli detalje o terapiji hitnog pacijenta!");
                toolStripStatusLabel2.Text = "Niste unijeli detalje o terapiji hitnog pacijenta!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxMisljenjeDoktora_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonZiv.Checked == true && textBoxMisljenjeDoktora.Text.Length == 0)
            {
                this.errorProvider2.SetError(textBoxMisljenjeDoktora, "Niste unijeli detalje o misljenju doktora nakon pregleda hitnog pacijenta!");
                toolStripStatusLabel2.Text = "Niste unijeli detalje o misljenju doktora nakon pregleda hitnog pacijenta!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxMisljenjeDoktora_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(textBoxMisljenjeDoktora, "");
        }

        private void textBoxUzrokSmrti_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonMrtav.Checked == true && textBoxMisljenjeDoktora.Text.Length == 0)
            {
                this.errorProvider2.SetError(textBoxUzrokSmrti, "Niste unijeli detalje o uzroku smrti hitnog pacijenta!");
                toolStripStatusLabel2.Text = "Niste unijeli detalje o uzroku smrti hitnog pacijenta!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxUzrokSmrti_Validated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            errorProvider2.SetError(textBoxUzrokSmrti, "");
        }

        private void radioButtonZiv_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxZiv.Enabled = radioButtonZiv.Checked;
            textBoxMisljenjeDoktora_Validated(sender, e);
            textBoxTerapija_Validated(sender, e);
            textBoxPostupak_Validated(sender, e);
        }

        private void radioButtonMrtav_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxMrtav.Enabled = radioButtonMrtav.Checked;
            textBoxUzrokSmrti_Validated(sender, e);
        }

        private void groupBoxHitniSlucajevi_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listBoxPretragaImePrezime.Items.Clear();
            if (textBoxBrisanjeImePrezime.Text.Length!=0) //ne zelimo izlistavati na prazno
            foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
            {
                if ((p.Ime + " " + p.Prezime).IndexOf(textBoxBrisanjeImePrezime.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    listBoxPretragaImePrezime.Items.Add(p);
                }
            }
        }

        private void textBoxBrisanjeJMBG_TextChanged(object sender, EventArgs e)
        {
            listBoxBrisanjeJMBG.Items.Clear();
            if (textBoxBrisanjeJMBG.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    if ((p.MaticniBroj).ToString().IndexOf(textBoxBrisanjeJMBG.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxBrisanjeJMBG.Items.Add(p);
                    }
                }
        }

        private void textBoxImeRasporedPregleda_TextChanged(object sender, EventArgs e)
        {
            listBoxPretragaRaspored.Items.Clear();
            if (textBoxImeRasporedPregleda.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    if ((p.Ime + " " + p.Prezime).IndexOf(textBoxImeRasporedPregleda.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxPretragaRaspored.Items.Add(p);
                    }
                }
        }
    }
}
