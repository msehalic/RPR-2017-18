using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prvi
{
    class Program
    {
        const int Milje = 1852;
        static void Main(string[] args)
        {
            int brzina;
            decimal rezultat;
            Console.Write("Unesite brzinu broda u cvorovima: ");
            brzina= Convert.ToInt32(Console.ReadLine());
            rezultat = (brzina * Milje)/1000M;
            Console.WriteLine("Brzina broda u km/h je {0}", rezultat);
        }
    }
}
