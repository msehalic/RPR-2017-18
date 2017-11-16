using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LV5_1
{
    public partial class FormMenadzmentKorisnika : Form
    {
        public FormMenadzmentKorisnika()
        {
            InitializeComponent();
        }

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            textBoxIme.Text = "";
            textBoxPrezime.Text = "";
            radioButtonMusko.Checked = false;
            radioButtonZensko.Checked = false;
            comboBoxGrad.ResetText();
            dateTimePickerDatumRodjenja.ResetText();
            maskedTextBoxTelefon.ResetText();
            textBoxKorisnickoIme.Text = "";
            textBoxLozinka.Text = "";
            pictureBoxSlikaKorisnika.ResetText();
            checkBoxAdmin.Checked = false;
            checkBoxModerator.Checked = false;
            textBoxPretragaIme.Text = "";
            richTextBoxPretraga.Text = "";
        }
        private void buttonUcitavanjeSlike_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Izaberite sliku"; dlg.Filter = "jpg files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK) { pictureBoxSlikaKorisnika.Image = new Bitmap(dlg.FileName); }
            }
        }
    }
}
