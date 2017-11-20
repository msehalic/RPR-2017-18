using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<decimal> naplaceno = new List<decimal>();
            int unos;
            List<Tuple<Pregled, decimal>> pregledIznosNaplate = new List<Tuple<Pregled, decimal>>();
            bool dobarUnos = true;
            List<Pacijent> pacijenti = new List<Pacijent>();
            List<Doktor> doktori = new List<Doktor>();
            List<Ordinacija> ordinacije = new List<Ordinacija>();
            //nekoliko doktora za potrebe testiranja
            Doktor doktor17324_1 = new Doktor("Ahmed", "Ahmedic", 123); //dermatolog, broj licence 123
            Doktor doktor17324_2 = new Doktor("Emina", "Tutic", 456); //kardiolog, broj licence 456
            Doktor doktor17324_3 = new Doktor("Marko", "Kikic", 789); //ortoped, broj licence 789
            Doktor doktor17324_4 = new Doktor("Pavle", "Bisercic", 555); //stomatolog, broj licence 555
            doktori.Add(doktor17324_1);
            doktori.Add(doktor17324_2);
            doktori.Add(doktor17324_3);
            doktori.Add(doktor17324_4);
            //kreirajmo ordinacije i postavimo odgovarajuce sefove
            OrdinacijaDermatolog ordinacija17324_1 = new OrdinacijaDermatolog(doktor17324_1);
            OrdinacijaKardiolog ordinacija17324_2 = new OrdinacijaKardiolog(doktor17324_2);
            OrdinacijaOrtoped ordinacija17324_3 = new OrdinacijaOrtoped(doktor17324_3);
            OrdinacijaStomatolog ordinacija17324_4 = new OrdinacijaStomatolog(doktor17324_4);
            ordinacije.Add(ordinacija17324_1);
            ordinacije.Add(ordinacija17324_2);
            ordinacije.Add(ordinacija17324_3);
            ordinacije.Add(ordinacija17324_4);
            do
            {
                do
                {
                    if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                    Console.WriteLine("Dobro došli! Odaberite jednu od opcija:\n1.Registruj / Briši pacijenta\n2.Prikaži raspored pregleda pacijenta\n3.Kreiranje kartona pacijenta\n4.Pretraga kartona pacijenta\n5.Registruj novi pregled\n6.Analiza sadržaja\n7.Naplata\n8.Izlaz");
                    var temp = Console.ReadLine();
                    dobarUnos = Int32.TryParse(temp, out unos);
                } while (!dobarUnos);
                switch (unos)
                {
                    case 1:
                        {
                            DodajBrisi(ref pacijenti, ref ordinacije);
                            break;
                        }
                    case 2:
                        {
                            GenerisiRaspored(ref pacijenti, ref ordinacije);
                            break;
                        }
                    case 3:
                        {
                            KreirajKarton(ref pacijenti, ref ordinacije);
                            break;
                        }
                    case 4:
                        {
                            PretragaKartona(ref pacijenti);
                            break;
                        }
                    case 5:
                        {
                            RegistracijaPregleda(ref pacijenti, ref doktori, ref ordinacije, ref pregledIznosNaplate);
                            break;
                        }
                    case 6:
                        {
                            Analiza(ref pacijenti, ref doktori, ref ordinacije, ref naplaceno);
                            break;
                        }
                    case 7:
                        {
                            Naplata(ref pacijenti, ref pregledIznosNaplate, ref naplaceno);
                            break;
                        }
                    default:
                        {
                            Console.Write("Neispravan unos. Pokusajte ponovo: ");
                            continue;
                        }
                }
            } while (unos != 8); //rjesava izlaz


        }
    }
}
