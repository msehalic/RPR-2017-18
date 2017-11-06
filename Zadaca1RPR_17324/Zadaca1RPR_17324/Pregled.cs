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
        public Pacijent p;
        public int idPregleda=0;
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
            Console.WriteLine("{0}. Pacijent {1} {2} je prošao kroz proceduru {3}.", DatumVrijemePregleda.ToLocalTime(), p.ime, p.prezime, postupak);
        }
    }
}
