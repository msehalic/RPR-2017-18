using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSR1_6
{
    class Program
    {
        static string IzbrisiPodstring(string prvi, string drugi)
        {
            return prvi.Replace(drugi, ""); ;
        }
        static int NadjiPodstring(string prvi, string drugi)
        {
            return prvi.IndexOf(drugi);
        }
        static void Main(string[] args)
        {
            string prvi = "Abcdefgh", drugi = "def";
            int n = NadjiPodstring(prvi, drugi);
            prvi = IzbrisiPodstring(prvi, drugi);
            Console.WriteLine("Drugi string se nalazi na poziciji {0}", n);
            Console.WriteLine("String nakon izbacivanja glasi {0}", prvi);
        }
    }
}
