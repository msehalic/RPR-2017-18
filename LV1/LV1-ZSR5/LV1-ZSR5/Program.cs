using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1_ZSR5
{
    class Program
    {
        static string OkreniGa (string s)
        {
            char[] niz = s.ToCharArray();
            Array.Reverse(niz);
            return new string(niz);
        }
        static bool DaLiJePalindrom(string s)
        {
            string trim = s.Replace(" ", "");
            trim=trim.ToLower();
            string poredbeni = OkreniGa(trim);
            return (poredbeni==trim);
        }
        static void Main(string[] args)
        {
            string s;
            Console.Write("Unesite neki string: ");
            s = Console.ReadLine();
            string palindrom = DaLiJePalindrom(s) ? "je" : "nije";
            Console.WriteLine("Uneseni string " + palindrom + " palindrom");
        }
    }
}
