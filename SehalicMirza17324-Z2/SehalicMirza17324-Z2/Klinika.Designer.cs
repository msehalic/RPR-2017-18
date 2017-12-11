namespace SehalicMirza17324_Z2
{
    partial class Klinika
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
            this.textboxUnosImena = new System.Windows.Forms.TextBox();
            this.textBoxUnosSifre = new System.Windows.Forms.TextBox();
            this.labelKorisnickoIme = new System.Windows.Forms.Label();
            this.labelLozinka = new System.Windows.Forms.Label();
            this.buttonPrijava = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxUnosImena
            // 
            this.textboxUnosImena.Location = new System.Drawing.Point(250, 105);
            this.textboxUnosImena.Name = "textboxUnosImena";
            this.textboxUnosImena.Size = new System.Drawing.Size(200, 20);
            this.textboxUnosImena.TabIndex = 0;
            // 
            // textBoxUnosSifre
            // 
            this.textBoxUnosSifre.Location = new System.Drawing.Point(250, 131);
            this.textBoxUnosSifre.Name = "textBoxUnosSifre";
            this.textBoxUnosSifre.PasswordChar = '*';
            this.textBoxUnosSifre.Size = new System.Drawing.Size(200, 20);
            this.textBoxUnosSifre.TabIndex = 1;
            // 
            // labelKorisnickoIme
            // 
            this.labelKorisnickoIme.AutoSize = true;
            this.labelKorisnickoIme.Location = new System.Drawing.Point(166, 108);
            this.labelKorisnickoIme.Name = "labelKorisnickoIme";
            this.labelKorisnickoIme.Size = new System.Drawing.Size(78, 13);
            this.labelKorisnickoIme.TabIndex = 3;
            this.labelKorisnickoIme.Text = "Korisničko ime:";
            this.labelKorisnickoIme.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelLozinka
            // 
            this.labelLozinka.AutoSize = true;
            this.labelLozinka.Location = new System.Drawing.Point(166, 134);
            this.labelLozinka.Name = "labelLozinka";
            this.labelLozinka.Size = new System.Drawing.Size(50, 13);
            this.labelLozinka.TabIndex = 4;
            this.labelLozinka.Text = "Lozinka: ";
            this.labelLozinka.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonPrijava
            // 
            this.buttonPrijava.Location = new System.Drawing.Point(284, 174);
            this.buttonPrijava.Name = "buttonPrijava";
            this.buttonPrijava.Size = new System.Drawing.Size(75, 23);
            this.buttonPrijava.TabIndex = 5;
            this.buttonPrijava.Text = "Prijavi se";
            this.buttonPrijava.UseMnemonic = false;
            this.buttonPrijava.UseVisualStyleBackColor = true;
            this.buttonPrijava.Click += new System.EventHandler(this.buttonPrijava_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.Location = new System.Drawing.Point(365, 174);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(75, 23);
            this.buttonOdustani.TabIndex = 6;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonOdustani_Click);
            // 
            // Klinika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(488, 219);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonPrijava);
            this.Controls.Add(this.labelLozinka);
            this.Controls.Add(this.labelKorisnickoIme);
            this.Controls.Add(this.textBoxUnosSifre);
            this.Controls.Add(this.textboxUnosImena);
            this.Name = "Klinika";
            this.Text = "Klinika \'Dr Sehalic\'";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxUnosImena;
        private System.Windows.Forms.TextBox textBoxUnosSifre;
        private System.Windows.Forms.Label labelKorisnickoIme;
        private System.Windows.Forms.Label labelLozinka;
        private System.Windows.Forms.Button buttonPrijava;
        private System.Windows.Forms.Button buttonOdustani;
    }
}

