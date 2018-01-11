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
using System.IO;
using System.Xml.Serialization;
using System.Globalization;

namespace SehalicMirza17324_Z2
{
    public partial class glavniMeni17324 : Form
    {
        Zadaca1RPR_17324.KlinikaKontejner klinika17324 = new Zadaca1RPR_17324.KlinikaKontejner();
        Uposlenik uposlenik17324_1 = new Uposlenik();
        List<string> GlobalniLogovi = new List<string>();
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

            if (u is Doktor)
            {
                ((Control)this.tabPageUnosPacijenata).Enabled = false; //nije posao doktora da unosi pacijente niti da ih brise
                this.tabPageUnosPacijenata.Dispose();
                ((Control)this.tabPageNaplata).Enabled = false; //nema potrebe da doktori naplacuju
                this.tabPageNaplata.Dispose();
                ((Control)this.tabPageKreiranjeKartona).Enabled = false; //nije posao doktora da kreira kartone
                this.tabPageKreiranjeKartona.Dispose();
            }
            if (!(u is Administrator)) //samo admini vide dio za administraciju
            {
                ((Control)this.tabPageAdministracija).Enabled = false;
                this.tabPageAdministracija.Dispose();
                ((Control)this.tabPageSerijalizacija).Enabled = false;
                this.tabPageSerijalizacija.Dispose();
                ((Control)this.tabPageDeserijalizacija).Enabled = false;
                this.tabPageDeserijalizacija.Dispose();
                ((Control)this.tabPageLogovi).Enabled = false;
                this.tabPageLogovi.Dispose();
                ((Control)this.tabPageStatistikaIzuzeci).Enabled = false;
                this.tabPageStatistikaIzuzeci.Dispose();
            }
        }
        public glavniMeni17324(Zadaca1RPR_17324.Pacijent p)
        {
            InitializeComponent();
            Zadaca1RPR_17324.Pacijent pacijent17324 = p;
            ((Control)this.tabPageNaplata).Enabled = false;
            this.tabPageNaplata.Dispose();
            ((Control)this.tabPageAnaliza).Enabled = false;
            this.tabPageAnaliza.Dispose();
            ((Control)this.tabPageKreiranjeKartona).Enabled = false;
            this.tabPageKreiranjeKartona.Dispose();
            ((Control)this.tabPageUnosPacijenata).Enabled = false;
            this.tabPageUnosPacijenata.Dispose();
            ((Control)this.tabPagePretragaKartona).Enabled = false;
            this.tabPagePretragaKartona.Dispose();
            ((Control)this.tabPageAdministracija).Enabled = false;
            this.tabPageAdministracija.Dispose();
        }
        private void DodajCvorove(TreeView t)
        {
            t.Nodes.Clear();
            TreeNode doktori = new TreeNode("Doktori");
            TreeNode tehnicari = new TreeNode("Tehnicari");
            TreeNode pacijenti = new TreeNode("Pacijenti");
            TreeNode admin = new TreeNode("Administratori");
            t.Nodes.Add(admin);
            t.Nodes.Add(doktori);
            t.Nodes.Add(tehnicari);
            t.Nodes.Add(pacijenti);
            if (klinika17324.Uposlenici.Count != 0) //dodaje vec postojece iz kontejnerske
            {
                doktori.Nodes.Clear();
                tehnicari.Nodes.Clear();
                pacijenti.Nodes.Clear();
                admin.Nodes.Clear();
                foreach (Uposlenik u in klinika17324.Uposlenici)
                {
                    if (u is Tehnicar) tehnicari.Nodes.Add(new TreeNode(u.ImeUposlenika + " " + u.PrezimeUposlenika));
                    if (u is Doktor) doktori.Nodes.Add(new TreeNode(u.ImeUposlenika + " " + u.PrezimeUposlenika));
                    if (u is Administrator) admin.Nodes.Add(new TreeNode(u.ImeUposlenika + " " + u.PrezimeUposlenika));
                }

            }
            if (klinika17324.Pacijenti.Count != 0)
            {
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    pacijenti.Nodes.Add(new TreeNode(p.Ime + " " + p.Prezime));
                }
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
            if (radioButtonDoktor.Checked == false) textBoxSpecijalizacija.Enabled = false;
            groupBoxPrikazKartona.Enabled = false;
            DodajCvorove(treeView1);

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
        private string stvoriUsername(TextBox prvi, TextBox drugi)
        {
            return prvi.Text.ToLower().Trim().Substring(0, 1) + drugi.Text.Trim().ToLower();
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
                Zadaca1RPR_17324.Pacijent p = new Zadaca1RPR_17324.Pacijent(stvoriUsername(textBox1, textBox2), maskedTextBox1.Text, textBox1.Text, textBox2.Text, textBoxAdresa.Text, bracnoStanjePacijenta, dateTimePicker1.Value.Date, pol, Convert.ToUInt64(maskedTextBox1.Text), userControlUnosSlike1.vratiSliku);
                labelUsername.Text = stvoriUsername(textBox1, textBox2) + "\nŠifra je matični broj pacijenta.";
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
                    DodajCvorove(treeView1);
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
            if (userControlUnosSlike1.vratiSliku == null)
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
            Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxNaplata.SelectedItem;
            if (listBoxNaplata.SelectedIndex != -1)
            {
                double saldoUkupni = 0;
                int brojac = 0;
                if (pacijent17324.Karton.Count == 0) listBoxRacun.Items.AddRange(new object[] { "Nema registrovanih pregleda za placanje kod pacijenta" });
                else foreach (Zadaca1RPR_17324.Pregled p in pacijent17324.Karton)
                    {
                        labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: ";
                        if (p.NaplacenPregled == false)
                        {
                            listBoxRacun.Items.Add("Pregled " + p.Postupak + " datuma " + p.DatumVrijemePregleda.ToShortDateString() + " cijena 45 KM.");
                            saldoUkupni += 45;
                            labelUkupnaCijenaPregleda.Text += saldoUkupni.ToString() + " KM";
                            label12.Text = saldoUkupni.ToString();
                            brojac++;
                        }
                    }
                if (brojac == 0) listBoxRacun.Items.AddRange(new object[] { "Nema registrovanih pregleda za placanje kod pacijenta" });
                if (pacijent17324.PosjetioKliniku >= 2) labelUkupnaCijenaPregleda.Text = "Ukupna cijena pregleda: " + (Convert.ToDouble(label12.Text) * 0.9) + " KM";//ovo ce mu biti barem treca posjeta-10% popusta
                                                                                                                                                                     // listBoxRacun.Items.Add
            }
        }

        private void buttonRegistrujPregled_Click(object sender, EventArgs e)
        {
            richTextBoxOpisPostupka_Validating(richTextBoxOpisPostupka, new CancelEventArgs());
            richTextBoxMisljenjeLjekara_Validating(richTextBoxMisljenjeLjekara, new CancelEventArgs());
            richTextBoxTerapija_Validating(richTextBoxTerapija, new CancelEventArgs());
            numericUpDown1_Validating(numericUpDown1, new CancelEventArgs());
            if (errorProvider2.GetError(numericUpDown1) == "" && errorProvider2.GetError(richTextBoxTerapija) == "" && errorProvider2.GetError(richTextBoxMisljenjeLjekara) == "" && errorProvider2.GetError(richTextBoxOpisPostupka) == "")
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
            if (comboBoxKriterijPretrage.SelectedIndex == 0)
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
            if (textBoxSadrzajPretrage.Text.Length != 0 && errorProvider2.GetError(listBoxPretraga) == "")
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
            if (errorProvider2.GetError(listBoxNaplata) == "" && errorProvider2.GetError(textBoxImePrezimeNaplata) == "")
            {
                pacijent17324.PosjetioKliniku++;
                klinika17324.Naplaceno.Add(Convert.ToDouble(label12.Text));
            }
            foreach (Zadaca1RPR_17324.Pregled p in pacijent17324.Karton)
            {
                p.NaplacenPregled = true;
            }
            label12.Text = "0";
            labelUkupnaCijenaPregleda.Text = "";
            listBoxRacun.Items.Clear();
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

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {
            if (numericUpDown1.Value != uposlenik17324_1.BrojLicence)
            {
                this.errorProvider2.SetError(numericUpDown1, "Licenca koju ste unijeli nije vasa!");
                toolStripStatusLabel2.Text = "Licenca koju ste unijeli nije vasa!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void numericUpDown1_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(numericUpDown1, "");
            toolStripStatusLabel2.Text = "";
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBoxImeUposlenik_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxImeUposlenik.Text.Length == 0)
            {
                errorProvider2.SetError(textBoxImeUposlenik, "Niste unijeli ime uposlenika!");
                toolStripStatusLabel2.Text = "Niste unijeli ime uposlenika!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
            if (textBoxImeUposlenik.Text.Any(char.IsDigit))
            {
                errorProvider2.SetError(textBoxImeUposlenik, "Unijeli ste broj u polje za ime uposlenika!");
                toolStripStatusLabel2.Text = "Unijeli ste broj u polje za ime uposlenika!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxImeUposlenik_Validated(object sender, EventArgs e)
        {
            errorProvider2.SetError(textBoxImeUposlenik, "");
            toolStripStatusLabel2.Text = "";
        }

        private void textBoxPrezimeUposlenik_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPrezimeUposlenik.Text.Length == 0)
            {
                errorProvider2.SetError(textBoxPrezimeUposlenik, "Niste unijeli prezime uposlenika!");
                toolStripStatusLabel2.Text = "Niste unijeli prezime uposlenika!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
            if (textBoxPrezimeUposlenik.Text.Any(char.IsDigit))
            {
                errorProvider2.SetError(textBoxPrezimeUposlenik, "Unijeli ste broj u polje za prezime uposlenika!");
                toolStripStatusLabel2.Text = "Unijeli ste broj u polje za prezime uposlenika!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxPrezimeUposlenik_Validated(object sender, EventArgs e)
        {
            errorProvider2.SetError(textBoxPrezimeUposlenik, "");
            toolStripStatusLabel2.Text = "";
        }

        private void textBoxKorisnickoImeUposlenik_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxKorisnickoImeUposlenik.Text.Length == 0)
            {
                errorProvider2.SetError(textBoxKorisnickoImeUposlenik, "Niste unijeli korisnicko ime uposlenika!");
                toolStripStatusLabel2.Text = "Niste unijeli korisnicko ime uposlenika!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxKorisnickoImeUposlenik_Validated(object sender, EventArgs e)
        {
            errorProvider2.SetError(textBoxKorisnickoImeUposlenik, "");
            toolStripStatusLabel2.Text = "";
        }

        private void textBoxLozinkaUposlenik_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxLozinkaUposlenik.Text.Length == 0)
            {
                errorProvider2.SetError(textBoxLozinkaUposlenik, "Niste unijeli lozinku uposlenika!");
                toolStripStatusLabel2.Text = "Niste unijeli lozinku uposlenika!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxLozinkaUposlenik_Validated(object sender, EventArgs e)
        {
            errorProvider2.SetError(textBoxLozinkaUposlenik, "");
            toolStripStatusLabel2.Text = "";
        }

        private void textBoxPotvrdaLozinkeUposlenik_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxLozinkaUposlenik.Text != textBoxPotvrdaLozinkeUposlenik.Text)
            {
                errorProvider2.SetError(textBoxPotvrdaLozinkeUposlenik, "Lozinke se ne podudaraju!");
                toolStripStatusLabel2.Text = "Lozinke se ne podudaraju!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxPotvrdaLozinkeUposlenik_Validated(object sender, EventArgs e)
        {
            errorProvider2.SetError(textBoxPotvrdaLozinkeUposlenik, "");
            toolStripStatusLabel2.Text = "";
        }
        private void userControlUnosSlikeUposlenik_Validating(object sender, CancelEventArgs e)
        {
            if (!userControlUnosSlikeUposlenik.ispravanDatum)
            {
                this.errorProvider2.SetError(userControlUnosSlikeUposlenik, "Datum slike ne smije biti stariji od 6 mjeseci!");
                toolStripStatusLabel2.Text = "Datum slike ne smije biti stariji od 6 mjeseci!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
            if (userControlUnosSlikeUposlenik.vratiSliku == null)
            {
                this.errorProvider2.SetError(userControlUnosSlikeUposlenik, "Niste odabrali sliku!");
                toolStripStatusLabel2.Text = "Niste odabrali sliku!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void userControlUnosSlikeUposlenik_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(userControlUnosSlikeUposlenik, "");
            toolStripStatusLabel2.Text = "";
        }

        private void buttonOdustaniUposlenik_Click(object sender, EventArgs e)
        {
            textBoxPotvrdaLozinkeUposlenik.Text = "";
            textBoxLozinkaUposlenik.Text = "";
            textBoxImeUposlenik.Text = "";
            textBoxPrezimeUposlenik.Text = "";
            numericUpDownLicenca.Value = 100;
            userControlUnosSlikeUposlenik.Resetiraj();
        }

        private void buttonUnesiUposlenika_Click(object sender, EventArgs e)
        {
            textBoxImeUposlenik_Validating(textBoxImeUposlenik, new CancelEventArgs());
            textBoxPrezimeUposlenik_Validating(textBoxPrezimeUposlenik, new CancelEventArgs());
            textBoxKorisnickoImeUposlenik_Validating(textBoxKorisnickoImeUposlenik, new CancelEventArgs());
            textBoxLozinkaUposlenik_Validating(textBoxLozinkaUposlenik, new CancelEventArgs());
            textBoxPotvrdaLozinkeUposlenik_Validating(textBoxPotvrdaLozinkeUposlenik, new CancelEventArgs());
            userControlUnosSlikeUposlenik_Validating(userControlUnosSlikeUposlenik, new CancelEventArgs());
            textBoxSpecijalizacija_Validating(textBoxSpecijalizacija, new CancelEventArgs());
            if (errorProvider2.GetError(textBoxSpecijalizacija) == "" && errorProvider2.GetError(textBoxImeUposlenik) == "" && errorProvider2.GetError(textBoxPotvrdaLozinkeUposlenik) == "" && errorProvider2.GetError(textBoxLozinkaUposlenik) == "" && errorProvider2.GetError(textBoxPrezimeUposlenik) == "" && errorProvider2.GetError(userControlUnosSlikeUposlenik) == "")
            {
                if (radioButtonTehnicar.Checked)
                {
                    klinika17324.Uposlenici.Add(new Tehnicar(textBoxImeUposlenik.Text, textBoxPrezimeUposlenik.Text, userControlUnosSlikeUposlenik.vratiSliku, (int)numericUpDownLicenca.Value, textBoxKorisnickoImeUposlenik.Text, textBoxPotvrdaLozinkeUposlenik.Text));
                    DodajCvorove(treeView1);
                    toolStripStatusLabel2.Text = "Uspjesno dodan uposlenik!";
                    toolStripStatusLabel2.ForeColor = Color.Green;
                }
                else if (radioButtonAdmin.Checked)
                {
                    klinika17324.Uposlenici.Add(new Administrator(textBoxImeUposlenik.Text, textBoxPrezimeUposlenik.Text, userControlUnosSlikeUposlenik.vratiSliku, (int)numericUpDownLicenca.Value, textBoxKorisnickoImeUposlenik.Text, textBoxPotvrdaLozinkeUposlenik.Text));
                    DodajCvorove(treeView1);
                    toolStripStatusLabel2.Text = "Uspjesno dodan uposlenik!";
                    toolStripStatusLabel2.ForeColor = Color.Green;
                }
                else if (radioButtonDoktor.Checked)
                {
                    klinika17324.Uposlenici.Add(new Doktor(textBoxImeUposlenik.Text, textBoxPrezimeUposlenik.Text, userControlUnosSlikeUposlenik.vratiSliku, (int)numericUpDownLicenca.Value, textBoxKorisnickoImeUposlenik.Text, textBoxPotvrdaLozinkeUposlenik.Text, 0, textBoxSpecijalizacija.Text));
                    DodajCvorove(treeView1);
                    toolStripStatusLabel2.Text = "Uspjesno dodan uposlenik!";
                    toolStripStatusLabel2.ForeColor = Color.Green;
                }
            }
        }

        private void textBoxSpecijalizacija_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxSpecijalizacija.Text.Length == 0 && radioButtonDoktor.Enabled == true)
            {
                this.errorProvider2.SetError(textBoxSpecijalizacija, "Niste unijeli specijalizaciju doktora!");
                toolStripStatusLabel2.Text = "Niste unijeli specijalizaciju doktora!";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
        }

        private void textBoxSpecijalizacija_Validated(object sender, EventArgs e)
        {
            this.errorProvider2.SetError(textBoxSpecijalizacija, "");
            toolStripStatusLabel2.Text = "";
        }

        private void radioButtonDoktor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDoktor.Checked == true) textBoxSpecijalizacija.Enabled = true;
            else textBoxSpecijalizacija.Enabled = false;
        }

        private void buttonBrisanjeImePrezime_Click(object sender, EventArgs e)
        {
            if (listBoxPretragaImePrezime.SelectedIndex != -1)
            {
                Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxPretragaImePrezime.SelectedItem;
                klinika17324.Pacijenti.Remove(pacijent17324);
                toolStripStatusLabel2.Text = "Uspjesno obrisan pacijent!";
                toolStripStatusLabel2.ForeColor = Color.Green;
                DodajCvorove(treeView1);
            }
        }

        private void buttonBrisanjeJMBG_Click(object sender, EventArgs e)
        {
            if (listBoxBrisanjeJMBG.SelectedIndex != -1)
            {
                Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxBrisanjeJMBG.SelectedItem;
                klinika17324.Pacijenti.Remove(pacijent17324);
                toolStripStatusLabel2.Text = "Uspjesno obrisan pacijent!";
                toolStripStatusLabel2.ForeColor = Color.Green;
                DodajCvorove(treeView1);
            }
        }

        private void textBoxBrisanjeImePrezimeUposlenik_TextChanged(object sender, EventArgs e)
        {
            listBoxBrisanjeImeUposlenik.Items.Clear();
            if (textBoxBrisanjeImePrezimeUposlenik.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Uposlenik u in klinika17324.Uposlenici)
                {
                    if ((u.ImeUposlenika + " " + u.PrezimeUposlenika).IndexOf(textBoxBrisanjeImePrezimeUposlenik.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxBrisanjeImeUposlenik.Items.Add(u);
                    }
                }
        }

        private void labelBrisanjeUposlenikLicenca_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBrisanjeLicenca_TextChanged(object sender, EventArgs e)
        {
            listBoxBrisanjeLicenca.Items.Clear();
            if (textBoxBrisanjeLicenca.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Uposlenik u in klinika17324.Uposlenici)
                {
                    if ((u.BrojLicence.ToString()).Equals(textBoxBrisanjeLicenca.Text))
                    {
                        listBoxBrisanjeLicenca.Items.Add(u);
                    }
                }
        }

        private void buttonBrisiUposlenikIme_Click(object sender, EventArgs e)
        {
            if (listBoxBrisanjeImeUposlenik.SelectedIndex != -1)
            {
                Uposlenik u17324 = (Uposlenik)listBoxBrisanjeImeUposlenik.SelectedItem;
                klinika17324.Uposlenici.Remove(u17324);
                toolStripStatusLabel2.Text = "Uspjesno obrisan uposlenik!";
                toolStripStatusLabel2.ForeColor = Color.Green;
                DodajCvorove(treeView1);
            }
        }

        private void buttonBrisiLicenca_Click(object sender, EventArgs e)
        {
            if (listBoxBrisanjeLicenca.SelectedIndex != -1)
            {
                Uposlenik u17324 = (Uposlenik)listBoxBrisanjeLicenca.SelectedItem;
                klinika17324.Uposlenici.Remove(u17324);
                toolStripStatusLabel2.Text = "Uspjesno obrisan uposlenik!";
                toolStripStatusLabel2.ForeColor = Color.Green;
                DodajCvorove(treeView1);
            }
        }

        private void podešavanjeBojeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.BackColor = colorDialog1.Color;
            }
        }

        private void textBoxPrikazKartona_TextChanged(object sender, EventArgs e)
        {
            listBoxPrikazKartona.Items.Clear();
            if (textBoxPrikazKartona.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    if ((p.Ime + " " + p.Prezime).IndexOf(textBoxPrikazKartona.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        listBoxPrikazKartona.Items.Add(p);
                    }
                }
        }

        private void listBoxPrikazKartona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPrikazKartona.SelectedIndex != -1)
            {
                Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)listBoxPrikazKartona.SelectedItem;
                textBoxPrikazKartonaIme.Text = pacijent17324.Ime;
                textBoxPrikazKartonaPrezime.Text = pacijent17324.Prezime;
                dateTimePickerPrikazKartona.Value = pacijent17324.DatumRodjenja;
                maskedTextBoxPrikazKartona.Text = pacijent17324.MaticniBroj.ToString();
                pictureBoxPrikazSlikePacijenta.Image = pacijent17324.SlikaPacijenta;
                radioButtonPrikazZensko.Checked = pacijent17324.Spol == 'Z';
                textBoxAdresaPrikaz.Text = pacijent17324.AdresaStanovanja;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void SacuvajLogIzuzetka(string log)
        {
            GlobalniLogovi.Add(DateTime.Now.ToString() + " " + log); //spasava vrijeme nastanka izuzetka
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@".\logIzuzetaka.txt", false))
            {
                foreach (string s in GlobalniLogovi)
                    file.WriteLine(s); //zapisuje u txt fajl
            }
        }
        private void buttonSerijalizujPacijente_Click(object sender, EventArgs e)
        {
            textBoxInfoSerijalizacijaPacijenti.Text = "";
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "xml files(*.xml)|*.xml|All files (*.*)|*.*", FileName = "pacijenti.xml", AddExtension = true, DefaultExt = ".xml", };
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
            {
                klinika17324.XMLSerial(sfd.FileName, klinika17324.Pacijenti, typeof(List<Zadaca1RPR_17324.Pacijent>));
                textBoxInfoSerijalizacijaPacijenti.Text = "Serijalizacija uspješna!";
            }
            else
            {
                textBoxInfoSerijalizacijaPacijenti.Text = "Greška pri serijalizaciji! Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela serijalizacija liste pacijenata u XML datoteku!");
            }

        }

