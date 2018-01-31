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
using Zadaca1RPR_17324;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
namespace SehalicMirzaZ4UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Unos : Page
    {
        KlinikaKontejner klinika17324 = new KlinikaKontejner();
        public Unos()
        {
            this.InitializeComponent();
        }
        public Unos(Zadaca1RPR_17324.KlinikaKontejner k)
        {
            this.InitializeComponent();
            klinika17324 = k;
        }
        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        private bool ProvjeriIme()
        {
            bool imaSamoSlova = ImePacijenta.Text.Any(char.IsLetter);
            if (imaSamoSlova == false) IspisGresaka.Text = "Uneseno ime sadrzi nedozvoljene znakove!";
            return imaSamoSlova;
        }
        private bool ProvjeriPrezime()
        {
            bool imaSamoSlova = PrezimePacijenta.Text.Any(char.IsLetter);
            if (imaSamoSlova == false) IspisGresaka.Text = "Uneseno prezime sadrzi nedozvoljene znakove!";
            return imaSamoSlova;
        }
        private bool ProvjeriAdresu()
        {
            bool imaSamoSlova = AdresaStanovanja.Text.Any(char.IsLetter);
            if (imaSamoSlova == false) IspisGresaka.Text = "Unesena adresa sadrzi nedozvoljene znakove!";
            return imaSamoSlova;
        }
        private bool ProvjeriMaticniBroj()
        {
            if (!(MaticniBroj.Text.Length == 13))
            {
                IspisGresaka.Text = "Neispravan maticni broj!";
                return false;
            }
            else
            {
                //provjerimo sada prvi dio maticnog broja
                string datumUString = DatumRodjenja.Date.DateTime.ToString("ddMMyyyy");
                datumUString = datumUString.Remove(4, 1); //cifra hiljadica godine rodjenja
                string maticniUString = MaticniBroj.Text.Substring(0, MaticniBroj.Text.Length - 6); //skratimo 6 posljednjih cifara
                //ImePacijenta.Text = datumUString + " " + maticniUString + " " + MaticniBroj.Text.Length;
                if (datumUString.Equals(maticniUString) == false)
                {
                    IspisGresaka.Text = "Neispravan maticni broj!";
                    return false;
                }
            }
            return true;
        }
        private bool ProvjeriBracnoStanje()
        {
            if (bracnoStanje.SelectedIndex == -1)
            {
                IspisGresaka.Text = "Niste selektirali bracno stanje pacijenta!";
                return false;
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char spol;
            string bracnoStanjePacijenta = "Ozenjen";
            if (bracnoStanje.SelectedIndex != -1) bracnoStanjePacijenta = bracnoStanje.SelectedItem.ToString();
            if ((bool)Musko.IsChecked) spol = 'm';
            else spol = 'z';
            if (ProvjeriAdresu() && ProvjeriIme() && ProvjeriPrezime() && ProvjeriMaticniBroj() && ProvjeriBracnoStanje()) //ako je sve ok
            {
                klinika17324.Pacijenti.Add(new Pacijent(Convert.ToUInt64(MaticniBroj.Text), ImePacijenta.Text, PrezimePacijenta.Text, DatumRodjenja.Date.DateTime, spol, AdresaStanovanja.Text, bracnoStanjePacijenta, DateTime.Now));
                IspisGresaka.Text = "Uspjesno dodan pacijent " + ImePacijenta.Text + " " + PrezimePacijenta.Text;
            }
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            BlankPage1 brisanje = new BlankPage1(klinika17324); //kreira formu i salje podatke o kontejnerskoj
            this.Content = brisanje;
        }
    }
}
