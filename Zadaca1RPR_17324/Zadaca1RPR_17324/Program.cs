using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadaca1RPR_17324
{

    class Program
    {
        static List<Pregled> pregledi = new List<Pregled>();

        static void EvidentirajPrvuPomoc(PacijentHitno p)
        {
            Pregled hitni = new Pregled(DateTime.Now, "", p);
            bool PacijentZiv;
            string vrijemeSmrti, razlogSmrti;
            char prezivio;
            Console.WriteLine("Kojem postupku je podvrgnut pacijent?");
            hitni.postupak = Console.ReadLine();
            Console.WriteLine("Pacijent je ziv (D/N)?");
            prezivio = Convert.ToChar(Console.ReadLine());
            PacijentZiv = (prezivio == 'D') ? true : false; //OVDJE IMA NEKI PROBLEM, MRSKO MI SAD
            if (PacijentZiv) Console.WriteLine("Uspjesno obavljen postupak " + hitni.postupak);
            else
            {
                Console.Write("Unesite vrijeme smrti: ");
                vrijemeSmrti = Console.ReadLine();
                Console.Write("\nUnesite razlog smrti: ");
                razlogSmrti = Console.ReadLine();
                //treba ovo zapisati negdje, mozda neka klasa pregleda pa u listu da se zapisuju pregledi i komentari tj. karton pacijenta
                Console.WriteLine("Pacijent je nazalost preminuo u" + vrijemeSmrti + "zbog" + razlogSmrti);
            }
            pregledi.Add(hitni);
        }
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
                            PacijentHitno pacijent17324_1 = new PacijentHitno();
                            if (prioritet == 1) pacijenti.Add(pacijent17324_1);
                            EvidentirajPrvuPomoc(pacijent17324_1); //malo ovo doraditi da zapisuje gdje treba
                        } while (prioritet < 1 || prioritet > 2);
                        break;
                    }
            }
            //Debug
            foreach (Pregled p in pregledi) p.Ispisi();
            Console.ReadLine(); //da se ne gasi konzola
        }
    }
}
