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
        int ObracunajPlatu(Doktor d) //za obracun plate doktorima (cisto da bude implementirano)
        {
            int bonus = BrojPregledanihPacijenata > 20 ? 20 : BrojPregledanihPacijenata; //poslije 20 pacijenata nema bonusa
            return 2000 + 50 * BrojPregledanihPacijenata; //recimo da za svakog pacijenta doktor dobije 50KM bonusa
        }
    }
}
