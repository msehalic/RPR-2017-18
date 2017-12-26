using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
    sealed public class Pregled
    {
        private DateTime datumVrijemePregleda; //dan i vrijeme pregleda
        private string postupak;
        private string misljenjeLjekara;
        private string terapija; //ne zaboravi natjerati doktora da propise terapiju kod pregleda
        private DateTime vrijemeSmrti;
        private DateTime obdukcija;
        private Doktor d = new Doktor();
        private int idPregleda;
        private bool naplacenPregled = false;
        private bool rutinskiPregled = false; //ovo za vozacku i ono ljekarski

        public DateTime DatumVrijemePregleda { get => datumVrijemePregleda; set => datumVrijemePregleda = value; }
        public string Postupak { get => postupak; set => postupak = value; }
        public string MisljenjeLjekara { get => misljenjeLjekara; set => misljenjeLjekara = value; }
        public string Terapija { get => terapija; set => terapija = value; }
        public DateTime VrijemeSmrti { get => vrijemeSmrti; set => vrijemeSmrti = value; }
        public DateTime Obdukcija { get => obdukcija; set => obdukcija = value; }
        public Doktor D { get => d; set => d = value; }
        public int IdPregleda { get => idPregleda; set => idPregleda = value; }
        public bool RutinskiPregled { get => rutinskiPregled; set => rutinskiPregled = value; }
        public Pacijent P { get => p; set => p = value; }
        public bool NaplacenPregled { get => naplacenPregled; set => naplacenPregled = value; }

        private Pacijent p;

        public Pregled(Pacijent p1)
        {
            Postupak = "Nije unesen";
            MisljenjeLjekara= "Nije uneseno";
            Terapija= "Nije unesena";
            DatumVrijemePregleda = DateTime.Now;
            GenerisiIDPregleda();
            P = p1;
            D.BrojPregledanihPacijenata++;
        }
        public Pregled (DateTime datum1, string postupak1, string misljenjeLjekara1, string terapija1, Pacijent pac)
        {
            DatumVrijemePregleda = datum1;
            Postupak = postupak1;
            MisljenjeLjekara = misljenjeLjekara1;
            Terapija = terapija1;
            GenerisiIDPregleda();
            P = pac;
            D.BrojPregledanihPacijenata++;
        }
       public override string ToString()
        {
            if (IdPregleda==0) return ("Pacijent trenutno nema evidentiranih izvršenih pregleda.");
            return(DatumVrijemePregleda + " Pacijent " + P.Ime + P.Prezime + ", procedura: " + Postupak + ". Misljenje ljekara je " + MisljenjeLjekara + ", propisana terapija: " + Terapija + ".");
        }
        public void GenerisiIDPregleda() //generise nasumican broj od 1 do 1000 da se ne peglamo sa brojacima
        {
            List<int> listaRandomBrojeva = new List<int>();
            int generisaniBroj;
            Random rand = new Random();
            do
            {
                generisaniBroj = rand.Next(1, 1000);
            } while (listaRandomBrojeva.Contains(generisaniBroj));
            IdPregleda = generisaniBroj;
        }
    }
}
