using Windows.UI.Xaml.Controls;

namespace Zadaca1RPR_17324
{
    public class Tehnicar : Uposlenik
    {
        //cisto da postoji funkcionalnost
        public Tehnicar()
        {
        }

        public Tehnicar(string imeUposlenika, string prezimeUposlenika, int brojLicence) : base(imeUposlenika, prezimeUposlenika, brojLicence)
        {
        }

        public Tehnicar(string imeUposlenika, string prezimeUposlenika, Image slikaUposlenika, int brojLicence, string korisnickoIme, string lozinka) : base(imeUposlenika, prezimeUposlenika, slikaUposlenika, brojLicence, korisnickoIme, lozinka)
        {
        }
    }
}
