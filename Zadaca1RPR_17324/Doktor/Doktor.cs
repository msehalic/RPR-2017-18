﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Doktori
{
    [Serializable]
    public class Doktor:Uposlenik
    {
        private int brojPregledanihPacijenata;
        private string specijalizacija;
        public Doktor()
        {
            ImeUposlenika = "Dietrich";
            PrezimeUposlenika = "Doktorcic";
            BrojLicence = 0;
            BrojPregledanihPacijenata = 0;
        }


        public Doktor(string imeUposlenika, string prezimeUposlenika, int brojLicence, int brojPregledanihPacijenata, string specijalizacija) : base(imeUposlenika, prezimeUposlenika, brojLicence)
        {
            BrojPregledanihPacijenata = brojPregledanihPacijenata;
            Specijalizacija = specijalizacija;
        }

        public Doktor(string imeUposlenika, string prezimeUposlenika, Image slikaUposlenika, int brojLicence, string korisnickoIme, string lozinka, int brojPregledanihPacijenata, string specijalizacija) : base(imeUposlenika, prezimeUposlenika, slikaUposlenika, brojLicence, korisnickoIme, lozinka)
        {
            BrojPregledanihPacijenata = brojPregledanihPacijenata;
            Specijalizacija = specijalizacija;
        }

        public int BrojPregledanihPacijenata { get => brojPregledanihPacijenata; set => brojPregledanihPacijenata = value; }
        public string Specijalizacija { get => specijalizacija; set => specijalizacija = value; }

        int ObracunajPlatu(Doktor d) //za obracun plate doktorima (cisto da bude implementirano)
        {
            int bonus = BrojPregledanihPacijenata > 20 ? 20 : BrojPregledanihPacijenata; //poslije 20 pacijenata nema bonusa
            return 2000 + 50 * BrojPregledanihPacijenata; //recimo da za svakog pacijenta doktor dobije 50KM bonusa
        }
    }
}
