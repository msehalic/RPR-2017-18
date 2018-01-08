using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Doktori
{
    [Serializable]
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
