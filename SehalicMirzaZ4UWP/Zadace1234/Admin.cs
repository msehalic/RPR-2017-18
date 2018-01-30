using Windows.UI.Xaml.Controls;

namespace Zadaca1RPR_17324
{
    public class Administrator : Uposlenik
    {
        //da postoji funkcionalnost
        public Administrator()
        {
        }

        public Administrator(string imeUposlenika, string prezimeUposlenika, int brojLicence) : base(imeUposlenika, prezimeUposlenika, brojLicence)
        {
        }

        public Administrator(string imeUposlenika, string prezimeUposlenika, Image slikaUposlenika, int brojLicence, string korisnickoIme, string lozinka) : base(imeUposlenika, prezimeUposlenika, slikaUposlenika, brojLicence, korisnickoIme, lozinka)
        {
        }
    }
}
