namespace SehalicMirza17324_Z2
{
    partial class Z4_Zadatak2_Pretraga
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonIzborPocetnogDirektorija = new System.Windows.Forms.Button();
            this.listBoxIzlistajDirektorije = new System.Windows.Forms.ListBox();
            this.buttonPretraziDirektorije = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Izaberite početni direktorij...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonIzborPocetnogDirektorija
            // 
            this.buttonIzborPocetnogDirektorija.Location = new System.Drawing.Point(106, 23);
            this.buttonIzborPocetnogDirektorija.Name = "buttonIzborPocetnogDirektorija";
            this.buttonIzborPocetnogDirektorija.Size = new System.Drawing.Size(165, 23);
            this.buttonIzborPocetnogDirektorija.TabIndex = 0;
            this.buttonIzborPocetnogDirektorija.Text = "Izaberi početni direktorij...";
            this.buttonIzborPocetnogDirektorija.UseVisualStyleBackColor = true;
            this.buttonIzborPocetnogDirektorija.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxIzlistajDirektorije
            // 
            this.listBoxIzlistajDirektorije.FormattingEnabled = true;
            this.listBoxIzlistajDirektorije.Location = new System.Drawing.Point(29, 52);
            this.listBoxIzlistajDirektorije.Name = "listBoxIzlistajDirektorije";
            this.listBoxIzlistajDirektorije.Size = new System.Drawing.Size(323, 147);
            this.listBoxIzlistajDirektorije.TabIndex = 1;
            // 
            // buttonPretraziDirektorije
            // 
            this.buttonPretraziDirektorije.Location = new System.Drawing.Point(106, 205);
            this.buttonPretraziDirektorije.Name = "buttonPretraziDirektorije";
            this.buttonPretraziDirektorije.Size = new System.Drawing.Size(165, 23);
            this.buttonPretraziDirektorije.TabIndex = 2;
            this.buttonPretraziDirektorije.Text = "Pretraži!";
            this.buttonPretraziDirektorije.UseVisualStyleBackColor = true;
            this.buttonPretraziDirektorije.Click += new System.EventHandler(this.buttonPretraziDirektorije_Click);
            // 
            // Z4_Zadatak2_Pretraga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 261);
            this.Controls.Add(this.buttonPretraziDirektorije);
            this.Controls.Add(this.listBoxIzlistajDirektorije);
            this.Controls.Add(this.buttonIzborPocetnogDirektorija);
            this.Name = "Z4_Zadatak2_Pretraga";
            this.Text = "Z4_Zadatak2_Pretraga";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonIzborPocetnogDirektorija;
        private System.Windows.Forms.ListBox listBoxIzlistajDirektorije;
        private System.Windows.Forms.Button buttonPretraziDirektorije;
    }
}