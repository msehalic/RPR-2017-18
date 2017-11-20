namespace LV5_1
{
    partial class FormMenadzmentKorisnika
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxUnos = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUredu = new System.Windows.Forms.Button();
            this.buttonPonisti = new System.Windows.Forms.Button();
            this.buttonUcitavanjeSlike = new System.Windows.Forms.Button();
            this.textBoxLozinka = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTelefon = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxGrad = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDatumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.labelLozinka = new System.Windows.Forms.Label();
            this.labelKorisnickoIme = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBrTelefona = new System.Windows.Forms.Label();
            this.labelGrad = new System.Windows.Forms.Label();
            this.pictureBoxSlikaKorisnika = new System.Windows.Forms.PictureBox();
            this.checkBoxModerator = new System.Windows.Forms.CheckBox();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.textBoxKorisnickoIme = new System.Windows.Forms.TextBox();
            this.groupBoxSpol = new System.Windows.Forms.GroupBox();
            this.radioButtonZensko = new System.Windows.Forms.RadioButton();
            this.radioButtonMusko = new System.Windows.Forms.RadioButton();
            this.textBoxPrezime = new System.Windows.Forms.TextBox();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.labelIme = new System.Windows.Forms.Label();
            this.LabelPrezime = new System.Windows.Forms.Label();
            this.groupBoxPretraga = new System.Windows.Forms.GroupBox();
            this.richTextBoxPretraga = new System.Windows.Forms.RichTextBox();
            this.labelImePretraga = new System.Windows.Forms.Label();
            this.textBoxPretragaIme = new System.Windows.Forms.TextBox();
            this.groupBoxBrisanje = new System.Windows.Forms.GroupBox();
            this.groupBoxUnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlikaKorisnika)).BeginInit();
            this.groupBoxSpol.SuspendLayout();
            this.groupBoxPretraga.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUnos
            // 
            this.groupBoxUnos.Controls.Add(this.label1);
            this.groupBoxUnos.Controls.Add(this.buttonUredu);
            this.groupBoxUnos.Controls.Add(this.buttonPonisti);
            this.groupBoxUnos.Controls.Add(this.buttonUcitavanjeSlike);
            this.groupBoxUnos.Controls.Add(this.textBoxLozinka);
            this.groupBoxUnos.Controls.Add(this.maskedTextBoxTelefon);
            this.groupBoxUnos.Controls.Add(this.comboBoxGrad);
            this.groupBoxUnos.Controls.Add(this.dateTimePickerDatumRodjenja);
            this.groupBoxUnos.Controls.Add(this.labelLozinka);
            this.groupBoxUnos.Controls.Add(this.labelKorisnickoIme);
            this.groupBoxUnos.Controls.Add(this.label3);
            this.groupBoxUnos.Controls.Add(this.labelBrTelefona);
            this.groupBoxUnos.Controls.Add(this.labelGrad);
            this.groupBoxUnos.Controls.Add(this.pictureBoxSlikaKorisnika);
            this.groupBoxUnos.Controls.Add(this.checkBoxModerator);
            this.groupBoxUnos.Controls.Add(this.checkBoxAdmin);
            this.groupBoxUnos.Controls.Add(this.textBoxKorisnickoIme);
            this.groupBoxUnos.Controls.Add(this.groupBoxSpol);
            this.groupBoxUnos.Controls.Add(this.textBoxPrezime);
            this.groupBoxUnos.Controls.Add(this.textBoxIme);
            this.groupBoxUnos.Controls.Add(this.labelIme);
            this.groupBoxUnos.Controls.Add(this.LabelPrezime);
            this.groupBoxUnos.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUnos.Name = "groupBoxUnos";
            this.groupBoxUnos.Size = new System.Drawing.Size(511, 442);
            this.groupBoxUnos.TabIndex = 0;
            this.groupBoxUnos.TabStop = false;
            this.groupBoxUnos.Text = "Unos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Detaljnije informacije možete naći ovdje.";
            // 
            // buttonUredu
            // 
            this.buttonUredu.Location = new System.Drawing.Point(430, 386);
            this.buttonUredu.Name = "buttonUredu";
            this.buttonUredu.Size = new System.Drawing.Size(75, 23);
            this.buttonUredu.TabIndex = 25;
            this.buttonUredu.Text = "Uredu";
            this.buttonUredu.UseVisualStyleBackColor = true;
            // 
            // buttonPonisti
            // 
            this.buttonPonisti.Location = new System.Drawing.Point(341, 386);
            this.buttonPonisti.Name = "buttonPonisti";
            this.buttonPonisti.Size = new System.Drawing.Size(75, 23);
            this.buttonPonisti.TabIndex = 24;
            this.buttonPonisti.Text = "Poništi";
            this.buttonPonisti.UseVisualStyleBackColor = true;
            this.buttonPonisti.Click += new System.EventHandler(this.buttonPonisti_Click);
            // 
            // buttonUcitavanjeSlike
            // 
            this.buttonUcitavanjeSlike.Location = new System.Drawing.Point(363, 198);
            this.buttonUcitavanjeSlike.Name = "buttonUcitavanjeSlike";
            this.buttonUcitavanjeSlike.Size = new System.Drawing.Size(142, 23);
            this.buttonUcitavanjeSlike.TabIndex = 23;
            this.buttonUcitavanjeSlike.Text = "Učitaj sliku... ";
            this.buttonUcitavanjeSlike.UseVisualStyleBackColor = true;
            this.buttonUcitavanjeSlike.Click += new System.EventHandler(this.buttonUcitavanjeSlike_Click);
            // 
            // textBoxLozinka
            // 
            this.textBoxLozinka.Location = new System.Drawing.Point(106, 312);
            this.textBoxLozinka.Name = "textBoxLozinka";
            this.textBoxLozinka.PasswordChar = '*';
            this.textBoxLozinka.Size = new System.Drawing.Size(224, 20);
            this.textBoxLozinka.TabIndex = 22;
            // 
            // maskedTextBoxTelefon
            // 
            this.maskedTextBoxTelefon.Location = new System.Drawing.Point(106, 209);
            this.maskedTextBoxTelefon.Mask = "(999) 000-0000";
            this.maskedTextBoxTelefon.Name = "maskedTextBoxTelefon";
            this.maskedTextBoxTelefon.Size = new System.Drawing.Size(224, 20);
            this.maskedTextBoxTelefon.TabIndex = 21;
            // 
            // comboBoxGrad
            // 
            this.comboBoxGrad.FormattingEnabled = true;
            this.comboBoxGrad.Location = new System.Drawing.Point(105, 170);
            this.comboBoxGrad.Name = "comboBoxGrad";
            this.comboBoxGrad.Size = new System.Drawing.Size(225, 21);
            this.comboBoxGrad.TabIndex = 20;
            // 
            // dateTimePickerDatumRodjenja
            // 
            this.dateTimePickerDatumRodjenja.Location = new System.Drawing.Point(106, 239);
            this.dateTimePickerDatumRodjenja.Name = "dateTimePickerDatumRodjenja";
            this.dateTimePickerDatumRodjenja.Size = new System.Drawing.Size(224, 20);
            this.dateTimePickerDatumRodjenja.TabIndex = 19;
            // 
            // labelLozinka
            // 
            this.labelLozinka.AutoSize = true;
            this.labelLozinka.Location = new System.Drawing.Point(58, 315);
            this.labelLozinka.Name = "labelLozinka";
            this.labelLozinka.Size = new System.Drawing.Size(50, 13);
            this.labelLozinka.TabIndex = 17;
            this.labelLozinka.Text = "Lozinka: ";
            // 
            // labelKorisnickoIme
            // 
            this.labelKorisnickoIme.AutoSize = true;
            this.labelKorisnickoIme.Location = new System.Drawing.Point(27, 277);
            this.labelKorisnickoIme.Name = "labelKorisnickoIme";
            this.labelKorisnickoIme.Size = new System.Drawing.Size(81, 13);
            this.labelKorisnickoIme.TabIndex = 16;
            this.labelKorisnickoIme.Text = "Korisničko ime: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Datum Rođenja: ";
            // 
            // labelBrTelefona
            // 
            this.labelBrTelefona.AutoSize = true;
            this.labelBrTelefona.Location = new System.Drawing.Point(58, 209);
            this.labelBrTelefona.Name = "labelBrTelefona";
            this.labelBrTelefona.Size = new System.Drawing.Size(41, 13);
            this.labelBrTelefona.TabIndex = 14;
            this.labelBrTelefona.Text = "Br. Tel:";
            // 
            // labelGrad
            // 
            this.labelGrad.AutoSize = true;
            this.labelGrad.Location = new System.Drawing.Point(63, 174);
            this.labelGrad.Name = "labelGrad";
            this.labelGrad.Size = new System.Drawing.Size(36, 13);
            this.labelGrad.TabIndex = 13;
            this.labelGrad.Text = "Grad: ";
            // 
            // pictureBoxSlikaKorisnika
            // 
            this.pictureBoxSlikaKorisnika.Location = new System.Drawing.Point(363, 33);
            this.pictureBoxSlikaKorisnika.Name = "pictureBoxSlikaKorisnika";
            this.pictureBoxSlikaKorisnika.Size = new System.Drawing.Size(142, 158);
            this.pictureBoxSlikaKorisnika.TabIndex = 12;
            this.pictureBoxSlikaKorisnika.TabStop = false;
            // 
            // checkBoxModerator
            // 
            this.checkBoxModerator.AutoSize = true;
            this.checkBoxModerator.Location = new System.Drawing.Point(250, 359);
            this.checkBoxModerator.Name = "checkBoxModerator";
            this.checkBoxModerator.Size = new System.Drawing.Size(74, 17);
            this.checkBoxModerator.TabIndex = 11;
            this.checkBoxModerator.Text = "Moderator";
            this.checkBoxModerator.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(138, 359);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(86, 17);
            this.checkBoxAdmin.TabIndex = 10;
            this.checkBoxAdmin.Text = "Administrator";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // textBoxKorisnickoIme
            // 
            this.textBoxKorisnickoIme.Location = new System.Drawing.Point(105, 274);
            this.textBoxKorisnickoIme.Name = "textBoxKorisnickoIme";
            this.textBoxKorisnickoIme.Size = new System.Drawing.Size(225, 20);
            this.textBoxKorisnickoIme.TabIndex = 8;
            // 
            // groupBoxSpol
            // 
            this.groupBoxSpol.Controls.Add(this.radioButtonZensko);
            this.groupBoxSpol.Controls.Add(this.radioButtonMusko);
            this.groupBoxSpol.Location = new System.Drawing.Point(101, 102);
            this.groupBoxSpol.Name = "groupBoxSpol";
            this.groupBoxSpol.Size = new System.Drawing.Size(229, 52);
            this.groupBoxSpol.TabIndex = 4;
            this.groupBoxSpol.TabStop = false;
            this.groupBoxSpol.Text = "Spol";
            // 
            // radioButtonZensko
            // 
            this.radioButtonZensko.AutoSize = true;
            this.radioButtonZensko.Location = new System.Drawing.Point(99, 20);
            this.radioButtonZensko.Name = "radioButtonZensko";
            this.radioButtonZensko.Size = new System.Drawing.Size(61, 17);
            this.radioButtonZensko.TabIndex = 1;
            this.radioButtonZensko.TabStop = true;
            this.radioButtonZensko.Text = "Žensko";
            this.radioButtonZensko.UseVisualStyleBackColor = true;
            // 
            // radioButtonMusko
            // 
            this.radioButtonMusko.AutoSize = true;
            this.radioButtonMusko.Location = new System.Drawing.Point(7, 20);
            this.radioButtonMusko.Name = "radioButtonMusko";
            this.radioButtonMusko.Size = new System.Drawing.Size(57, 17);
            this.radioButtonMusko.TabIndex = 0;
            this.radioButtonMusko.TabStop = true;
            this.radioButtonMusko.Text = "Muško";
            this.radioButtonMusko.UseVisualStyleBackColor = true;
            // 
            // textBoxPrezime
            // 
            this.textBoxPrezime.Location = new System.Drawing.Point(101, 63);
            this.textBoxPrezime.Name = "textBoxPrezime";
            this.textBoxPrezime.Size = new System.Drawing.Size(229, 20);
            this.textBoxPrezime.TabIndex = 3;
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(101, 33);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(229, 20);
            this.textBoxIme.TabIndex = 2;
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.Location = new System.Drawing.Point(64, 36);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(30, 13);
            this.labelIme.TabIndex = 1;
            this.labelIme.Text = "Ime: ";
            // 
            // LabelPrezime
            // 
            this.LabelPrezime.AutoSize = true;
            this.LabelPrezime.Location = new System.Drawing.Point(49, 66);
            this.LabelPrezime.Name = "LabelPrezime";
            this.LabelPrezime.Size = new System.Drawing.Size(50, 13);
            this.LabelPrezime.TabIndex = 0;
            this.LabelPrezime.Text = "Prezime: ";
            // 
            // groupBoxPretraga
            // 
            this.groupBoxPretraga.Controls.Add(this.richTextBoxPretraga);
            this.groupBoxPretraga.Controls.Add(this.labelImePretraga);
            this.groupBoxPretraga.Controls.Add(this.textBoxPretragaIme);
            this.groupBoxPretraga.Location = new System.Drawing.Point(543, 12);
            this.groupBoxPretraga.Name = "groupBoxPretraga";
            this.groupBoxPretraga.Size = new System.Drawing.Size(291, 222);
            this.groupBoxPretraga.TabIndex = 1;
            this.groupBoxPretraga.TabStop = false;
            this.groupBoxPretraga.Text = "Pretraga";
            // 
            // richTextBoxPretraga
            // 
            this.richTextBoxPretraga.Location = new System.Drawing.Point(28, 79);
            this.richTextBoxPretraga.Name = "richTextBoxPretraga";
            this.richTextBoxPretraga.Size = new System.Drawing.Size(257, 125);
            this.richTextBoxPretraga.TabIndex = 2;
            this.richTextBoxPretraga.Text = "";
            // 
            // labelImePretraga
            // 
            this.labelImePretraga.AutoSize = true;
            this.labelImePretraga.Location = new System.Drawing.Point(25, 43);
            this.labelImePretraga.Name = "labelImePretraga";
            this.labelImePretraga.Size = new System.Drawing.Size(27, 13);
            this.labelImePretraga.TabIndex = 1;
            this.labelImePretraga.Text = "Ime:";
            // 
            // textBoxPretragaIme
            // 
            this.textBoxPretragaIme.Location = new System.Drawing.Point(72, 36);
            this.textBoxPretragaIme.Name = "textBoxPretragaIme";
            this.textBoxPretragaIme.Size = new System.Drawing.Size(213, 20);
            this.textBoxPretragaIme.TabIndex = 0;
            // 
            // groupBoxBrisanje
            // 
            this.groupBoxBrisanje.Location = new System.Drawing.Point(543, 244);
            this.groupBoxBrisanje.Name = "groupBoxBrisanje";
            this.groupBoxBrisanje.Size = new System.Drawing.Size(291, 210);
            this.groupBoxBrisanje.TabIndex = 2;
            this.groupBoxBrisanje.TabStop = false;
            this.groupBoxBrisanje.Text = "Brisanje";
            // 
            // FormMenadzmentKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 466);
            this.Controls.Add(this.groupBoxBrisanje);
            this.Controls.Add(this.groupBoxPretraga);
            this.Controls.Add(this.groupBoxUnos);
            this.Name = "FormMenadzmentKorisnika";
            this.Text = "Menadžment Korisnika";
            this.groupBoxUnos.ResumeLayout(false);
            this.groupBoxUnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSlikaKorisnika)).EndInit();
            this.groupBoxSpol.ResumeLayout(false);
            this.groupBoxSpol.PerformLayout();
            this.groupBoxPretraga.ResumeLayout(false);
            this.groupBoxPretraga.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUnos;
        private System.Windows.Forms.GroupBox groupBoxPretraga;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.Label LabelPrezime;
        private System.Windows.Forms.GroupBox groupBoxSpol;
        private System.Windows.Forms.TextBox textBoxPrezime;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.RadioButton radioButtonZensko;
        private System.Windows.Forms.RadioButton radioButtonMusko;
        private System.Windows.Forms.TextBox textBoxKorisnickoIme;
        private System.Windows.Forms.Label labelLozinka;
        private System.Windows.Forms.Label labelKorisnickoIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBrTelefona;
        private System.Windows.Forms.Label labelGrad;
        private System.Windows.Forms.PictureBox pictureBoxSlikaKorisnika;
        private System.Windows.Forms.CheckBox checkBoxModerator;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefon;
        private System.Windows.Forms.ComboBox comboBoxGrad;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumRodjenja;
        private System.Windows.Forms.Button buttonUcitavanjeSlike;
        private System.Windows.Forms.TextBox textBoxLozinka;
        private System.Windows.Forms.Button buttonUredu;
        private System.Windows.Forms.Button buttonPonisti;
        private System.Windows.Forms.Label labelImePretraga;
        private System.Windows.Forms.TextBox textBoxPretragaIme;
        private System.Windows.Forms.RichTextBox richTextBoxPretraga;
        private System.Windows.Forms.GroupBox groupBoxBrisanje;
        private System.Windows.Forms.Label label1;
    }
}

