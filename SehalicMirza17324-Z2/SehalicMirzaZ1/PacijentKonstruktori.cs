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
            Ime = "Carl CJ";
            Prezime = "Johnson";
            DatumRodjenja = new DateTime(1987, 1, 1, 0, 0, 0);
            Spol = 'M';
            AdresaStanovanja = "Trg republike 1";
            BracnoStanje = "neozenjen";
            DatumPrijema = new DateTime(2017, 1, 1, 0, 0, 0);
            Karton = new List<Pregled>();
            //idPacijenta++;
        }

        public Pacijent(string ime, string prezime, string adresaStanovanja, string bracnoStanje, DateTime datumRodjenja, char spol, ulong maticniBroj)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.AdresaStanovanja = adresaStanovanja;
            this.BracnoStanje = bracnoStanje;
            this.DatumRodjenja = datumRodjenja;
            this.Spol = spol;
            MaticniBroj = maticniBroj;
        }

        public Pacijent(UInt64 maticniBroj1, string ime1, string prezime1, DateTime datumRodjenja1, char spol1, string adresaStanovanja1, string bracnoStanje1, DateTime datumPrijema1)
        {
            MaticniBroj = maticniBroj1;
            Ime = ime1;
            Prezime = prezime1;
            DatumRodjenja = datumRodjenja1;
            Spol = spol1;
            AdresaStanovanja = adresaStanovanja1;
            BracnoStanje = bracnoStanje1;
            DatumPrijema = datumPrijema1;
            //idPacijenta++;
        }
    }
}
