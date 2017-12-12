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
        public glavniMeni17324()
        {
            InitializeComponent();
        }

        private void glavniMeni17324_Load(object sender, EventArgs e)
        {

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
    }
}
