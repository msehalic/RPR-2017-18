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
    public sealed partial class MainPage : Page
    {
        KlinikaKontejner klinika17324 = new KlinikaKontejner();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            char spol;
            string bracnoStanjePacijenta = "Ozenjen";
            if (bracnoStanje.SelectedIndex != -1) bracnoStanjePacijenta = bracnoStanje.SelectedItem.ToString();
            if ((bool)Musko.IsChecked) spol = 'm';
            else spol = 'z';
            klinika17324.Pacijenti.Add(new Pacijent(Convert.ToUInt64(MaticniBroj.Text), ImePacijenta.Text, PrezimePacijenta.Text, DatumRodjenja.Date.DateTime, spol, AdresaStanovanja.Text, bracnoStanjePacijenta, DateTime.Now));
        }
    }
}
