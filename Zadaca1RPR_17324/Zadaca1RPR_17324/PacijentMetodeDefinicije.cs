using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    abstract partial class Pacijent//partial dio sa metodama
    {
        //TREBALA BI POSTOJATI NEKA LISTA PREGLEDA U KOJU BI SE UBACIVALI KARTONI, SMRTNI STATUS I TO!
        public string ime, prezime, adresaStanovanja, bracnoStanje;
        public DateTime datumPrijema, datumRodjenja;
        public int idPacijenta = 0;
        public char spol;
        public int posjetioKliniku = 0; //broji koliko je puta odredjeni pacijent bio u klinici, kada dostigne 3 idu popusti itd.
        public Int64 MaticniBroj;
            
                /*var ima13Cifara = Math.Floor(Math.Log10(value) + 1) == 13; //provjera da ima 13 cifara
                if (value>0 && ima13Cifara) MaticniBroj = value;*/
          public void Ispisi()
        {
            Console.WriteLine("ID-{0} Pacijent {1} {2}, primljen je u bolnicu {3}, spola {4}, ukupno boravio u klinici {5} puta. Rodjen {6}, adresa stanovanja {7}, bracno stanje {8}", idPacijenta, ime, prezime, datumPrijema.ToLocalTime(), spol, posjetioKliniku, datumRodjenja.ToLocalTime(), adresaStanovanja, bracnoStanje);
        }
        public void GenerisiIDPacijenta() //generise nasumican broj od 1 do 1000 da se ne peglamo sa brojacima
        {
            List<int> listaRandomBrojeva = new List<int>();
            int generisaniBroj;
            Random rand = new Random();
                do
                {
                    generisaniBroj = rand.Next(1, 1000);
                } while (listaRandomBrojeva.Contains(generisaniBroj));
            idPacijenta = generisaniBroj;
        }
    }
}
