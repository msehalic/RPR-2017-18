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
        static void UnosPodataka (Pacijent p)
        {
            Console.Write("Unesite ime pacijenta: ");
            p.ime=Console.ReadLine();
            Console.Write("Unesite prezime pacijenta: ");
            p.prezime = Console.ReadLine();
            Console.Write("Unesite datum rodjenja pacijenta (DD/MM/YYYY): ");
            var temp = Console.ReadLine();
            p.datumRodjenja = DateTime.Parse(temp);
            Console.Write("Unesite maticni broj pacijenta (13 cifara): ");
            p.MaticniBroj = Convert.ToInt64(Console.ReadLine());
            Console.Write("Unesite spol pacijenta (M/Ž): ");
            p.spol=Convert.ToChar(Console.ReadLine());
            Console.Write("Unesite adresu stanovanja pacijenta: ");
            p.adresaStanovanja = Console.ReadLine();
            Console.Write("Unesite bracno stanje pacijenta: ");
            p.bracnoStanje = Console.ReadLine();
            p.datumPrijema = DateTime.Today;
        }
        static void EvidentirajPrvuPomoc(PacijentHitno p)
        {
            Pregled hitni17324_1 = new Pregled(DateTime.Now, "", p); //kreiramo instancu pregleda koju cemo nadopunjavati
            p.datumPrijema = DateTime.Now; //obzirom da je hitni slucaj, datum prvog pregleda odgovara prijemu
            string vrijemeSmrti, razlogSmrti;
            char prezivio;
            Console.Write("Kojem postupku je podvrgnut pacijent? ");
            hitni17324_1.postupak = Console.ReadLine();
            Console.Write("Pacijent je ziv (D/N)? ");
            prezivio = Convert.ToChar(Console.ReadLine());
            p.PacijentZiv = (prezivio == 'D') ? true : false;
            if (p.PacijentZiv) Console.WriteLine("Uspjesno obavljen postupak " + hitni17324_1.postupak);
            else
            {
                Console.Write("Unesite vrijeme smrti: ");
                vrijemeSmrti = Console.ReadLine();
                Console.Write("\nUnesite razlog smrti: ");
                razlogSmrti = Console.ReadLine();
                //trebaju nam i komentari tj. zabiljeziti ih u karton pacijenta
                Console.Write("Pacijent je nazalost preminuo u" + vrijemeSmrti + "zbog" + razlogSmrti);
            }
            pregledi.Add(hitni17324_1);
        }
        static void Main(string[] args)
        {
            int unos, prioritet;
            List<Pacijent> pacijenti = new List<Pacijent>();
            do
            {
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
                                PacijentNormal pacijent17324_2 = new PacijentNormal();
                                if (prioritet == 1)
                                {
                                    EvidentirajPrvuPomoc(pacijent17324_1); //should be ok
                                    pacijenti.Add(pacijent17324_1);
                                    UnosPodataka(pacijent17324_2 as Pacijent);
                                }
                                if (prioritet== 2)
                                {
                                    UnosPodataka(pacijent17324_2 as Pacijent);
                                    pacijenti.Add(pacijent17324_2);
                                }
                            } while (prioritet < 1 || prioritet > 2);
                            break;
                        }
                }
            } while (unos != 8);
            //Debug
            foreach (Pregled p in pregledi) p.Ispisi();
            //this is good
            //Debug2
            foreach (Pacijent p in pacijenti) p.Ispisi();
            //this is good
            Console.ReadLine(); //da se ne gasi konzola
            //KAD PACIJENT PLATI TREBA INKREMENTIRATI NJEGOV BROJ DOLAZAKA U BOLNICU RADI KASNIJIH POPUSTA
        }
    }
}
