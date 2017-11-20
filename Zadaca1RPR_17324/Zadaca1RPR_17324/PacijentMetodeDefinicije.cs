using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;

namespace Zadaca1RPR_17324
{
    abstract partial class Pacijent//partial dio sa metodama
    {
        public string ime, prezime, adresaStanovanja, bracnoStanje;
        public DateTime datumPrijema, datumRodjenja;
        public int idPacijenta = 0;
        public char spol;
        public int posjetioKliniku = 0; //broji koliko je puta odredjeni pacijent bio u klinici, kada dostigne 3 idu popusti itd.
        public UInt64 MaticniBroj;
        public List<Pregled> karton = new List<Pregled>();

        public bool IspravanKarton = false;

        /*var ima13Cifara = Math.Floor(Math.Log10(value) + 1) == 13; //provjera da ima 13 cifara (za main mozda nekad)
if (value>0 && ima13Cifara) MaticniBroj = value;*/
        public override string ToString()
        {
            return ("ID-" + idPacijenta + ": Pacijent " + ime + " " + prezime + ", primljen je u bolnicu " + datumPrijema + ", spola " + spol + ", ukupno boravio u klinici " + posjetioKliniku + " puta. Rodjen " + datumRodjenja.ToLocalTime() + ", adresa stanovanja " + adresaStanovanja + ", bracno stanje " + bracnoStanje);
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
