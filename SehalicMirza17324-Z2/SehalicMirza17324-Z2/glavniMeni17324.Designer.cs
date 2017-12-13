namespace SehalicMirza17324_Z2
{
    partial class glavniMeni17324
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(glavniMeni17324));
            this.tabControlGlavniMeni = new System.Windows.Forms.TabControl();
            this.tabPageUnosPacijenata = new System.Windows.Forms.TabPage();
            this.groupBoxBrisanjePacijenata = new System.Windows.Forms.GroupBox();
            this.groupBoxUnosPacijenata = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAdresa = new System.Windows.Forms.TextBox();
            this.labelAdresaStanovanja = new System.Windows.Forms.Label();
            this.groupBoxSpol = new System.Windows.Forms.GroupBox();
            this.radioButtonZ = new System.Windows.Forms.RadioButton();
            this.radioButtonM = new System.Windows.Forms.RadioButton();
            this.labelMaticniBroj = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelDatumRodjenja = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelPrezime = new System.Windows.Forms.Label();
            this.labelIme = new System.Windows.Forms.Label();
            this.tabPageRaspored = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxBracnoStanje = new System.Windows.Forms.GroupBox();
            this.radioButtonOzenjen = new System.Windows.Forms.RadioButton();
            this.radioButtonRazveden = new System.Windows.Forms.RadioButton();
            this.radioButtonNeozenjen = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBoxIzborLjekara = new System.Windows.Forms.GroupBox();
            this.checkBoxOrtoped = new System.Windows.Forms.CheckBox();
            this.checkBoxStomatolog = new System.Windows.Forms.CheckBox();
            this.checkBoxKardiolog = new System.Windows.Forms.CheckBox();
            this.checkBoxDermatolog = new System.Windows.Forms.CheckBox();
            this.tabControlGlavniMeni.SuspendLayout();
            this.tabPageUnosPacijenata.SuspendLayout();
            this.groupBoxUnosPacijenata.SuspendLayout();
            this.groupBoxSpol.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.groupBoxBracnoStanje.SuspendLayout();
            this.groupBoxIzborLjekara.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGlavniMeni
            // 
            this.tabControlGlavniMeni.Controls.Add(this.tabPageUnosPacijenata);
            this.tabControlGlavniMeni.Controls.Add(this.tabPageRaspored);
            this.tabControlGlavniMeni.Controls.Add(this.tabPage3);
            this.tabControlGlavniMeni.Controls.Add(this.tabPage4);
            this.tabControlGlavniMeni.Controls.Add(this.tabPage5);
            this.tabControlGlavniMeni.Controls.Add(this.tabPage6);
            this.tabControlGlavniMeni.Location = new System.Drawing.Point(-3, 12);
            this.tabControlGlavniMeni.Name = "tabControlGlavniMeni";
            this.tabControlGlavniMeni.SelectedIndex = 0;
            this.tabControlGlavniMeni.Size = new System.Drawing.Size(967, 524);
            this.tabControlGlavniMeni.TabIndex = 0;
            // 
            // tabPageUnosPacijenata
            // 
            this.tabPageUnosPacijenata.Controls.Add(this.groupBoxBrisanjePacijenata);
            this.tabPageUnosPacijenata.Controls.Add(this.groupBoxUnosPacijenata);
            this.tabPageUnosPacijenata.Location = new System.Drawing.Point(4, 22);
            this.tabPageUnosPacijenata.Name = "tabPageUnosPacijenata";
            this.tabPageUnosPacijenata.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUnosPacijenata.Size = new System.Drawing.Size(959, 498);
            this.tabPageUnosPacijenata.TabIndex = 0;
            this.tabPageUnosPacijenata.Text = "Unos/Brisanje Pacijenata";
            this.tabPageUnosPacijenata.UseVisualStyleBackColor = true;
            // 
            // groupBoxBrisanjePacijenata
            // 
            this.groupBoxBrisanjePacijenata.Location = new System.Drawing.Point(469, 3);
            this.groupBoxBrisanjePacijenata.Name = "groupBoxBrisanjePacijenata";
            this.groupBoxBrisanjePacijenata.Size = new System.Drawing.Size(482, 492);
            this.groupBoxBrisanjePacijenata.TabIndex = 1;
            this.groupBoxBrisanjePacijenata.TabStop = false;
            this.groupBoxBrisanjePacijenata.Text = "Brisanje Pacijenata";
            this.groupBoxBrisanjePacijenata.Enter += new System.EventHandler(this.groupBoxBrisanjePacijenata_Enter);
            // 
            // groupBoxUnosPacijenata
            // 
            this.groupBoxUnosPacijenata.Controls.Add(this.groupBoxIzborLjekara);
            this.groupBoxUnosPacijenata.Controls.Add(this.groupBoxBracnoStanje);
            this.groupBoxUnosPacijenata.Controls.Add(this.button1);
            this.groupBoxUnosPacijenata.Controls.Add(this.textBoxAdresa);
            this.groupBoxUnosPacijenata.Controls.Add(this.labelAdresaStanovanja);
            this.groupBoxUnosPacijenata.Controls.Add(this.groupBoxSpol);
            this.groupBoxUnosPacijenata.Controls.Add(this.labelMaticniBroj);
            this.groupBoxUnosPacijenata.Controls.Add(this.maskedTextBox1);
            this.groupBoxUnosPacijenata.Controls.Add(this.dateTimePicker1);
            this.groupBoxUnosPacijenata.Controls.Add(this.labelDatumRodjenja);
            this.groupBoxUnosPacijenata.Controls.Add(this.textBox2);
            this.groupBoxUnosPacijenata.Controls.Add(this.textBox1);
            this.groupBoxUnosPacijenata.Controls.Add(this.labelPrezime);
            this.groupBoxUnosPacijenata.Controls.Add(this.labelIme);
            this.groupBoxUnosPacijenata.Location = new System.Drawing.Point(-4, 0);
            this.groupBoxUnosPacijenata.Name = "groupBoxUnosPacijenata";
            this.groupBoxUnosPacijenata.Size = new System.Drawing.Size(477, 498);
            this.groupBoxUnosPacijenata.TabIndex = 0;
            this.groupBoxUnosPacijenata.TabStop = false;
            this.groupBoxUnosPacijenata.Text = "Unos Pacijenata";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 460);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Unesi!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxAdresa
            // 
            this.textBoxAdresa.Location = new System.Drawing.Point(92, 159);
            this.textBoxAdresa.Name = "textBoxAdresa";
            this.textBoxAdresa.Size = new System.Drawing.Size(147, 20);
            this.textBoxAdresa.TabIndex = 11;
            this.textBoxAdresa.TextChanged += new System.EventHandler(this.textBoxAdresa_TextChanged);
            this.textBoxAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAdresa_Validating);
            this.textBoxAdresa.Validated += new System.EventHandler(this.textBoxAdresa_Validated);
            // 
            // labelAdresaStanovanja
            // 
            this.labelAdresaStanovanja.AutoSize = true;
            this.labelAdresaStanovanja.Location = new System.Drawing.Point(36, 162);
            this.labelAdresaStanovanja.Name = "labelAdresaStanovanja";
            this.labelAdresaStanovanja.Size = new System.Drawing.Size(43, 13);
            this.labelAdresaStanovanja.TabIndex = 10;
            this.labelAdresaStanovanja.Text = "Adresa:";
            // 
            // groupBoxSpol
            // 
            this.groupBoxSpol.Controls.Add(this.radioButtonZ);
            this.groupBoxSpol.Controls.Add(this.radioButtonM);
            this.groupBoxSpol.Location = new System.Drawing.Point(18, 122);
            this.groupBoxSpol.Name = "groupBoxSpol";
            this.groupBoxSpol.Size = new System.Drawing.Size(221, 37);
            this.groupBoxSpol.TabIndex = 9;
            this.groupBoxSpol.TabStop = false;
            this.groupBoxSpol.Text = "Spol";
            // 
            // radioButtonZ
            // 
            this.radioButtonZ.AutoSize = true;
            this.radioButtonZ.Location = new System.Drawing.Point(138, 14);
            this.radioButtonZ.Name = "radioButtonZ";
            this.radioButtonZ.Size = new System.Drawing.Size(61, 17);
            this.radioButtonZ.TabIndex = 1;
            this.radioButtonZ.Text = "Žensko";
            this.radioButtonZ.UseVisualStyleBackColor = true;
            // 
            // radioButtonM
            // 
            this.radioButtonM.AutoSize = true;
            this.radioButtonM.Checked = true;
            this.radioButtonM.Location = new System.Drawing.Point(44, 14);
            this.radioButtonM.Name = "radioButtonM";
            this.radioButtonM.Size = new System.Drawing.Size(57, 17);
            this.radioButtonM.TabIndex = 0;
            this.radioButtonM.TabStop = true;
            this.radioButtonM.Text = "Muško";
            this.radioButtonM.UseVisualStyleBackColor = true;
            // 
            // labelMaticniBroj
            // 
            this.labelMaticniBroj.AutoSize = true;
            this.labelMaticniBroj.Location = new System.Drawing.Point(22, 99);
            this.labelMaticniBroj.Name = "labelMaticniBroj";
            this.labelMaticniBroj.Size = new System.Drawing.Size(64, 13);
            this.labelMaticniBroj.TabIndex = 8;
            this.labelMaticniBroj.Text = "Matični broj:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(92, 96);
            this.maskedTextBox1.Mask = "0000000000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(147, 20);
            this.maskedTextBox1.TabIndex = 7;
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            this.maskedTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox1_Validating);
            this.maskedTextBox1.Validated += new System.EventHandler(this.maskedTextBox1_Validated);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // labelDatumRodjenja
            // 
            this.labelDatumRodjenja.AutoSize = true;
            this.labelDatumRodjenja.Location = new System.Drawing.Point(6, 76);
            this.labelDatumRodjenja.Name = "labelDatumRodjenja";
            this.labelDatumRodjenja.Size = new System.Drawing.Size(80, 13);
            this.labelDatumRodjenja.TabIndex = 4;
            this.labelDatumRodjenja.Text = "Datum rođenja:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(147, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            this.textBox2.Validated += new System.EventHandler(this.textBox2_Validated);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // labelPrezime
            // 
            this.labelPrezime.AutoSize = true;
            this.labelPrezime.Location = new System.Drawing.Point(39, 52);
            this.labelPrezime.Name = "labelPrezime";
            this.labelPrezime.Size = new System.Drawing.Size(47, 13);
            this.labelPrezime.TabIndex = 1;
            this.labelPrezime.Text = "Prezime:";
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.Location = new System.Drawing.Point(59, 29);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(27, 13);
            this.labelIme.TabIndex = 0;
            this.labelIme.Text = "Ime:";
            // 
            // tabPageRaspored
            // 
            this.tabPageRaspored.Location = new System.Drawing.Point(4, 22);
            this.tabPageRaspored.Name = "tabPageRaspored";
            this.tabPageRaspored.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRaspored.Size = new System.Drawing.Size(959, 498);
            this.tabPageRaspored.TabIndex = 1;
            this.tabPageRaspored.Text = "Raspored Pregleda";
            this.tabPageRaspored.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(704, 282);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(704, 282);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(704, 282);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(704, 282);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 539);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(964, 22);
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip1";
            this.statusStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // groupBoxBracnoStanje
            // 
            this.groupBoxBracnoStanje.Controls.Add(this.radioButton4);
            this.groupBoxBracnoStanje.Controls.Add(this.radioButtonNeozenjen);
            this.groupBoxBracnoStanje.Controls.Add(this.radioButtonRazveden);
            this.groupBoxBracnoStanje.Controls.Add(this.radioButtonOzenjen);
            this.groupBoxBracnoStanje.Location = new System.Drawing.Point(18, 194);
            this.groupBoxBracnoStanje.Name = "groupBoxBracnoStanje";
            this.groupBoxBracnoStanje.Size = new System.Drawing.Size(314, 73);
            this.groupBoxBracnoStanje.TabIndex = 13;
            this.groupBoxBracnoStanje.TabStop = false;
            this.groupBoxBracnoStanje.Text = "Bračno stanje";
            // 
            // radioButtonOzenjen
            // 
            this.radioButtonOzenjen.AutoSize = true;
            this.radioButtonOzenjen.Location = new System.Drawing.Point(3, 19);
            this.radioButtonOzenjen.Name = "radioButtonOzenjen";
            this.radioButtonOzenjen.Size = new System.Drawing.Size(98, 17);
            this.radioButtonOzenjen.TabIndex = 0;
            this.radioButtonOzenjen.TabStop = true;
            this.radioButtonOzenjen.Text = "Oženjen/Udata";
            this.radioButtonOzenjen.UseVisualStyleBackColor = true;
            // 
            // radioButtonRazveden
            // 
            this.radioButtonRazveden.AutoSize = true;
            this.radioButtonRazveden.Location = new System.Drawing.Point(170, 20);
            this.radioButtonRazveden.Name = "radioButtonRazveden";
            this.radioButtonRazveden.Size = new System.Drawing.Size(86, 17);
            this.radioButtonRazveden.TabIndex = 1;
            this.radioButtonRazveden.TabStop = true;
            this.radioButtonRazveden.Text = "Razveden(a)";
            this.radioButtonRazveden.UseVisualStyleBackColor = true;
            // 
            // radioButtonNeozenjen
            // 
            this.radioButtonNeozenjen.AutoSize = true;
            this.radioButtonNeozenjen.Location = new System.Drawing.Point(2, 43);
            this.radioButtonNeozenjen.Name = "radioButtonNeozenjen";
            this.radioButtonNeozenjen.Size = new System.Drawing.Size(122, 17);
            this.radioButtonNeozenjen.TabIndex = 2;
            this.radioButtonNeozenjen.TabStop = true;
            this.radioButtonNeozenjen.Text = "Neoženjen/Neudata";
            this.radioButtonNeozenjen.UseVisualStyleBackColor = true;
            this.radioButtonNeozenjen.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(170, 43);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(108, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Udovac/Udovica";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupBoxIzborLjekara
            // 
            this.groupBoxIzborLjekara.Controls.Add(this.checkBoxDermatolog);
            this.groupBoxIzborLjekara.Controls.Add(this.checkBoxKardiolog);
            this.groupBoxIzborLjekara.Controls.Add(this.checkBoxStomatolog);
            this.groupBoxIzborLjekara.Controls.Add(this.checkBoxOrtoped);
            this.groupBoxIzborLjekara.Location = new System.Drawing.Point(18, 273);
            this.groupBoxIzborLjekara.Name = "groupBoxIzborLjekara";
            this.groupBoxIzborLjekara.Size = new System.Drawing.Size(314, 71);
            this.groupBoxIzborLjekara.TabIndex = 14;
            this.groupBoxIzborLjekara.TabStop = false;
            this.groupBoxIzborLjekara.Text = "Izbor ljekara kod kojeg vrši pregled";
            // 
            // checkBoxOrtoped
            // 
            this.checkBoxOrtoped.AutoSize = true;
            this.checkBoxOrtoped.Location = new System.Drawing.Point(21, 19);
            this.checkBoxOrtoped.Name = "checkBoxOrtoped";
            this.checkBoxOrtoped.Size = new System.Drawing.Size(64, 17);
            this.checkBoxOrtoped.TabIndex = 0;
            this.checkBoxOrtoped.Text = "Ortoped";
            this.checkBoxOrtoped.UseVisualStyleBackColor = true;
            // 
            // checkBoxStomatolog
            // 
            this.checkBoxStomatolog.AutoSize = true;
            this.checkBoxStomatolog.Location = new System.Drawing.Point(176, 19);
            this.checkBoxStomatolog.Name = "checkBoxStomatolog";
            this.checkBoxStomatolog.Size = new System.Drawing.Size(79, 17);
            this.checkBoxStomatolog.TabIndex = 1;
            this.checkBoxStomatolog.Text = "Stomatolog";
            this.checkBoxStomatolog.UseVisualStyleBackColor = true;
            // 
            // checkBoxKardiolog
            // 
            this.checkBoxKardiolog.AutoSize = true;
            this.checkBoxKardiolog.Location = new System.Drawing.Point(21, 42);
            this.checkBoxKardiolog.Name = "checkBoxKardiolog";
            this.checkBoxKardiolog.Size = new System.Drawing.Size(70, 17);
            this.checkBoxKardiolog.TabIndex = 2;
            this.checkBoxKardiolog.Text = "Kardiolog";
            this.checkBoxKardiolog.UseVisualStyleBackColor = true;
            // 
            // checkBoxDermatolog
            // 
            this.checkBoxDermatolog.AutoSize = true;
            this.checkBoxDermatolog.Location = new System.Drawing.Point(176, 42);
            this.checkBoxDermatolog.Name = "checkBoxDermatolog";
            this.checkBoxDermatolog.Size = new System.Drawing.Size(80, 17);
            this.checkBoxDermatolog.TabIndex = 3;
            this.checkBoxDermatolog.Text = "Dermatolog";
            this.checkBoxDermatolog.UseVisualStyleBackColor = true;
            // 
            // glavniMeni17324
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(964, 561);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.tabControlGlavniMeni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "glavniMeni17324";
            this.Text = "Klinika \'Dr Sehalic\'";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.glavniMeni17324_FormClosed);
            this.Load += new System.EventHandler(this.glavniMeni17324_Load);
            this.tabControlGlavniMeni.ResumeLayout(false);
            this.tabPageUnosPacijenata.ResumeLayout(false);
            this.groupBoxUnosPacijenata.ResumeLayout(false);
            this.groupBoxUnosPacijenata.PerformLayout();
            this.groupBoxSpol.ResumeLayout(false);
            this.groupBoxSpol.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.groupBoxBracnoStanje.ResumeLayout(false);
            this.groupBoxBracnoStanje.PerformLayout();
            this.groupBoxIzborLjekara.ResumeLayout(false);
            this.groupBoxIzborLjekara.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGlavniMeni;
        private System.Windows.Forms.TabPage tabPageUnosPacijenata;
        private System.Windows.Forms.TabPage tabPageRaspored;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBoxBrisanjePacijenata;
        private System.Windows.Forms.GroupBox groupBoxUnosPacijenata;
        private System.Windows.Forms.Label labelPrezime;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.Label labelDatumRodjenja;
        private System.Windows.Forms.Label labelMaticniBroj;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBoxSpol;
        private System.Windows.Forms.RadioButton radioButtonZ;
        private System.Windows.Forms.RadioButton radioButtonM;
        private System.Windows.Forms.Label labelAdresaStanovanja;
        private System.Windows.Forms.TextBox textBoxAdresa;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxBracnoStanje;
        private System.Windows.Forms.RadioButton radioButtonNeozenjen;
        private System.Windows.Forms.RadioButton radioButtonRazveden;
        private System.Windows.Forms.RadioButton radioButtonOzenjen;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox groupBoxIzborLjekara;
        private System.Windows.Forms.CheckBox checkBoxDermatolog;
        private System.Windows.Forms.CheckBox checkBoxKardiolog;
        private System.Windows.Forms.CheckBox checkBoxStomatolog;
        private System.Windows.Forms.CheckBox checkBoxOrtoped;
    }
}