using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;

namespace Doktori
{

   public class Uposlenik
    {
        string imeUposlenika;
        string prezimeUposlenika;
        int brojLicence;
        Image slikaUposlenika;
        string korisnickoIme;
        string lozinka;
        public Uposlenik()
        {
            ImeUposlenika = "Dietrich";
            PrezimeUposlenika = "Uposlenicic";
            BrojLicence = 0;
        }
        public Uposlenik(string imeUposlenika, string prezimeUposlenika, int brojLicence)
        {
            this.ImeUposlenika = imeUposlenika;
            this.PrezimeUposlenika = prezimeUposlenika;
            this.BrojLicence = brojLicence;
        }

        public Uposlenik(string imeUposlenika, string prezimeUposlenika, Image slikaUposlenika, int brojLicence, string korisnickoIme, string lozinka) : this(imeUposlenika, prezimeUposlenika, brojLicence)
        {
            this.KorisnickoIme1 = korisnickoIme;
            this.SlikaUposlenika = slikaUposlenika;
            this.Lozinka1 = GetMd5Hash(MD5.Create(), lozinka); //OSIGURAVA MD5 algoritam
        }

        public string ImeUposlenika { get => ImeUposlenika1; set => ImeUposlenika1 = value; }
        public string PrezimeUposlenika { get => PrezimeUposlenika1; set => PrezimeUposlenika1 = value; }
        public int BrojLicence { get => BrojLicence1; set => BrojLicence1 = value; }
        public string ImeUposlenika1 { get => ImeUposlenika2; set => ImeUposlenika2 = value; }
        public string PrezimeUposlenika1 { get => PrezimeUposlenika2; set => PrezimeUposlenika2 = value; }
        public int BrojLicence1 { get => BrojLicence2; set => BrojLicence2 = value; }
        public string KorisnickoIme { get => KorisnickoIme1; set => KorisnickoIme1 = value; }
        public string Lozinka { get => Lozinka1; set => Lozinka1 = value; }
        public string ImeUposlenika2 { get => imeUposlenika; set => imeUposlenika = value; }
        public string PrezimeUposlenika2 { get => prezimeUposlenika; set => prezimeUposlenika = value; }
        public int BrojLicence2 { get => brojLicence; set => brojLicence = value; }
        public string KorisnickoIme1 { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka1 { get => lozinka; set => lozinka = value; }
        public Image SlikaUposlenika { get => slikaUposlenika; set => slikaUposlenika = value; }

        static string GetMd5Hash(MD5 md5Hash, string input) //sluzbena dokumentacija
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
    }
}
