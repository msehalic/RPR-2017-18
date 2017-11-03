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
            int unos, prioritet;
            List<Pacijent> pacijenti = new List<Pacijent>();
            Console.WriteLine("Dobro došli! Odaberite jednu od opcija:\n1.Registruj / Briši pacijenta\n2.Prikaži raspored pregleda pacijenta\n3.Kreiranje kartona pacijenta\n4.Pretraga kartona pacijenta\n5.Registruj novi pregled\n6.Analiza sadržaja\n7.Naplata\n8.Izlaz");
            unos = Convert.ToInt32(Console.ReadLine());
            switch (unos)
            {
                case 1:
                    {
                        do
                        {
                            Console.Write("Molimo odaberite prioritet pacijenta: 1-hitni 2-normalni: ");
                            prioritet = Convert.ToInt32(Console.ReadLine());
                            if (prioritet < 1 || prioritet > 2) continue;
                            PacijentHitno pacijent17324_1= new PacijentHitno();
                            if (prioritet == 1) pacijenti.Add(pacijent17324_1);
                            pacijent17324_1.EvidentirajPrvuPomoc();
                        } while (prioritet < 1 || prioritet > 2);
                        break;
                    }
            }
        }
    }
}
