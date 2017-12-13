using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;

namespace Zadaca1RPR_17324
{
    public partial class Pacijent //dio sa konstruktorima
    {
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

        public Pacijent(string ime, string prezime, string adresaStanovanja, string bracnoStanje, DateTime datumRodjenja, char spol, ulong maticniBroj)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresaStanovanja = adresaStanovanja;
            this.bracnoStanje = bracnoStanje;
            this.datumRodjenja = datumRodjenja;
            this.spol = spol;
            MaticniBroj = maticniBroj;
        }

        public Pacijent(UInt64 maticniBroj1, string ime1, string prezime1, DateTime datumRodjenja1, char spol1, string adresaStanovanja1, string bracnoStanje1, DateTime datumPrijema1)
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
