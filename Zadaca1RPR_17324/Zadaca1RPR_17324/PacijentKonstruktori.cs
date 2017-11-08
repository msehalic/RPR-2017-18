using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    abstract partial class Pacijent //dio sa konstruktorima
    {
        //TREBALA BI POSTOJATI NEKA LISTA PREGLEDA U KOJU BI SE UBACIVALI KARTONI, SMRTNI STATUS I TO!
        public Pacijent()
        {
            MaticniBroj = 1111011123456;
            ime = "Carl CJ";
            prezime = "Johnson";
            datumRodjenja = new DateTime(1987, 1, 1, 0, 0, 0);
            spol = 'M';
            adresaStanovanja = "Trg republike 1";
            bracnoStanje = "neozenjen";
            datumPrijema = new DateTime(2017, 1, 1, 0, 0, 0);
            //idPacijenta++;
        }
        public Pacijent(int maticniBroj1, string ime1, string prezime1, DateTime datumRodjenja1, char spol1, string adresaStanovanja1, string bracnoStanje1, DateTime datumPrijema1)
        {
            MaticniBroj = maticniBroj1;
            ime = ime1;
            prezime = prezime1;
            datumRodjenja = datumRodjenja1;
            spol = spol1;
            adresaStanovanja = adresaStanovanja1;
            bracnoStanje = bracnoStanje1;
            datumPrijema = datumPrijema1;
            //idPacijenta++;
        }
    }
}
