using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1_ZSR2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Unesite n: ");
            n = Convert.ToInt32(Console.ReadLine());
            int m = n;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < m; j++)
                    Console.Write(" ");
                m--;
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}
