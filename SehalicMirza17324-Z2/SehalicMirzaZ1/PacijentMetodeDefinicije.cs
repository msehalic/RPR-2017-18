using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Zadaca1RPR_17324
{
    [Serializable]
    public partial class Pacijent//partial dio sa metodama
    {
        private string ime;
        private string prezime;
        private string adresaStanovanja;
        private string bracnoStanje;
        private DateTime datumPrijema;
        private DateTime datumRodjenja;
        private Image slikaPacijenta;
        private int idPacijenta = 0;
        private char spol;
        private int posjetioKliniku = 0; //broji koliko je puta odredjeni pacijent bio u klinici, kada dostigne 3 idu popusti itd.
        private UInt64 maticniBroj;
       private string korisnickoIme;
       private string lozinka;
        private List<Pregled> karton = new List<Pregled>();

        public bool IspravanKarton = false;

        public int IdPacijenta { get => idPacijenta; set => idPacijenta = value; }
        public char Spol { get => spol; set => spol = value; }

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
        public Image SlikaPacijenta { get => slikaPacijenta; set => slikaPacijenta = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public ulong MaticniBroj { get => maticniBroj; set => maticniBroj = value; }

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
        static string GetMd5Hash(MD5 md5Hash, string input) //sluzbena dokumentacija
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
