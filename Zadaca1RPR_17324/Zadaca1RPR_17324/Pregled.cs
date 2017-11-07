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
        public DateTime VrijemeSmrti { get; set; }
        public Pacijent p;
        protected int idPregleda=0;
        public Pregled(Pacijent p)
        {
            postupak = "Nije unesen";
            DatumVrijemePregleda = DateTime.Now;
        }
        public Pregled (DateTime datum1, string postupak1, Pacijent pac)
        {
            DatumVrijemePregleda = datum1;
            postupak = postupak1;
            idPregleda++;
            p = pac;
        }
       public void Ispisi()
        {
            Console.WriteLine("U {0}. Pacijent {1} {2} je prošao kroz proceduru {3}.", DatumVrijemePregleda, p.ime, p.prezime, postupak);
        }
    }
}
