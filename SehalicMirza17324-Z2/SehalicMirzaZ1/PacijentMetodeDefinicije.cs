using System;
using System.Collections.Generic;

namespace Zadaca1RPR_17324
{
    public partial class Pacijent//partial dio sa metodama
    {
        private string ime;
        private string prezime;
        private string adresaStanovanja;
        private string bracnoStanje;
        private DateTime datumPrijema;
        private DateTime datumRodjenja;
        private int idPacijenta = 0;
        private char spol;
        private int posjetioKliniku = 0; //broji koliko je puta odredjeni pacijent bio u klinici, kada dostigne 3 idu popusti itd.
        private UInt64 maticniBroj;
        private List<Pregled> karton = new List<Pregled>();

        public bool IspravanKarton = false;

        public int IdPacijenta { get => idPacijenta; set => idPacijenta = value; }
        public char Spol { get => spol; set => spol = value; }
        public ulong MaticniBroj
        {
            get => maticniBroj; set
            {
                maticniBroj = value;
                if (maticniBroj.ToString().Length != 13) throw new Exception(("Maticni broj nema 13 cifara vec " + maticniBroj.ToString().Length));
            }
        }
        public int PosjetioKliniku { get => posjetioKliniku; set => posjetioKliniku = value; }
        public List<Pregled> Karton { get => karton; set => karton = value; }
        public string Ime
        {
            get => ime; set
            {
                ime = value;
                if (ime.Length == 0) throw new Exception("Uneseno prazno ime");

            }
        }
        public string Prezime
        {
            get => prezime; set
            {
                prezime = value;
                if (prezime.Length == 0) throw new Exception("Uneseno prazno prezime");
               
            }
        }
        public string AdresaStanovanja { get => adresaStanovanja; set => adresaStanovanja = value; }
        public string BracnoStanje { get => bracnoStanje; set => bracnoStanje = value; }
        public DateTime DatumPrijema { get => datumPrijema; set => datumPrijema = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }

        public override string ToString()
        {
            //return ("ID-" + IdPacijenta + ": Pacijent " + Ime + " " + Prezime + ", primljen je u bolnicu " + DatumPrijema + ", spola " + Spol + ", ukupno boravio u klinici " + PosjetioKliniku + " puta. Rodjen " + DatumRodjenja.ToLocalTime() + ", adresa stanovanja " + AdresaStanovanja + ", bracno stanje " + BracnoStanje);
            return (Ime + " " + Prezime + ", JMBG: " + MaticniBroj);
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
            IdPacijenta = generisaniBroj;
        }
    }
}
