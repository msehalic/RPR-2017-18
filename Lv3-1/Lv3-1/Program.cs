using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lv3_1
{
    abstract class Knjiga
    {
        public string naziv;
        public string autor;
        public int godinaIzdavanja { get; set; }
        public int IDbroj;
        public int tipKnjige { get; set; }
        public Knjiga()
        {
            naziv = "";
            autor = "";
            godinaIzdavanja = 0;
            IDbroj = 0;
            tipKnjige = 0;
        }
        public Knjiga(string nazivK, string autorK, int godinaK, int IDbrojK, int tipK)
        {
            naziv = nazivK;
            autor = autorK;
            godinaIzdavanja = godinaK;
            IDbroj = IDbrojK;
            tipKnjige = tipK;
        }
    }
    class ZabavnaKnjiga : Knjiga
    {
        int starosnaDob;
        int brojDanaZaRentanje = 0;
        public ZabavnaKnjiga(int starostK, int brojDanaK, string naziv, string autor, int godinaIzdavanja, int IDbroj, int tipKnjige) : base(naziv, autor, godinaIzdavanja, IDbroj, tipKnjige)
        {
            starosnaDob = starostK;
            brojDanaZaRentanje = brojDanaK;
        }
        double ObracunZabavna()
        {
            return (brojDanaZaRentanje <= 5) ? 4 : (4 + (brojDanaZaRentanje - 5) * 0.08);
        }
    }
    class NaucnaKnjiga : Knjiga
    {
        string granaNauke;
        int brojDanaZaRentanje = 0;
        public NaucnaKnjiga(string granaK, int brojDanaK, string naziv, string autor, int godinaIzdavanja, int IDbroj, int tipKnjige) : base(naziv, autor, godinaIzdavanja, IDbroj, tipKnjige)
        {
            granaNauke = granaK;
            brojDanaZaRentanje = brojDanaK;
        }
        double ObracunNaucna()
        {
            double cijena = 5;
            if (brojDanaZaRentanje > 10)
            {
                if (godinaIzdavanja < 1990) cijena += (brojDanaZaRentanje - 10) * 0.5;
                else cijena += (brojDanaZaRentanje - 10) * 0.3;
            }
            return cijena;
        }

    }
    class Program
    {
        const int VELICINA = 10;
        static void Main(string[] args)
        {
            int n;
            List<Knjiga> knjige = new List<Knjiga>();
            Knjiga k= new NaucnaKnjiga("Biologija", 0, "Udzbenik za prvi razred", "Neki random lik", 1989, 100, 2);
            knjige.add(k);
            Console.WriteLine("Dobrodosli u biblioteku :)\n1. Unos knjige\n2. Najam knjige\n0. Izlaz\n\n");
            Console.Write("Molimo izaberite opciju...");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Na stanju imamo sljedece knjige: ");
                            for (int i = 0; i < knjige.Length; i++)
                            {
                                if (knjige[i].naziv != "" && knjige[i].IDbroj != 0)
                                    Console.WriteLine("{0}. {1}, autora {2}, izdata {3}. godine", i+1, knjige[i].naziv, knjige[i].autor, knjige[i].godinaIzdavanja);
                            }
                            break;
                        }
                }
            }
            while (n != 0);
        }
    }
}
