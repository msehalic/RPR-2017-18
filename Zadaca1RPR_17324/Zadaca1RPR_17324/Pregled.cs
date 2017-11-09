using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    sealed class Pregled
    { 
       public DateTime DatumVrijemePregleda { get; set; } //dan i vrijeme pregleda
       public string postupak;
        public string misljenjeLjekara;
        public string terapija; //ne zaboravi natjerati doktora da propise terapiju kod pregleda
        //TREBALI BI INSTANCIRATI DOKTORA OVDJE KAD NAPISEMO KLASU!
        public DateTime VrijemeSmrti { get; set; }
        public DateTime Obdukcija { get; set; }
        public Pacijent p;
        public int idPregleda=0;
        public Pregled(Pacijent p1)
        {
            postupak = "Nije unesen";
            misljenjeLjekara= "Nije uneseno";
            terapija= "Nije unesena";
            DatumVrijemePregleda = DateTime.Now;
            GenerisiIDPregleda();
            p = p1;
        }
        public Pregled (DateTime datum1, string postupak1, string misljenjeLjekara1, string terapija1, Pacijent pac)
        {
            DatumVrijemePregleda = datum1;
            postupak = postupak1;
            misljenjeLjekara = misljenjeLjekara1;
            terapija = terapija1;
            GenerisiIDPregleda();
            p = pac;
        }
       public void Ispisi()
        {
            if (idPregleda==0) Console.WriteLine("Pacijent trenutno nema evidentiranih izvršenih pregleda.");
            Console.WriteLine("U {0}. Pacijent {1} {2} je prošao kroz proceduru {3}. Misljenje ljekara je {4} te je propisana terapija {5}.", DatumVrijemePregleda, p.ime, p.prezime, postupak, misljenjeLjekara, terapija);
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
            idPregleda = generisaniBroj;
        }
    }
}