        private void buttonSerijalizujUposlenike_Click(object sender, EventArgs e)
        {
            textBoxInfoSerijalizacijaUposlenika.Text = "";
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "xml files(*.xml)|*.xml|All files (*.*)|*.*", FileName = "uposlenici.xml", AddExtension = true, DefaultExt = ".xml", };
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
            {
                klinika17324.XMLSerialNasljedjivanje(sfd.FileName, klinika17324.Uposlenici, typeof(List<Uposlenik>), new List<Type>() { typeof(Doktor), typeof(Administrator), typeof(Tehnicar), typeof(Uposlenik) });
                textBoxInfoSerijalizacijaUposlenika.Text = "Serijalizacija uspješna!";
            }
            else
            {
                textBoxInfoSerijalizacijaUposlenika.Text = "Greška pri serijalizaciji! Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela serijalizacija liste uposlenika u XML datoteku!");
            }
        }

        private void buttonSerijalizujPacijenteBinarno_Click(object sender, EventArgs e)
        {
            textBoxInfoBinarnoPacijenti.Text = "";
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "binary files(*.bin)|*.bin|All files (*.*)|*.*", FileName = "pacijenti.bin", AddExtension = true, DefaultExt = ".bin", };
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".bin"))
            {
                klinika17324.BinSerial(sfd.FileName, klinika17324.Pacijenti);
                textBoxInfoBinarnoPacijenti.Text = "Serijalizacija uspješna!";
            }
            else
            {
                textBoxInfoBinarnoPacijenti.Text = "Greška pri serijalizaciji! Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela serijalizacija liste pacijenata u binarnu datoteku!");
            }
        }

        private void buttonSerijalizujUposlenikeBinarno_Click(object sender, EventArgs e)
        {
            textBoxInfoBinarnoUposlenici.Text = "";
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "binary files(*.bin)|*.bin|All files (*.*)|*.*", FileName = "uposlenici.bin", AddExtension = true, DefaultExt = ".bin", };
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".bin"))
            {
                klinika17324.BinSerial(sfd.FileName, klinika17324.Uposlenici);
                textBoxInfoBinarnoUposlenici.Text = "Serijalizacija uspješna!";
            }
            else
            {
                textBoxInfoBinarnoUposlenici.Text = "Greška pri serijalizaciji! Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela serijalizacija liste uposlenika u binarnu datoteku!");
            }

        }

        private void buttonDeserijalizujXMLPac_Click(object sender, EventArgs e)
        {
            textBoxInfoDesXMLPac.Text = "";
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "xml files(*.xml)|*.xml|All files (*.*)|*.*", Multiselect = false, CheckFileExists = true };
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
            {
                try
                {
                    dataGridViewPacijenti.DataSource = klinika17324.XMLDeSerial(ofd.FileName, typeof(List<Zadaca1RPR_17324.Pacijent>));
                    klinika17324.Pacijenti = klinika17324.XMLDeSerial(ofd.FileName, typeof(List<Zadaca1RPR_17324.Pacijent>)) as List<Zadaca1RPR_17324.Pacijent>;
                    DodajCvorove(treeViewDeserijalizacija);
                    textBoxInfoDesXMLPac.Text = "Deserijalizacija uspješna!";
                }
                catch (Exception)
                {
                    dataGridViewPacijenti.Refresh();
                    textBoxInfoDesXMLPac.Text = "Greška pri deserijalizaciji! Pogrešan format datoteke, provjerite da učitavate pacijente!";
                    SacuvajLogIzuzetka("Neuspjela deserijalizacija liste pacijenata iz XML datoteke! Pogrešan format datoteke!");
                }
            }
            else
            {
                textBoxInfoDesXMLPac.Text = "Greška pri deserijalizaciji!. Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela deserijalizacija liste pacijenata iz XML datoteke!");
            }
        }

        private void buttonDesXMLUpo_Click(object sender, EventArgs e)
        {
            textBoxInfoXMLUpo.Text = "";
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "xml files(*.xml)|*.xml|All files (*.*)|*.*", Multiselect = false, CheckFileExists = true };
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
            {
                try
                {
                    dataGridViewUposlenici.DataSource = klinika17324.XMLDeSerialNasljedjivanje(ofd.FileName, typeof(List<Uposlenik>), new List<Type>() { typeof(Doktor), typeof(Administrator), typeof(Tehnicar), typeof(Uposlenik) });
                    klinika17324.Uposlenici = dataGridViewUposlenici.DataSource as List<Uposlenik>;
                    DodajCvorove(treeViewDeserijalizacija);
                    textBoxInfoXMLUpo.Text = "Deserijalizacija uspješna!";
                }
                catch (Exception)
                {
                    dataGridViewUposlenici.Refresh();
                    textBoxInfoXMLUpo.Text = "Greška pri deserijalizaciji! Pogrešan format datoteke, provjerite da učitavate uposlenike!";
                    SacuvajLogIzuzetka("Neuspjela deserijalizacija liste uposlenika iz XML datoteke! Pogrešan format datoteke!");
                }
            }
            else
            {
                textBoxInfoXMLUpo.Text = "Greška pri deserijalizaciji!. Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela deserijalizacija liste uposlenika iz XML datoteke!");
            }
        }

        private void buttonDeserijalizacijaBinPac_Click(object sender, EventArgs e)
        {
            RichTextBoxInfoDesPacBin.Text = "";
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "binary files(*.bin)|*.bin|All files (*.*)|*.*", Multiselect = false, CheckFileExists = true };
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".bin"))
            {
                try
                {
                    dataGridViewPacijenti.DataSource = klinika17324.BinDeSerial(ofd.FileName);
                    klinika17324.Pacijenti = klinika17324.BinDeSerial(ofd.FileName) as List<Zadaca1RPR_17324.Pacijent>;
                    DodajCvorove(treeViewDeserijalizacija);
                    RichTextBoxInfoDesPacBin.Text = "Deserijalizacija uspješna!";
                }
                catch (Exception)
                {
                    dataGridViewPacijenti.Refresh();
                    RichTextBoxInfoDesPacBin.Text = "Greška pri deserijalizaciji! Pogrešan format datoteke, provjerite da učitavate pacijente!";
                    SacuvajLogIzuzetka("Neuspjela deserijalizacija liste pacijenata iz binarne datoteke! Pogrešan format datoteke!");
                }
            }
            else
            {
                RichTextBoxInfoDesPacBin.Text = "Greška pri deserijalizaciji!. Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela deserijalizacija liste pacijenata iz binarne datoteke!");
            }
        }

        private void buttonDesBinUpo_Click(object sender, EventArgs e)
        {
            textBoxInfoBinUpo.Text = "";
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "binary files(*.bin)|*.bin|All files (*.*)|*.*", Multiselect = false, CheckFileExists = true };
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".bin"))
            {
                try
                {
                    dataGridViewUposlenici.DataSource = klinika17324.BinDeSerial(ofd.FileName);
                    klinika17324.Uposlenici = klinika17324.BinDeSerial(ofd.FileName) as List<Uposlenik>;
                    DodajCvorove(treeViewDeserijalizacija);
                    textBoxInfoBinUpo.Text = "Deserijalizacija uspješna!";
                }
                catch (Exception)
                {
                    dataGridViewUposlenici.Refresh();
                    textBoxInfoBinUpo.Text = "Greška pri deserijalizaciji! Pogrešan format datoteke, provjerite da učitavate uposlenike!";
                    SacuvajLogIzuzetka("Neuspjela deserijalizacija liste uposlenika iz binarne datoteke! Pogrešan format datoteke!");
                }
            }
            else
            {
                textBoxInfoBinUpo.Text = "Greška pri deserijalizaciji!. Provjerite ekstenziju datoteke.";
                SacuvajLogIzuzetka("Neuspjela deserijalizacija liste uposlenika iz binarne datoteke!");
            }
        }

        private void buttonUcitajLogove_Click(object sender, EventArgs e)
        {
            richTextBoxLogovi.Text = "";
            if (File.Exists(@".\logIzuzetaka.txt"))
            {
                string[] sadrzaj = System.IO.File.ReadAllLines(@".\logIzuzetaka.txt");
                foreach (string s in sadrzaj)
                    richTextBoxLogovi.Text += s + '\n';
            }
            else
            {
                richTextBoxLogovi.Text = "Otvaranje defaultne datoteke s logovima nije uspjelo";
                SacuvajLogIzuzetka("Otvaranje defaultne datoteke s logovima nije uspjelo");
            }
        }

        private void buttonUcitajDruguDatoteku_Click(object sender, EventArgs e)
        {
            richTextBoxLogovi.Text = "";
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "text files(*.txt)|*.txt|All files (*.*)|*.*", Multiselect = false, CheckFileExists = true };
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".txt"))
            {
                string[] sadrzaj = System.IO.File.ReadAllLines(ofd.FileName);
                foreach (string s in sadrzaj)
                    richTextBoxLogovi.Text += s;
            }
            else
            {
                richTextBoxLogovi.Text = "Otvaranje zeljene datoteke s logovima nije uspjelo";
                SacuvajLogIzuzetka("Otvaranje zeljene datoteke s logovima nije uspjelo");
            }
        }

        private void buttonObrisiSveLogove_Click(object sender, EventArgs e)
        {
            richTextBoxLogovi.Text = "";
            if (File.Exists(@".\logIzuzetaka.txt"))
            {
                System.IO.File.WriteAllText(@".\logIzuzetaka.txt", string.Empty);
                GlobalniLogovi = new List<string>(); //treba pocistiti i globalni zapis gresaka
                richTextBoxLogovi.Text = "Uspjesno obrisan sadrzaj defaultne datoteke s logovima";
            }
            else
            {
                richTextBoxLogovi.Text = "Pokusaj brisanja sadrzaja defaultne datoteke s logovima nije uspio";
                SacuvajLogIzuzetka("Pokusaj brisanja sadrzaja defaultne datoteke s logovima nije uspio");
            }
        }

        private void radioButtonVrstaIzuzetka_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxStatistikaIzuzeci.Text = ""; //ocisti sve sto je mozda tu jer se mijenja nacin pregleda
            if (radioButtonVrstaIzuzetka.Checked == false) groupBoxTipIzuzetka.Enabled = false;
            else if (radioButtonVrstaIzuzetka.Checked == true) groupBoxTipIzuzetka.Enabled = true;
        }

        private void radioButtonDatumIzuzetka_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxStatistikaIzuzeci.Text = "";
            string[] razdvojiNaDatumIOpis;
            DateTime datum;
            TimeSpan sat;
            if (radioButtonDatumIzuzetka.Checked == false) groupBoxIntervalDatuma.Enabled = false;
            else if (radioButtonDatumIzuzetka.Checked == true)
            {
                groupBoxIntervalDatuma.Enabled = true;
                foreach (string s in GlobalniLogovi)
                {
                    razdvojiNaDatumIOpis = s.Split(null);
                    datum = Convert.ToDateTime(razdvojiNaDatumIOpis[0]); //vadi datum iz izuzetka
                    sat=TimeSpan.ParseExact(razdvojiNaDatumIOpis[1], "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
                    datum += sat; //dodaje i sate na datum da se mogu porediti i minute i sekunde na pickerima
                    if (dateTimePickerIzuzetak1.Value <= datum && datum <= dateTimePickerIzuzetak2.Value) //ako je u intervalu
                        richTextBoxStatistikaIzuzeci.Text += s + '\n';
                }
            }
        }

        private void radioButtonXMLIzuzetak_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonXMLIzuzetak.Checked == true && radioButtonVrstaIzuzetka.Checked == true)
            {
                foreach (string s in GlobalniLogovi)
                 if (s.Contains("XML")) richTextBoxStatistikaIzuzeci.Text += s +'\n'; //provjerava da li je XML izuzetak sto smo naglasili kod kreiranja istih
            }
            if (radioButtonVrstaIzuzetka.Checked == false || radioButtonXMLIzuzetak.Checked == false)
                richTextBoxStatistikaIzuzeci.Text = ""; //brise sve ako se deselektuje
        }

        private void radioButtonBazePodataka_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBazePodataka.Checked == true && radioButtonVrstaIzuzetka.Checked == true)
            {
                foreach (string s in GlobalniLogovi)
                    if (s.Contains("DB")) richTextBoxStatistikaIzuzeci.Text += s +'\n'; //provjerava da li je DB izuzetak sto smo naglasili kod kreiranja istih
            }
            if (radioButtonVrstaIzuzetka.Checked == false || radioButtonBazePodataka.Checked == false)
                richTextBoxStatistikaIzuzeci.Text = ""; //brise sve ako se deselektuje
        }

        private void radioButtonUIIzuzetak_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUIIzuzetak.Checked == true && radioButtonVrstaIzuzetka.Checked == true)
            {
                foreach (string s in GlobalniLogovi)
                    if (s.Contains("UI")) richTextBoxStatistikaIzuzeci.Text += s + '\n'; //provjerava da li je UI izuzetak sto smo naglasili kod kreiranja istih
            }
            if (radioButtonVrstaIzuzetka.Checked == false || radioButtonUIIzuzetak.Checked == false)
                richTextBoxStatistikaIzuzeci.Text = ""; //brise sve ako se deselektuje
        }

        private void dateTimePickerIzuzetak1_ValueChanged(object sender, EventArgs e)
        {
            radioButtonDatumIzuzetka_CheckedChanged(sender, e);
            if (dateTimePickerIzuzetak1.Value > dateTimePickerIzuzetak2.Value)
                dateTimePickerIzuzetak1.Value = dateTimePickerIzuzetak2.Value; //ne smije pocetak intervala biti iza kraja 

        }

        private void dateTimePickerIzuzetak2_ValueChanged(object sender, EventArgs e)
        {
            radioButtonDatumIzuzetka_CheckedChanged(sender, e);
            if (dateTimePickerIzuzetak2.Value < dateTimePickerIzuzetak1.Value)
                dateTimePickerIzuzetak2.Value = dateTimePickerIzuzetak1.Value; //ne smije kraj intervala biti prije pocetka
        }
    }
}
