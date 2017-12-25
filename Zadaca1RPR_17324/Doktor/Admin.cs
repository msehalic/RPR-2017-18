using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doktori
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

        public Administrator(string imeUposlenika, string prezimeUposlenika, int brojLicence, string korisnickoIme, string lozinka) : base(imeUposlenika, prezimeUposlenika, brojLicence, korisnickoIme, lozinka)
        {
        }
    }
}
