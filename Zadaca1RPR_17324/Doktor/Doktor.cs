using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doktori
{
    public class Doktor
    {
        public string imeDoktora;
        public string prezimeDoktora;
        public int brojLicence;
        public int BrojPregledanihPacijenata { get; set; }
        public Doktor()
        {
            imeDoktora = "Dietrich";
            prezimeDoktora = "Doktorcic";
            brojLicence = 0;
            BrojPregledanihPacijenata = 0;
        }
        public Doktor(string imeDoktora1, string prezimeDoktora1, int brojLicence1)
        {
            imeDoktora = imeDoktora1;
            prezimeDoktora = prezimeDoktora1;
            brojLicence = brojLicence1;
            BrojPregledanihPacijenata = 0;
        }
    }
}
