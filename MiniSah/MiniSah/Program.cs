using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSah
{

   class Figura
    {
        public enum Potez { NaprijedzaN = 1, Naprijed = 2, KonjLijevo = 3, KonjDesno = 4 };
         char pomjerislovo(int potez)
        {
            switch(potez)
            {
                case 1:
                    {
                        for (char c = 'A'; c <= 'Z'; c++)
                        {
                            return c+n;
                        }
                    }

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string ulaz;
            Console.Write("Dobro dosli u Mini Sah. Molimo odaberite opciju 1 ili 2: ");
            ulaz = Console.ReadLine();
        }
    }
}
