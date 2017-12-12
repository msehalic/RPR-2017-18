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
        public DateTime DatumVrijemePregleda; //dan i vrijeme pregleda
       public string postupak;
        public string misljenjeLjekara;
        public string terapija; //ne zaboravi natjerati doktora da propise terapiju kod pregleda
        public DateTime VrijemeSmrti;
        public DateTime Obdukcija;
        public Pacijent p;
        public Doktor d=new Doktor();
        public int idPregleda;
        public bool rutinskiPregled = false; //ovo za vozacku i ono ljekarski
        public Pregled(Pacijent p1)
        {
            postupak = "Nije unesen";
            misljenjeLjekara= "Nije uneseno";
            terapija= "Nije unesena";
            DatumVrijemePregleda = DateTime.Now;
            GenerisiIDPregleda();
            p = p1;
            d.BrojPregledanihPacijenata++;
        }
        public Pregled (DateTime datum1, string postupak1, string misljenjeLjekara1, string terapija1, Pacijent pac)
        {
            DatumVrijemePregleda = datum1;
            postupak = postupak1;
            misljenjeLjekara = misljenjeLjekara1;
            terapija = terapija1;
            GenerisiIDPregleda();
            p = pac;
            d.BrojPregledanihPacijenata++;
        }
       public override string ToString()
        {
            if (idPregleda==0) return ("Pacijent trenutno nema evidentiranih izvršenih pregleda.");
            return("U " + DatumVrijemePregleda + " Pacijent " + p.ime + p.prezime + " je prošao kroz proceduru " + postupak + ". Misljenje ljekara je " + misljenjeLjekara + " te je propisana terapija " + terapija + ".");
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
