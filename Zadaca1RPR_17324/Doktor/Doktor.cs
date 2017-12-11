using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doktori
{
    public class Doktor:Uposlenik
    {
        public int BrojPregledanihPacijenata { get; set; }
        public Doktor()
        {
            ImeUposlenika = "Dietrich";
            PrezimeUposlenika = "Doktorcic";
            BrojLicence = 0;
            BrojPregledanihPacijenata = 0;
        }

        public Doktor(string imeUposlenika, string prezimeUposlenika, int brojLicence) : base(imeUposlenika, prezimeUposlenika, brojLicence)
        {
        }

        public Doktor(string imeUposlenika, string prezimeUposlenika, int brojLicence, string korisnickoIme, string lozinka) : base(imeUposlenika, prezimeUposlenika, brojLicence, korisnickoIme, lozinka)
        {
        }

        int ObracunajPlatu(Doktor d) //za obracun plate doktorima (cisto da bude implementirano)
        {
            int bonus = BrojPregledanihPacijenata > 20 ? 20 : BrojPregledanihPacijenata; //poslije 20 pacijenata nema bonusa
            return 2000 + 50 * BrojPregledanihPacijenata; //recimo da za svakog pacijenta doktor dobije 50KM bonusa
        }
    }
}
