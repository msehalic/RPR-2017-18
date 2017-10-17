using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1_ZSR4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Unesite broj n: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[n];
                Console.WriteLine("Unesite elemente reda {0}: ", i + 1);
                for (int j = 0; j < n; j++)
                {
                    int unos = Convert.ToInt32(Console.ReadLine());
                    arr[i][j] = unos;
                }
            }
            Console.WriteLine("Matrica koju ste unijeli je: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", arr[i][j]);
                }
                Console.WriteLine("");
            }
            //kolone
            int[] brojacKolona = new int[n];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    brojacKolona[j] += arr[i][j];
                }
            }
            int test = 0, indeks = 0;
            for (int j = 0; j < n; j++)
            {
                if (brojacKolona[j] > test)
                {
                    test = brojacKolona[j];
                    indeks = j;
                }
            }
            Console.WriteLine("Kolona sa najvecim zbirom je {0}, taj zbir iznosi {1}.", indeks + 1, test);
            //redovi
            int[] brojacRedova = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    brojacRedova[i] += arr[i][j];
                }
            }
            int test2 = 0, indeks2 = 0;
            for (int j = 0; j < n; j++)
            {
                if (brojacRedova[j] > test2)
                {
                    test2 = brojacRedova[j];
                    indeks2 = j;
                }
            }
            Console.WriteLine("Red sa najvecim zbirom je {0}, taj zbir iznosi {1}.", indeks2 + 1, test2);
        }
    }
}
