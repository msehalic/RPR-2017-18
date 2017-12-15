using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KontrolaZaUnosSlike
{
    public partial class UserControlUnosSlike : UserControl
    {
        public UserControlUnosSlike()
        {
            InitializeComponent();
        }
        public ErrorProvider vratiErrorProvider() => errorProvider1;
        public PictureBox vratiSliku => pictureBox1;
        public DateTime vratiDatumSlike() => dateTimePicker1.Value.Date;
        public Control vratiDateTimePicker() => dateTimePicker1;
        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimePicker1.Value.AddMonths(6) < DateTime.Now) //ako ima preko 6 mjeseci
            {
                this.errorProvider1.SetError(dateTimePicker1, "Unijeli ste datum stariji od 6 mjeseci!");
                toolStripStatusLabel1.Text = "Unijeli ste datum stariji od 6 mjeseci!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
        }
        
        private void UserControlUnosSlike_Load(object sender, EventArgs e)
        {

        }

        private void buttonUcitajSliku_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "jpg files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
