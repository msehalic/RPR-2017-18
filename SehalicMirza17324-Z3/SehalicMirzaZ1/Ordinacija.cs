using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
    public class Ordinacija : IOrdinacije
    {
        //klasa napravljena samo radi polimorfizma ostalih
        private Queue<Pregled> redCekanja=new Queue<Pregled>();
        private string nazivKlinike;
        private Doktor sefKlinike;

        public Ordinacija()
        {
        }

        public Ordinacija(Doktor sefKlinike)
        {
            this.sefKlinike = sefKlinike;
        }

        public Ordinacija(string nazivKlinike, Doktor sefKlinike)
        {
            NazivKlinike = nazivKlinike;
            SefKlinike = sefKlinike;
        }

        public Ordinacija(Queue<Pregled> redCekanja, string nazivKlinike, Doktor sefKlinike)
        {
            RedCekanja = redCekanja;
            NazivKlinike = nazivKlinike;
            SefKlinike = sefKlinike;
        }

        public Queue<Pregled> RedCekanja { get => redCekanja; set => redCekanja = value; }
        public string NazivKlinike { get => nazivKlinike; set => nazivKlinike = value; }
        public Doktor SefKlinike { get => sefKlinike; set => sefKlinike = value; }

        public decimal IznosPlacanja(Pregled pregled17324_1)
        {
            return pregled17324_1.RutinskiPregled ? 45.00M : 90.00M; //vraca cijenu pregleda
        }
    }
}

