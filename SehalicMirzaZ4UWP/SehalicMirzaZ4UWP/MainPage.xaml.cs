using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
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
    public sealed partial class MainPage : Page
    {
        Zadaca1RPR_17324.Pacijent pacijent17324_1 = new Zadaca1RPR_17324.Pacijent();
        Zadaca1RPR_17324.Uposlenik uposlenik17324_1 = new Zadaca1RPR_17324.Uposlenik();
        Zadaca1RPR_17324.KlinikaKontejner klinika17324 = new Zadaca1RPR_17324.KlinikaKontejner();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Prijava_Click(object sender, RoutedEventArgs e)
        {
            if (PodaciOkej())
            {
                Unos otvoriMeni = new Unos();
                this.Content = otvoriMeni;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool PodaciOkej()
        {
            bool ispravan = false;
            foreach (Zadaca1RPR_17324.Uposlenik u in klinika17324.Uposlenici) if (u.KorisnickoIme == textKorisnicko.Text && VerifyMd5Hash(MD5.Create(), textLozinka.Text, u.Lozinka))
                {
                    uposlenik17324_1 = u;
                    ispravan = true;
                    return true;
                }
            foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
            {
                if (p.KorisnickoIme == textKorisnicko.Text && VerifyMd5Hash(MD5.Create(), textLozinka.Text, p.Lozinka))
                {
                    pacijent17324_1 = p;
                    ispravan = true;
                    return true;
                }
            }
            if (textLozinka.Text == "") ispravan = false; // prazan string
            if (!ispravan)
            {
                IspisGreskeLogin.Text = "Neispravan unos!";
                return false;
            }
            // if (buttonOdustani_Click) e.Cancel = false;
            return false;
        }

        private void textLozinka_TextChanged(object sender, TextChangedEventArgs e)
        {
            IspisGreskeLogin.Text = "";
        }

        private void Odustajanje_Click(object sender, RoutedEventArgs e)
        {
            textKorisnicko.Text = "";
            textLozinka.Text = "";
            IspisGreskeLogin.Text = "";
        }
    }
}
