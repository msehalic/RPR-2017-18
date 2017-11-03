using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadaca1RPR_17324
{
    class Program
    {
        static void Main(string[] args)
        {
            int unos;
            Console.WriteLine("Dobro došli! Odaberite jednu od opcija:\n1.Registruj / Briši pacijenta\n2.Prikaži raspored pregleda pacijenta\n3.Kreiranje kartona pacijenta\n4.Pretraga kartona pacijenta\n5.Registruj novi pregled\n6.Analiza sadržaja\n7.Naplata\n8.Izlaz");
            unos = Convert.ToInt32(Console.ReadLine());
        }
    }
}
