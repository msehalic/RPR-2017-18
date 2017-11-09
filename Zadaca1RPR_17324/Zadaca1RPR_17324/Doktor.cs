using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    class Doktor
    {
        public string imeDoktora;
        public string prezimeDoktora;
        public int brojLicence;
        bool SefKlinike { get; set; }
        public Doktor()
        {
            imeDoktora = "Dietrich";
            prezimeDoktora = "Doktorcic";
            brojLicence = 0;
            SefKlinike = false;
        }
        public Doktor(string imeDoktora1, string prezimeDoktora1, int brojLicence1, bool SefKlinike1)
        {
            imeDoktora = imeDoktora1;
            prezimeDoktora = prezimeDoktora1;
            brojLicence = brojLicence1;
            SefKlinike = SefKlinike1;
        }
    }
}
