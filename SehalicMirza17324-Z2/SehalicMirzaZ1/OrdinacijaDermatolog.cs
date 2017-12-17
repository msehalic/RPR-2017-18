using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
    public class OrdinacijaDermatolog : Ordinacija, IOrdinacije //implementira interfejs da je lakse
    {
        private Queue<Pregled> redCekanja;
        private string nazivKlinike;
        private Doktor sefKlinike;

        public Queue<Pregled> RedCekanja { get => redCekanja; set => redCekanja = value; }
        public string NazivKlinike { get => nazivKlinike; set => nazivKlinike = value; }
        public Doktor SefKlinike { get => sefKlinike; set => sefKlinike = value; }

        public decimal IznosPlacanja(Pregled pregled17324_1)
        {
            return pregled17324_1.RutinskiPregled ? 45.00M : 83.20M; //vraca cijenu pregleda
        }
        public OrdinacijaDermatolog()
        {
            NazivKlinike = "Dermatoloska ordinacija";
            SefKlinike = new Doktor(); //privremeno dok se ne dodijeli specificni sef
        }
        public OrdinacijaDermatolog(Doktor SefKlinike1) //konstruktor za sefa klinike
        {
            NazivKlinike = "Dermatoloska ordinacija";
            RedCekanja = new Queue<Pregled>();
            SefKlinike = SefKlinike1;
        }
    }
}
