using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
    public class OrdinacijaStomatolog : Ordinacija, IOrdinacije //implementira interfejs da je lakse
    {
        private Queue<Pregled> redCekanja;
        private string nazivKlinike;
        private Doktor sefKlinike;

        public Queue<Pregled> RedCekanja { get => redCekanja; set => redCekanja = value; }
        public string NazivKlinike { get => nazivKlinike; set => nazivKlinike = value; }
        public Doktor SefKlinike { get => sefKlinike; set => sefKlinike = value; }
        public decimal IznosPlacanja(Pregled pregled17324_1)
        {
            return pregled17324_1.RutinskiPregled ? 115.00M : 218.80M; //vraca cijenu pregleda
        }
        public OrdinacijaStomatolog()
        {
            NazivKlinike = "Stomatoloska ordinacija";
            SefKlinike = new Doktor(); //privremeno dok se ne dodijeli specificni sef
        }
        public OrdinacijaStomatolog(Doktor SefKlinike1) //konstruktor za sefa klinike
        {
            NazivKlinike = "Stomatoloska ordinacija";
            RedCekanja = new Queue<Pregled>();
            SefKlinike = SefKlinike1;
        }
    }
}
