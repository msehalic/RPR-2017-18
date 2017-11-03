using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    abstract partial class Pacijent //dio sa konstruktorima
    {
        public Pacijent()
        {
            MaticniBroj = 1111011123456;
            ime = "Carl CJ";
            prezime = "Johnson";
            datumRodjenja = "11/11/2011";
            spol = 'M';
            adresaStanovanja = "Trg republike 1";
            bracnoStanje = "neozenjen";
            datumPrijema = "01/01/2018";
        }
        public Pacijent(int maticniBroj1, string ime1, string prezime1, string datumRodjenja1, char spol1, string adresaStanovanja1, string bracnoStanje1, string datumPrijema1)
        {
            MaticniBroj = maticniBroj1;
            ime = ime1;
            prezime = prezime1;
            datumRodjenja = datumRodjenja1;
            spol = spol1;
            adresaStanovanja = adresaStanovanja1;
            bracnoStanje = bracnoStanje1;
            datumPrijema = datumPrijema1;
        }
    }
}
