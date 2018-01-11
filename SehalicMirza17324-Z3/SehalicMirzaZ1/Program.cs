using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;
namespace Zadaca1RPR_17324
{
   public class Program
    {
        static void Main(string[] args)
        {
            KlinikaKontejner klinika17324 = new KlinikaKontejner();
            int unos;

            bool dobarUnos = true;
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
                            //   klinika17324.DodajBrisi(ref klinika17324.Pacijenti, ref klinika17324.Ordinacije);
                            break;
                        }
                    case 2:
                        {
                            //     klinika17324.GenerisiRaspored(ref klinika17324.Pacijenti, ref klinika17324.Ordinacije);
                            break;
                        }
                    case 3:
                        {
                            //  klinika17324.KreirajKarton(ref klinika17324.Pacijenti, ref klinika17324.Ordinacije);
                            break;
                        }
                    case 4:
                        {
                            //     klinika17324.PretragaKartona(ref klinika17324.Pacijenti);
                            break;
                        }
                    case 5:
                        {
                            //    klinika17324.RegistracijaPregleda(ref klinika17324.Pacijenti, ref klinika17324.Doktori, ref klinika17324.Ordinacije, ref pregledIznosNaplate);
                            break;
                        }
                    case 6:
                        {
                            //   klinika17324.Analiza(ref klinika17324.Pacijenti, ref klinika17324.Doktori, ref klinika17324.Ordinacije, ref naplaceno);
                            break;
                        }
                    case 7:
                        {
                          //  klinika17324.Naplata(ref klinika17324.Pacijenti, ref pregledIznosNaplate, ref naplaceno);
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
