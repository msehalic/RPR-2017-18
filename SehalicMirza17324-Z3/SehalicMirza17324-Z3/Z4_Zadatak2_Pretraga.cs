using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SehalicMirza17324_Z2
{
    public partial class Z4_Zadatak2_Pretraga : Form
    {
        public Z4_Zadatak2_Pretraga()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }
        private async void IzlistajDirektorije()
        {
            SearchOption rekurzivnoSve = SearchOption.AllDirectories;
            var ListaFoldera = Directory.GetDirectories(folderBrowserDialog1.SelectedPath, "*", rekurzivnoSve);
            foreach (object o in ListaFoldera)
            {
                await Task.Delay(500);
                listBoxIzlistajDirektorije.Items.Add(o);
            }
        }
        private void buttonPretraziDirektorije_Click(object sender, EventArgs e)
        {
            IzlistajDirektorije();
        }
    }
}
