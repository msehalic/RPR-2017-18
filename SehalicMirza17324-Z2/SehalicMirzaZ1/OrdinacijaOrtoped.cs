using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
    public class OrdinacijaOrtoped : Ordinacija, IOrdinacije //implementira interfejs da je lakse
    {
        private Queue<Pregled> redCekanja;
        private string nazivKlinike;
        private Doktor sefKlinike;

        public Queue<Pregled> RedCekanja { get => redCekanja; set => redCekanja = value; }
        public string NazivKlinike { get => nazivKlinike; set => nazivKlinike = value; }
        public Doktor SefKlinike { get => sefKlinike; set => sefKlinike = value; }
        public decimal IznosPlacanja(Pregled pregled17324_1)
        {
            return pregled17324_1.RutinskiPregled ? 60.00M : 92.75M; //vraca cijenu pregleda
        }
        public OrdinacijaOrtoped()
        {
            NazivKlinike = "Ortopedska ordinacija";
            SefKlinike = new Doktor(); //privremeno dok se ne dodijeli specificni sef
        }
        public OrdinacijaOrtoped(Doktor SefKlinike1) //konstruktor za sefa klinike
        {
            NazivKlinike = "Ortopedska ordinacija";
            RedCekanja = new Queue<Pregled>();
            SefKlinike = SefKlinike1;
        }
    }
}
