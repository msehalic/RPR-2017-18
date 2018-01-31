using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SehalicMirzaZ4UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        Zadaca1RPR_17324.KlinikaKontejner klinika17324;
        public BlankPage1(Zadaca1RPR_17324.KlinikaKontejner k)
        {
            this.InitializeComponent();
            klinika17324 = k;
        }
        private void PacijentZaBrisanje_TextChanged(object sender, TextChangedEventArgs e)
        {
            PronadjeniZaBrisanje.Items.Clear();
            IspisGresakaBrisanje.Text = "";
            if (PacijentZaBrisanje.Text.Length != 0) //ne zelimo izlistavati na prazno
                foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
                {
                    if ((p.Ime + " " + p.Prezime).IndexOf(PacijentZaBrisanje.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        PronadjeniZaBrisanje.Items.Add(p);
                    }
                }
        }

        private void MenuFlyoutItem2_Click(object sender, RoutedEventArgs e)
        {
            MainPage unos = new MainPage(klinika17324);
            this.Content = unos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PronadjeniZaBrisanje.SelectedIndex != -1)
            {
                Zadaca1RPR_17324.Pacijent pacijent17324 = (Zadaca1RPR_17324.Pacijent)PronadjeniZaBrisanje.SelectedItem;
                klinika17324.Pacijenti.Remove(pacijent17324);
                IspisGresakaBrisanje.Text = "Uspjesno obrisan pacijent!";
            }
        }
    }
}
