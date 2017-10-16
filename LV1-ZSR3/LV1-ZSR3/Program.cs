using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1_ZSR3
{
    class Program
    {
        private static void izbaciElementNiza(int[] arr, int element)
        {
            var lista = arr.ToList();
            lista.Remove(element);
            arr = lista.ToArray();
        }
        private static void bubbleSortNiz(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n;
            Console.Write("Unesite broj n: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] niz = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Unesite {0}. element niza: ", i + 1);
                niz[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Niz prije sortiranja: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", niz[i]);
            }
            Console.WriteLine();
            bubbleSortNiz(niz);
            Console.Write("Niz poslije sortiranja: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", niz[i]);
            }
            Console.WriteLine();
            Console.Write("Unesite element niza koji zelite izbaciti: ");
            int izbacaj = Convert.ToInt32(Console.ReadLine());
            izbaciElementNiza(niz, izbacaj);
            Console.Write("Niz poslije izbacivanja: ");
            for (int i = 0; i < niz.Length; i++)
            {
                Console.Write("{0} ", niz[i]);
            }
        }
    }
}