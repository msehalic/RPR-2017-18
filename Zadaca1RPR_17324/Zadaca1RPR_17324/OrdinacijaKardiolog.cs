using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
    class OrdinacijaKardiolog: Ordinacija, IOrdinacije //implementira interfejs da je lakse
    {
        public Queue<Pregled> RedCekanja { get; set; }
        public string NazivKlinike { get; set; }
        public Doktor SefKlinike { get; set; }
        public decimal IznosPlacanja(Pregled pregled17324_1)
        {
            return pregled17324_1.rutinskiPregled ? 35.00M : 62.50M; //vraca cijenu pregleda
        }
        public OrdinacijaKardiolog()
        {
            NazivKlinike = "Kardioloska ordinacija";
            SefKlinike = new Doktor(); //privremeno dok se ne dodijeli specificni sef
        }
        public OrdinacijaKardiolog(Doktor SefKlinike1) //konstruktor za sefa klinike
        {
            NazivKlinike = "Kardioloska ordinacija";
            RedCekanja = new Queue<Pregled>();
            SefKlinike = SefKlinike1;
        }
    }
}
