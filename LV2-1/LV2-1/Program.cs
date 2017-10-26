using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            //tekuci fizicko lice
            Poly.Banka b = new Poly.Banka(); b.dodajKlijenta(new Poly.Osoba(1, "Haris"));

            Poly.Osoba p = b.pronadjiKlijenta(1) as Poly.Osoba; b.otvoriTekuciRacunZaOsobu(p);

            p.Racuni[0].poloziNovac(550); Console.WriteLine("Stanje: {0}", b.pronadjiKlijenta(1).Racuni[0].Stanje);
            //stedni pravno lice
            Poly.Banka b2 = new Poly.Banka(); b2.dodajKlijenta(new Poly.PravnoLice(2, "Ramiz", "Zmaja od Bosne bb"));

            Poly.PravnoLice p2 = b2.pronadjiKlijenta(2) as Poly.PravnoLice; b2.otvoriStedniRacunZaPravnoLice(p2);

            p2.Racuni[0].poloziNovac(1000); Console.WriteLine("Stanje: {0}", b2.pronadjiKlijenta(2, true).Racuni[0].Stanje);
            Console.ReadLine();
        }
    }
}
namespace Polymorphism.Poly
{
    abstract public class Klijent
    {
        public Int32 Id { get; set; }
        public List<Racun> Racuni { get; set; }
        protected Klijent(Int32 id) { Id = id; Racuni = new List<Racun>(); }
    }

    public class Osoba : Klijent
    {
        public String Ime { get; set; }

        public Osoba(Int32 id, String ime) : base(id) { this.Ime = ime; }
    }
    public class PravnoLice : Klijent
    {
        public String Ime { get; set; }

        public String Adresa { get; set; }

        public PravnoLice(Int32 id, String ime, String adresa) : base(id) { this.Ime = ime; this.Adresa = adresa; }
    }
    abstract public class Racun
    {
        public Int32 RacunID { get; set; }
        protected string valuta;
        protected Decimal _stanje;

        protected Racun(Int32 id, Decimal pocetnoStanje) { RacunID = id; _stanje = pocetnoStanje; }
        protected Racun(Int32 id, Decimal pocetnoStanje, string pocetnaValuta) { RacunID = id; _stanje = pocetnoStanje; valuta = pocetnaValuta; }
        public Decimal Stanje { get { return _stanje; } }

        public virtual void poloziNovac(Decimal kol) { if (kol < 0) { throw new Exception("Količina koju podižete sa računa mora biti pozitivna."); } _stanje += kol; }

        public virtual void povuciNovac(Decimal kol) { if (kol < 0) { throw new Exception("Količina koju povlačite mora biti pozitivna."); } _stanje -= kol; }
    }

    public class TekuciRacun : Racun
    {
        private static Decimal limitZaPodizanje = 1000;

        public TekuciRacun(Int32 racunID, Decimal pocetnoStanje) : base(racunID, pocetnoStanje)
        {
        }

        // Preklapanje (Override) za specifično ponašanje kada se povlači novac    
        override public void povuciNovac(Decimal kol)
        {
            if (kol < 0) { throw new Exception("Količina mora biti pozitivna da bi se povukao novac."); }
            else if (kol > limitZaPodizanje) { throw new Exception("Količina mora biti manja od limita za podizanje."); }
            _stanje -= kol;
        }
    }
    public class StedniRacun : Racun
    {
        private static Decimal limitZaPodizanje = 1000;
        public StedniRacun(Int32 racunID, Decimal pocetnoStanje, string pocetnaValuta) : base(racunID, pocetnoStanje, pocetnaValuta)
        {
        }

        // Preklapanje (Override) za specifično ponašanje kada se povlači novac    
        override public void povuciNovac(Decimal kol)
        {
            if (kol < 0) { throw new Exception("Količina mora biti pozitivna da bi se povukao novac."); }
            else if (kol > limitZaPodizanje) { throw new Exception("Količina mora biti manja od limita za podizanje."); }
            _stanje -= kol;
        }
    }
    public class Banka
    {
        private List<Klijent> Klijenti { get; set; }
        private List<Racun> Racuni { get; set; }

        public Banka() { Klijenti = new List<Klijent>(); Racuni = new List<Racun>(); }

        public void dodajKlijenta(Osoba p) { Klijenti.Add(p); }

        public void dodajKlijenta(PravnoLice p) { Klijenti.Add(p); }

        public void otvoriTekuciRacunZaOsobu(Osoba p) { TekuciRacun acc = new TekuciRacun(Racuni.Count, 0); Racuni.Add(acc); p.Racuni.Add(acc); }

        public void otvoriStedniRacunZaOsobu(Osoba p) { StedniRacun acc = new StedniRacun(Racuni.Count, 0, "BAM"); Racuni.Add(acc); p.Racuni.Add(acc); }

        //pravno lice

        public void otvoriTekuciRacunZaPravnoLice(PravnoLice p) { TekuciRacun acc = new TekuciRacun(Racuni.Count, 0); Racuni.Add(acc); p.Racuni.Add(acc); }

        public void otvoriStedniRacunZaPravnoLice(PravnoLice p) { StedniRacun acc = new StedniRacun(Racuni.Count, 0, "BAM"); Racuni.Add(acc); p.Racuni.Add(acc); }


        public Klijent pronadjiKlijenta(Int32 id) { return Klijenti.Single(osoba => osoba.Id == id); }

        public Klijent pronadjiKlijenta(Int32 id, bool pravnolice) { return Klijenti.Single(osoba => osoba.Id == id); }

        public void poloziNovac(TekuciRacun acc, Decimal kol) { acc.poloziNovac(kol); }

        private String klijentUString(Klijent c)
        {
            if (c is Osoba) { return (c as Osoba).Ime; }
            return "";
        }
    }
}



