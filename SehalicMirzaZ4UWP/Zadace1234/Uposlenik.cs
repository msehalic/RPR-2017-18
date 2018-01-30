using System.Text;
using System.Security.Cryptography;
using Windows.UI.Xaml.Controls;

namespace Zadaca1RPR_17324
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
            this.KorisnickoIme = korisnickoIme;
            this.SlikaUposlenika = slikaUposlenika;
            this.Lozinka = GetMd5Hash(MD5.Create(), lozinka); //OSIGURAVA MD5 algoritam
        }

        public string ImeUposlenika { get => imeUposlenika; set => imeUposlenika = value; }
        public string PrezimeUposlenika { get => prezimeUposlenika; set => prezimeUposlenika = value; }
        public int BrojLicence { get => brojLicence; set => brojLicence = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }

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

        public override string ToString()
        {
            return ImeUposlenika + " " + PrezimeUposlenika + ", broj licence: " + BrojLicence;
        }
    }
}
