using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doktori;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SehalicMirza17324_Z2
{
    public partial class glavniMeni17324 : Form
    {
        Zadaca1RPR_17324.KlinikaKontejner klinika17324 = new Zadaca1RPR_17324.KlinikaKontejner();
        Uposlenik uposlenik17324_1 = new Uposlenik();
        public glavniMeni17324(Uposlenik u)
        {
            uposlenik17324_1 = u;
            InitializeComponent();
          //  toolStripStatusLabel1.Text = "Dobro došli " + u.ImeUposlenika + " " + u.PrezimeUposlenika;
            if (u is Tehnicar)
            {
                ((Control)this.tabPageRegistracijaPregleda).Enabled = false; //tehnicari ne smiju moci registrovati preglede
                this.tabPageRegistracijaPregleda.Dispose();
                labelGreskaUPristupu.Text = "Nemate privilegije za pristup ovom modulu!";

                ((Control)this.tabPagePretragaKartona).Enabled = false; //tehnicari ne smiju moci pretrazivati karton
                this.tabPagePretragaKartona.Dispose();
                labelGreskaUPristupu.Text = "Nemate privilegije za pristup ovom modulu!";
            }
        }

        private void glavniMeni17324_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.Text = "Klinika 'Dr. Sehalic'";
            if (checkBoxHitanSlucaj.Checked == false) groupBoxHitniSlucajevi.Enabled = false;
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
            else if (textBox1.Text.Any(char.IsDigit))
            {
                textBox1.Select(0, textBox1.Text.Length);
                this.errorProvider2.SetError(textBox1, "Unijeli ste broj u polje za ime!");
                toolStripStatusLabel2.Text = "Unijeli ste broj u polje za ime!";
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
            else if (textBox2.Text.Any(char.IsDigit))
            {
                textBox2.Select(0, textBox2.Text.Length);
                this.errorProvider2.SetError(textBox2, "Unijeli ste broj u polje za prezime!");
                toolStripStatusLabel2.Text = "Unijeli ste broj u polje za prezime!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1_Validating(textBox1, new CancelEventArgs());
            textBox2_Validating(textBox2, new CancelEventArgs());
            userControlUnosSlike1_Validating(userControlUnosSlike1, new CancelEventArgs());
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
            if (errorProvider2.GetError(userControlUnosSlike1) == "" && errorProvider2.GetError(textBox1) == "" && errorProvider2.GetError(textBox2) == "" && errorProvider2.GetError(maskedTextBox1) == "" && errorProvider2.GetError(textBoxAdresa) == "" && errorProvider2.GetError(textBoxUzrokSmrti) == "" && errorProvider2.GetError(textBoxMisljenjeDoktora) == "" && errorProvider2.GetError(textBoxPostupak) == "" && errorProvider2.GetError(textBoxTerapija) == "" && errorProvider2.GetError(groupBoxZivMrtav) == "")
            {
                string bracnoStanjePacijenta = "";

                if (radioButtonUdovac.Checked) bracnoStanjePacijenta = radioButtonUdovac.Text;
                else if (radioButtonRazveden.Checked) bracnoStanjePacijenta = radioButtonRazveden.Text;
                else if (radioButtonOzenjen.Checked) bracnoStanjePacijenta = radioButtonOzenjen.Text;
                else if (radioButtonNeozenjen.Checked) bracnoStanjePacijenta = radioButtonNeozenjen.Text;
                bool greska = false;
                string pogresniMaticniBroj = "";
                char pol = 'M';
                if (radioButtonZ.Checked) pol = 'Z';
                Zadaca1RPR_17324.Pacijent p = new Zadaca1RPR_17324.Pacijent(textBox1.Text, textBox2.Text, textBoxAdresa.Text, bracnoStanjePacijenta, dateTimePicker1.Value.Date, pol, Convert.ToUInt64(maskedTextBox1.Text));
                foreach (Zadaca1RPR_17324.Pacijent pacijent17324 in klinika17324.Pacijenti)
                {
                    if (pacijent17324.MaticniBroj == Convert.ToUInt64(maskedTextBox1.Text))
                    {
                        toolStripStatusLabel2.Text = "Vec postoji pacijent sa identicnim JMBG kao " + textBox1.Text + " " + textBox2.Text;
                        toolStripStatusLabel2.ForeColor = Color.Red;
                        greska = true;
                        pogresniMaticniBroj = maskedTextBox1.Text;
                    }
                }
                if (maskedTextBox1.Text != pogresniMaticniBroj) greska = false;
                if (greska == false)
                {
                    klinika17324.Pacijenti.Add(p);
                    klinika17324.UnosPodataka(p, checkBoxDermatolog.Checked, checkBoxKardiolog.Checked, checkBoxOrtoped.Checked, checkBoxStomatolog.Checked);
                    toolStripStatusLabel2.Text = "Uspjesno dodan pacijent " + p.Ime + " " + p.Prezime;
                    toolStripStatusLabel2.ForeColor = Color.Green; //malo lijepog dizajna
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
            toolStripStatusLabel2.Text = "";
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
            if (radioButtonMrtav.Checked == false && radioButtonZiv.Checked == false && checkBoxHitanSlucaj.Checked == true)
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
            if (radioButtonZiv.Checked == true && textBoxPostupak.Text.Length == 0)
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
            if (radioButtonMrtav.Checked == true && textBoxUzrokSmrti.Text.Length == 0)
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
            if (textBoxBrisanjeImePrezime.Text.Length != 0) //ne zelimo izlistavati na prazno
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

        //OPCIJA 2

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

        private void listBoxPretragaRaspored_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxPretragaRaspored_SelectedValueChanged(object sender, EventArgs e)
        {
            labelDermatolog.Text = "";
            labelOrtoped.Text = "";
            labelStomatolog.Text = "";
            labelKardiolog.Text = "";
            foreach (Zadaca1RPR_17324.Ordinacija o in klinika17324.Ordinacije)
            {
                foreach (Zadaca1RPR_17324.Pregled pr in o.RedCekanja)
                {
                    if (pr.P == listBoxPretragaRaspored.SelectedItem)
                    {
                        //stomatolog
                        if (o.NazivKlinike == "stomatolog")
                        {
                            labelStomatolog.Text = "Pacijent " + pr.P.ToString() + " \n" + "U ordinaciji stomatologa je " + (o.RedCekanja.ToList().IndexOf(pr) + 1) + "/" + o.RedCekanja.Count + " u redu cekanja.";
                            if (o.RedCekanja.ToList().IndexOf(pr) == 0) labelStomatolog.Text += " Doktor je spreman da primi pacijenta.";                        //ortoped
                        }
                        //ortoped
                        if (o.NazivKlinike == "ortoped")
                        {
                            labelOrtoped.Text = "Pacijent " + pr.P.ToString() + " \n" + "U ordinaciji ortopeda je " + (o.RedCekanja.ToList().IndexOf(pr) + 1) + "/" + o.RedCekanja.Count + " u redu cekanja.";
                            if (o.RedCekanja.ToList().IndexOf(pr) == 0) labelOrtoped.Text += " Doktor je spreman da primi pacijenta.";                        //kardiolog
                        }
                        //kardiolog
                        if (o.NazivKlinike == "kardiolog")
                        {
                            labelKardiolog.Text = "Pacijent " + pr.P.ToString() + " \n" + "U ordinaciji kardiologa je " + (o.RedCekanja.ToList().IndexOf(pr) + 1) + "/" + o.RedCekanja.Count + " u redu cekanja.";
                            if (o.RedCekanja.ToList().IndexOf(pr) == 0) labelKardiolog.Text += " Doktor je spreman da primi pacijenta.";                        //dermatolog
                        }
                        //ortoped
                        if (o.NazivKlinike == "dermatolog")
                        {
                            labelDermatolog.Text = "Pacijent " + pr.P.ToString() + " \n" + "U ordinaciji dermatologa je " + (o.RedCekanja.ToList().IndexOf(pr) + 1) + "/" + o.RedCekanja.Count + " u redu cekanja.";
                            if (o.RedCekanja.ToList().IndexOf(pr) == 0) labelDermatolog.Text += " Doktor je spreman da primi pacijenta.";
                        }
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBoxKarton_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKreiranjeKartona_TextChanged(object sender, EventArgs e)
        {
            listBoxKarton.Items.Clear();
            if (textBoxKreiranjeKartona.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    if ((p.Ime + " " + p.Prezime).IndexOf(textBoxKreiranjeKartona.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxKarton.Items.Add(p);
                    }
                }

        }

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            textBoxKreiranjeKartona.Text = "";
            radioButtonPusac.Checked = false;
            radioButtonNepusac.Checked = false;
            radioButtonNealkoholicar.Checked = false;
            radioButtonAlkoholicar.Checked = false;
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                this.errorProvider2.SetError(richTextBox1, "Niste unijeli detalje o nasljednim bolestima u porodici!");
                toolStripStatusLabel2.Text = "Niste unijeli detalje o nasljednim bolestima u porodici!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void richTextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                this.errorProvider2.SetError(richTextBox2, "Niste unijeli detalje o alergijama!");
                toolStripStatusLabel2.Text = "Niste unijeli detalje o alergijama!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void richTextBox1_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(richTextBox1, "");
            toolStripStatusLabel2.Text = "";
        }

        private void richTextBox2_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(richTextBox2, "");
            toolStripStatusLabel2.Text = "";
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonKreiraj_Click(object sender, EventArgs e)
        {
            richTextBox1_Validating(sender, new CancelEventArgs());
            richTextBox2_Validating(sender, new CancelEventArgs());
            textBoxKreiranjeKartona_Validating(sender, new CancelEventArgs());
            groupBoxAlkoholicar_Validating(sender, new CancelEventArgs());
            groupBoxPusac_Validating(sender, new CancelEventArgs());
            listBoxKarton_Validating(sender, new CancelEventArgs());
            if (errorProvider2.GetError(richTextBox1) == "" && errorProvider2.GetError(richTextBox2) == "" && errorProvider2.GetError(groupBoxAlkoholicar) == "" && errorProvider2.GetError(groupBoxPusac) == "" && errorProvider2.GetError(listBoxKarton) == "" && errorProvider2.GetError(textBoxKreiranjeKartona) == "")
            {
                Zadaca1RPR_17324.Pacijent pacijent17324_1 = (Zadaca1RPR_17324.Pacijent)listBoxKarton.SelectedItem;
                this.errorProvider2.SetError(listBoxKarton, "");
                toolStripStatusLabel2.Text = "Karton pacijenta " + pacijent17324_1.Ime + " " + pacijent17324_1.Prezime + " uspjesno kreiran!";
                toolStripStatusLabel2.ForeColor = Color.Green;
                pacijent17324_1.alergije = richTextBox2.Text;
                pacijent17324_1.historijaBolestiuPorodici = richTextBox1.Text;
                pacijent17324_1.IspravanKarton = true;
                pacijent17324_1.alkoholicar = (radioButtonAlkoholicar.Checked);
                pacijent17324_1.pusac = (radioButtonPusac.Checked);
            }

        }

        private void textBoxKreiranjeKartona_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxKreiranjeKartona.Text == "")
            {
                this.errorProvider2.SetError(textBoxKreiranjeKartona, "Niste unijeli ime i prezime pacijenta kojem se kreira karton!");
                toolStripStatusLabel2.Text = "Niste unijeli ime i prezime pacijenta kojem se kreira karton!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxKreiranjeKartona_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(textBoxKreiranjeKartona, "");
            toolStripStatusLabel2.Text = "";
        }

        private void groupBoxPusac_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonPusac.Checked == false && radioButtonNepusac.Checked == false)
            {
                this.errorProvider2.SetError(groupBoxPusac, "Niste odabrali da li je pacijent pusac!");
                toolStripStatusLabel2.Text = "Niste odabrali da li je pacijent pusac!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void groupBoxAlkoholicar_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonAlkoholicar.Checked == false && radioButtonNealkoholicar.Checked == false)
            {
                this.errorProvider2.SetError(groupBoxAlkoholicar, "Niste odabrali da li je pacijent alkoholicar!");
                toolStripStatusLabel2.Text = "Niste odabrali da li je pacijent alkoholicar!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void listBoxKarton_Validating(object sender, CancelEventArgs e)
        {
            if (listBoxKarton.SelectedIndex == -1)
            {
                this.errorProvider2.SetError(listBoxKarton, "Niste izabrali pacijenta iz liste!");
                toolStripStatusLabel2.Text = "Niste izabrali pacijenta iz liste!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }

        }

        private void listBoxKarton_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(listBoxKarton, "");
            toolStripStatusLabel2.Text = "";
        }

        private void groupBoxPusac_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(groupBoxPusac, "");
            toolStripStatusLabel2.Text = "";

        }

        private void groupBoxAlkoholicar_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(groupBoxAlkoholicar, "");
            toolStripStatusLabel2.Text = "";
        }

        private void userControlUnosSlike1_Load(object sender, EventArgs e)
        {

        }

        private void userControlUnosSlike1_Validating(object sender, CancelEventArgs e)
        {
            if (!userControlUnosSlike1.ispravanDatum)
            {
                this.errorProvider2.SetError(userControlUnosSlike1, "Datum slike ne smije biti stariji od 6 mjeseci!");
                toolStripStatusLabel2.Text = "Datum slike ne smije biti stariji od 6 mjeseci!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
            if (userControlUnosSlike1.vratiSliku.Image == null)
            {
                this.errorProvider2.SetError(userControlUnosSlike1, "Niste odabrali sliku!");
                toolStripStatusLabel2.Text = "Niste odabrali sliku!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void userControlUnosSlike1_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(userControlUnosSlike1, "");
            toolStripStatusLabel2.Text = "";
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            listBoxPretraga.Items.Clear();
            if (textBoxPretragaKartona.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    //izlistaj akko ima ispravan karton
                    if (p.IspravanKarton == true && (p.Ime + " " + p.Prezime).IndexOf(textBoxPretragaKartona.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxPretraga.Items.Add(p);
                    }
                }
        }

        private void textBoxRegistracijaPregleda_TextChanged(object sender, EventArgs e)
        {
            listBoxRegistracijaPregleda.Items.Clear();
            if (textBoxRegistracijaPregleda.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    //izlistaj akko ima ispravan karton
                    if (p.IspravanKarton == true && (p.Ime + " " + p.Prezime).IndexOf(textBoxRegistracijaPregleda.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxRegistracijaPregleda.Items.Add(p);
                    }
                }
        }

        private void tabPageRegistracijaPregleda_Click(object sender, EventArgs e)
        {

        }

        private void tabPageAnaliza_Paint(object sender, PaintEventArgs e)
        {
            //pusaci
            int sumaPusaca = 0;
            var procenatPusaca = 0;
            foreach (Zadaca1RPR_17324.Pacijent pacijent17324 in klinika17324.Pacijenti)
            {
                if (pacijent17324.pusac) sumaPusaca++;
            }
            sumaPusaca *= 100;
            if (klinika17324.Pacijenti.Count != 0)
            {
                procenatPusaca = sumaPusaca / klinika17324.Pacijenti.Count;
            }
            labelUkupnoPacijenata.Text = "Ukupno pacijenata: " + klinika17324.Pacijenti.Count;
            labelPusaci.Text = "Pušača: " + sumaPusaca / 100 + " (" + procenatPusaca + "%)";
            labelNepusaci.Text = "Nepušača: " + (klinika17324.Pacijenti.Count - sumaPusaca / 100) + " (" + (100 - procenatPusaca) + "%)";
            Rectangle rect = new Rectangle(250, 150, 200, 200);
            ArrayList sliceList = new ArrayList();
            Color curClr = Color.Black;
            int[] valArray = { procenatPusaca, 100 - procenatPusaca };
            Color[] clrArray = { Color.Red, Color.Green, Color.Yellow, Color.Pink, Color.Aqua };
            int total = 0;
            Bitmap curBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(curBitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float angle = 0;
            float sweep = 0;
            //Total
            for (int i = 0; i < valArray.Length; i++)
            {
                total += valArray[i];
            }
            for (int i = 0; i < valArray.Length; i++)
            {
                int val = valArray[i];
                Color clr = clrArray[i];
                sweep = 360f * val / total;

                SolidBrush brush = new SolidBrush(clr);
                g.FillPie(brush, 20.0f, 20.0f, 200, 200, angle, sweep);
                angle += sweep;
            }
            pictureBox1.Image = curBitmap;

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            //alkoholicari
            int sumaAlkoholicara = 0;
            var procenatAlkoholicara = 0;
            foreach (Zadaca1RPR_17324.Pacijent pacijent17324 in klinika17324.Pacijenti)
            {
                if (pacijent17324.alkoholicar) sumaAlkoholicara++;
            }
            sumaAlkoholicara *= 100;
            if (klinika17324.Pacijenti.Count != 0)
            {
                procenatAlkoholicara = sumaAlkoholicara / klinika17324.Pacijenti.Count;
            }
            labelBrojPacijenata.Text = "Ukupno pacijenata: " + klinika17324.Pacijenti.Count;
            labelAlkoholicar.Text = "Alkoholičara: " + sumaAlkoholicara / 100 + " (" + procenatAlkoholicara + "%)";
            labelNealkoholicar.Text = "Nealkoholičara: " + (klinika17324.Pacijenti.Count - sumaAlkoholicara / 100) + " (" + (100 - procenatAlkoholicara) + "%)";
            int[] valArray1 = { procenatAlkoholicara, 100 - procenatAlkoholicara };
            int total1 = 0;
            Color[] clrArray = { Color.Red, Color.Green, Color.Yellow, Color.Pink, Color.Aqua };
            Bitmap curBitmap1 = new Bitmap(pictureBox4.Width, pictureBox4.Height);
            Graphics g = Graphics.FromImage(curBitmap1);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float angle1 = 0;
            float sweep1 = 0;
            //Total
            for (int i = 0; i < valArray1.Length; i++)
            {
                total1 += valArray1[i];
            }
            for (int i = 0; i < valArray1.Length; i++)
            {
                int val = valArray1[i];
                Color clr = clrArray[i];
                sweep1 = 360f * val / total1;

                SolidBrush brush1 = new SolidBrush(clr);
                g.FillPie(brush1, 20.0f, 20.0f, 200, 200, angle1, sweep1);
                angle1 += sweep1;
            }
            pictureBox4.Image = curBitmap1;
        }

        private void textBoxRegistracijaPregleda_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxRegistracijaPregleda.Text == "")
            {
                this.errorProvider2.SetError(textBoxRegistracijaPregleda, "Niste unijeli ime/prezime pacijenta kojem registrujete pregled!");
                toolStripStatusLabel2.Text = "Niste unijeli ime/prezime pacijenta kojem registrujete pregled!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxRegistracijaPregleda_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(textBoxRegistracijaPregleda, "");
            toolStripStatusLabel2.Text = "";
        }

        private void listBoxRegistracijaPregleda_Validating(object sender, CancelEventArgs e)
        {
            if (listBoxRegistracijaPregleda.SelectedIndex == -1)
            {
                this.errorProvider2.SetError(listBoxRegistracijaPregleda, "Niste izabrali pacijenta iz liste!");
                toolStripStatusLabel2.Text = "Niste izabrali pacijenta iz liste!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void listBoxRegistracijaPregleda_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(listBoxRegistracijaPregleda, "");
            toolStripStatusLabel2.Text = "";
        }

        private void richTextBoxOpisPostupka_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBoxOpisPostupka.Text == "")
            {
                this.errorProvider2.SetError(richTextBoxOpisPostupka, "Niste unijeli opis provedenog postupka!");
                toolStripStatusLabel2.Text = "Niste unijeli opis provedenog postupka!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void richTextBoxOpisPostupka_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(richTextBoxOpisPostupka, "");
            toolStripStatusLabel2.Text = "";
        }

        private void richTextBoxMisljenjeLjekara_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBoxMisljenjeLjekara.Text == "")
            {
                this.errorProvider2.SetError(richTextBoxMisljenjeLjekara, "Niste unijeli misljenje ljekara nakon provedenog postupka!");
                toolStripStatusLabel2.Text = "Niste unijeli misljenje ljekara nakon provedenog postupka!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void richTextBoxMisljenjeLjekara_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(richTextBoxMisljenjeLjekara, "");
            toolStripStatusLabel2.Text = "";
        }

        private void textBoxImePrezimeNaplata_TextChanged(object sender, EventArgs e)
        {
            listBoxNaplata.Items.Clear();
            if (textBoxImePrezimeNaplata.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    if ((p.Ime + " " + p.Prezime).IndexOf(textBoxImePrezimeNaplata.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxNaplata.Items.Add(p);
                    }
                }
        }

        private void textBoxImePrezimeNaplata_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxImePrezimeNaplata.Text == "")
            {
                this.errorProvider2.SetError(textBoxImePrezimeNaplata, "Niste unijeli misljenje ljekara nakon provedenog postupka!");
                toolStripStatusLabel2.Text = "Niste unijeli misljenje ljekara nakon provedenog postupka!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxImePrezimeNaplata_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(textBoxImePrezimeNaplata, "");
            toolStripStatusLabel2.Text = "";
        }

        private void listBoxNaplata_Validating(object sender, CancelEventArgs e)
        {
            if (listBoxNaplata.SelectedIndex == -1)
            {
                this.errorProvider2.SetError(listBoxNaplata, "Niste izabrali pacijenta iz liste!");
                toolStripStatusLabel2.Text = "Niste izabrali pacijenta iz liste!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void listBoxNaplata_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(listBoxNaplata, "");
            toolStripStatusLabel2.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPageNaplata_Click(object sender, EventArgs e)
        {

        }

        private void listBoxNaplata_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent) listBoxNaplata.SelectedItem;
            double saldoUkupni = 0;
            if (pacijent17324.Karton.Count==0) listBoxRacun.Items.AddRange(new object[] { "Nema registrovanih pregleda za placanje kod pacijenta" });
            else foreach (Zadaca1RPR_17324.Pregled p in pacijent17324.Karton)
            {
                labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: ";
                listBoxRacun.Items.Add("Pregled " + p.Postupak + " datuma " + p.DatumVrijemePregleda.ToShortDateString() + " cijena 45 KM.");
                    saldoUkupni += 45;
                    labelUkupnaCijenaPregleda.Text += saldoUkupni.ToString() + " KM";
                label12.Text = saldoUkupni.ToString();
                
            }
            if (pacijent17324.PosjetioKliniku >= 2) labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: " + (Convert.ToDouble(label12.Text) * 0.9) + " KM";//ovo ce mu biti barem treca posjeta-10% popusta
            // listBoxRacun.Items.Add
        }

        private void buttonRegistrujPregled_Click(object sender, EventArgs e)
        {
            richTextBoxOpisPostupka_Validating(richTextBoxOpisPostupka, new CancelEventArgs());
            richTextBoxMisljenjeLjekara_Validating(richTextBoxMisljenjeLjekara, new CancelEventArgs());
            richTextBoxTerapija_Validating(richTextBoxTerapija, new CancelEventArgs());
            if (errorProvider2.GetError(richTextBoxTerapija) == "" && errorProvider2.GetError(richTextBoxMisljenjeLjekara) == "" && errorProvider2.GetError(richTextBoxOpisPostupka) == "")
            {

                Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxRegistracijaPregleda.SelectedItem;
                Zadaca1RPR_17324.Pregled pregled17324 = new Zadaca1RPR_17324.Pregled(dateTimePicker3.Value.Date, richTextBoxOpisPostupka.Text, richTextBoxMisljenjeLjekara.Text, richTextBoxTerapija.Text, pacijent17324);
                pacijent17324.Karton.Add(pregled17324);
                toolStripStatusLabel2.Text = "Uspjesno dodan pregled!";
                toolStripStatusLabel2.ForeColor = Color.Green;
            }
        }

        private void richTextBoxTerapija_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBoxTerapija.Text == "")
            {
                this.errorProvider2.SetError(richTextBoxTerapija, "Niste unijeli propisanu terapiju nakon provedenog postupka!");
                toolStripStatusLabel2.Text = "Niste unijeli propisanu terapiju nakon provedenog postupka!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void richTextBoxTerapija_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(richTextBoxTerapija, "");
            toolStripStatusLabel2.Text = "";
        }

        private void izadjiIzAplikacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izadji(sender, e);
        }


        private void podešavanjeFontaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                tabControlGlavniMeni.Font = fontDialog.Font;
            }
        }



        private void comboBoxKriterijPretrage_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPretraga_Validating(listBoxPretraga, new CancelEventArgs());
            if (comboBoxKriterijPretrage.SelectedIndex==0)
            {
                dateTimePickerPretraga.Enabled = true;
                textBoxSadrzajPretrage.Enabled = false;
            }
            else
            {
                dateTimePickerPretraga.Enabled = false;
                textBoxSadrzajPretrage.Enabled = true;
            }
        }

        private void textBoxSadrzajPretrage_TextChanged(object sender, EventArgs e)
        {
            Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxPretraga.SelectedItem;
            listBoxRezultatPretrage.Items.Clear();
            if (textBoxSadrzajPretrage.Text.Length != 0 && errorProvider2.GetError(listBoxPretraga)=="")
            {
                if (comboBoxKriterijPretrage.SelectedIndex == 1)
                {
                    listBoxRezultatPretrage.Items.Clear();
                    foreach (Zadaca1RPR_17324.Pregled p in pacijent17324.Karton)
                    {
                        if (p.MisljenjeLjekara.Contains(textBoxSadrzajPretrage.Text))
                        {
                            listBoxRezultatPretrage.Items.Add(p.ToString());
                        }
                    }
                }
                else if (comboBoxKriterijPretrage.SelectedIndex == 2)
                {
                    listBoxRezultatPretrage.Items.Clear();
                    foreach (Zadaca1RPR_17324.Pregled p in pacijent17324.Karton)
                    {
                        if (p.Terapija.Contains(textBoxSadrzajPretrage.Text))
                        {
                            listBoxRezultatPretrage.Items.Add(p.ToString());
                        }
                    }
                }
                else if (comboBoxKriterijPretrage.SelectedIndex == 3)
                {
                    listBoxRezultatPretrage.Items.Clear();
                    foreach (Zadaca1RPR_17324.Pregled p in pacijent17324.Karton)
                    {
                        if (p.Postupak.Contains(textBoxSadrzajPretrage.Text))
                        {
                            listBoxRezultatPretrage.Items.Add(p.ToString());
                        }
                    }
                }
            }
        }

        private void dateTimePickerPretraga_ValueChanged(object sender, EventArgs e)
        {
            Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxPretraga.SelectedItem;
            if (comboBoxKriterijPretrage.SelectedText.Equals("Pretraga po datumu pregleda"))
            {
                listBoxRezultatPretrage.Items.Clear();
                foreach (Zadaca1RPR_17324.Pregled p in pacijent17324.Karton)
                {
                    if (p.DatumVrijemePregleda.Date == dateTimePickerPretraga.Value.Date)
                    {
                        listBoxRezultatPretrage.Items.Add(p.ToString());
                    }
                }
            }
        }

        private void listBoxPretraga_Validating(object sender, CancelEventArgs e)
        {
            if (listBoxPretraga.SelectedIndex == -1)
            {
                this.errorProvider2.SetError(listBoxPretraga, "Niste izabrali pacijenta iz liste!");
                toolStripStatusLabel2.Text = "Niste izabrali pacijenta iz liste!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void listBoxPretraga_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(listBoxPretraga, "");
            toolStripStatusLabel2.Text = "";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonNaplati_Click(object sender, EventArgs e)
        {
            Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxNaplata.SelectedItem;
            listBoxNaplata_Validating(listBoxNaplata, new CancelEventArgs());
            textBoxImePrezimeNaplata_Validating(textBoxImePrezimeNaplata, new CancelEventArgs());
            if (errorProvider2.GetError(listBoxNaplata)=="" && errorProvider2.GetError(textBoxImePrezimeNaplata)=="")
            {
                pacijent17324.PosjetioKliniku++;
                klinika17324.Naplaceno.Add(Convert.ToDouble(label12.Text));
            }
        }

        private void radioButtonGotovina_CheckedChanged(object sender, EventArgs e)
        {
            Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxNaplata.SelectedItem;
            double originalnaVrijednost = Convert.ToDouble(label12.Text);
            if (radioButtonGotovina.Checked == true)
            {
                labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: " + originalnaVrijednost + " KM";
                if (pacijent17324.PosjetioKliniku >= 2) labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: " + (Convert.ToDouble(label12.Text) * 0.9) + " KM";//ovo ce mu biti barem treca posjeta-10% popusta
            }
            else
            {
               labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: " + originalnaVrijednost + " KM";
                if (pacijent17324.PosjetioKliniku < 2) labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: " + (Convert.ToDouble(label12.Text) * 1.15) + " KM";
            }
        }
    }
}
