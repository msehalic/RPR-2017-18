using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadaca1RPR_17324
{

    class Program
    {
        static void UnosPodataka(Pacijent p)
        {
            Console.Write("Unesite ime pacijenta: ");
            p.ime = Console.ReadLine();
            Console.Write("Unesite prezime pacijenta: ");
            p.prezime = Console.ReadLine();
            Console.Write("Unesite datum rodjenja pacijenta (DD/MM/YYYY): ");
            var temp = Console.ReadLine();
            p.datumRodjenja = DateTime.Parse(temp);
            Console.Write("Unesite maticni broj pacijenta (13 cifara): ");
            p.MaticniBroj = Convert.ToInt64(Console.ReadLine());
            Console.Write("Unesite spol pacijenta (M/Ž): ");
            p.spol = Convert.ToChar(Console.ReadLine());
            Console.Write("Unesite adresu stanovanja pacijenta: ");
            p.adresaStanovanja = Console.ReadLine();
            Console.Write("Unesite bracno stanje pacijenta: ");
            p.bracnoStanje = Console.ReadLine();
            p.datumPrijema = DateTime.Today;
            Console.WriteLine("Pacijent {0} {1} uspjesno kreiran.\n", p.ime, p.prezime);
        }
        static void EvidentirajPrvuPomoc(ref Pacijent_HitnaProcedura p)
        {
            Pregled hitni17324_1 = new Pregled(DateTime.Today, "", "", "", p); //kreiramo instancu pregleda koju cemo nadopunjavati
            p.datumPrijema = DateTime.Today; //obzirom da je hitni slucaj, datum prvog pregleda odgovara prijemu
    
            char prezivio;
            Console.Write("Kojem postupku je podvrgnut pacijent? ");
            hitni17324_1.postupak = Console.ReadLine();
            Console.Write("Pacijent je ziv (D/N)? ");
            prezivio = Convert.ToChar(Console.ReadLine());
            p.PacijentZiv = (prezivio == 'D') ? true : false;
            if (p.PacijentZiv)
            {
                Console.WriteLine("Uspjesno obavljen postupak " + hitni17324_1.postupak);
                Console.Write("Kakvo je misljenje ljekara nakon hitne intervencije? ");
                hitni17324_1.misljenjeLjekara = Console.ReadLine();
                Console.Write("Kakva je terapija propisana bolesniku? ");
                hitni17324_1.terapija = Console.ReadLine();
            }
            else
            {
                Console.Write("Unesite vrijeme smrti (DD/MM/YYYY HH:MM:SS): ");
                var temp = Console.ReadLine();
                hitni17324_1.VrijemeSmrti = DateTime.Parse(temp);
                Console.Write("\nUnesite razlog smrti: ");
                hitni17324_1.misljenjeLjekara = Console.ReadLine();
            }
            p.karton.Add(hitni17324_1);
        }
        static void KreirajKarton (ref List<Pacijent> pacijenti)
        {
            Pacijent temp = new Pacijent_NormalnaProcedura(); //normalna procedura za dodavanje pacijenta
            bool prekidKreiranjaKartona = true; //da je lakse u petlji opovrgnuti negaciju
            do
            {
                Console.Write("Unesite ime pacijenta kojem kreirate karton: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem kreirate karton: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => x.ime == ime) && !pacijenti.Exists(x => x.prezime == prezime))
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Kreirati novog pacijenta\n3. Odustati od kreiranja kartona");
                    int unos = Convert.ToInt32(Console.ReadLine());
                    //ako je unos 1 petlja ce sama napraviti krug
                    if (unos == 2) RegistrujPacijenta(ref pacijenti);
                    //mozda ovdje jos dodati da ne trazi ime i prezime opet hm?
                    else if (unos == 3) break;
                }
                else
                {
                    Anamneza(pacijenti.Find (x => (x.ime == ime) && (x.prezime == prezime))); //odmah napravi anamnezu
                    prekidKreiranjaKartona = false;
                    temp = pacijenti.Find(x => x.ime == ime);
                }
                if (!prekidKreiranjaKartona)
                {
                    Console.WriteLine("Uspjesno kreiran karton za pacijenta {0} {1}.\n", temp.ime, temp.prezime);
                    break;
                }
            } while (true);
        }        
        static void PretragaKartona(ref List<Pacijent> pacijenti)
        {
            Pacijent temp = new Pacijent_NormalnaProcedura(); //normalna procedura za dodavanje pacijenta
            bool neuspjelaPretragaKartona = false; //ovo nekako izbaciti kasnije
            do
            {
                Console.Write("Unesite ime pacijenta kojem zelite pretraziti karton: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem zelite pretraziti karton: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => x.ime == ime) && !pacijenti.Exists(x => x.prezime == prezime))
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen. Provjerite da li je evidentiran u sistemu te da li mu je kreiran karton.\nDa li zelite:\n1. Pokusati ponovo\n2. Odustati od pretrage kartona");
                    int unos = Convert.ToInt32(Console.ReadLine());
                    //ako je unos 1 petlja ce sama napraviti krug
                    if (unos == 2) break;
                }
                else
                {
                    temp = pacijenti.Find(x => x.ime == ime);
                    Console.WriteLine("Dobro dosli u modul za pretragu kartona pacijenta {0} {1}. \nIzaberite kriterij pretrage:\n1. Datum pregleda\n2. Riječ ili fraza koja je podstring propisane terapije\n3. Riječ ili fraza koja je podstring mišljenja ljekara nakon pregleda\n4. Riječ ili fraza koja je podstring provedenog postupka\n5. ID provedenog pregleda", temp.ime, temp.prezime);
                    int unos = Convert.ToInt32(Console.ReadLine());
                    switch(unos)
                    {
                        case 1:
                            {
                                Console.Write("Unesite datum za koji zelite izlistati preglede (DD/MM/YYYY): ");
                                var tempDan = Console.ReadLine();
                                //DateTime datum_17324 = DateTime.Parse(tempDan);
                               //DEBUG foreach (Pregled p in temp.karton) Console.WriteLine("Hej ja sam definiran kao {0}", p.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy"));
                                    foreach (Pregled p in temp.karton) if (temp.karton.Exists(x=>x.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy").Equals(tempDan))) p.Ispisi();
                                    else Console.WriteLine("Nije pronadjena komponenta pregleda na datum koji odgovara zahtjevu.");
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Unesite rijec ili frazu koju pretrazujete unutar imena terapije koju zelite izlistati: ");
                                string tempRijec = Console.ReadLine();
                                foreach (Pregled p in temp.karton) if (p.terapija.Contains(tempRijec)) p.Ispisi();
                                    else Console.WriteLine("Nije pronadjena komponenta u terapiji koja odgovara zahtjevu.");
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Unesite rijec ili frazu koju pretrazujete unutar misljenja ljekara nakon pregleda kojeg zelite izlistati: ");
                                string tempRijec = Console.ReadLine();
                                foreach (Pregled p in temp.karton) if (p.misljenjeLjekara.Contains(tempRijec)) p.Ispisi();
                                    else Console.WriteLine("Nije pronadjena komponenta u misljenju ljekara koja odgovara zahtjevu.");
                                break;
                            }
                        case 4:
                            {
                                Console.Write("Unesite rijec ili frazu koju pretrazujete unutar naziva provedenog postupka kojeg zelite izlistati: ");
                                string tempRijec = Console.ReadLine();
                                foreach (Pregled p in temp.karton) if (p.postupak.Contains(tempRijec)) p.Ispisi();
                                    else Console.WriteLine("Nije pronadjena komponenta u nazivu provedenog postupka koja odgovara zahtjevu.");
                                break;
                            }
                        case 5:
                            {
                                Console.Write("Unesite ID pregleda kojeg zelite izlistati: ");
                                int tempID = Convert.ToInt32(Console.ReadLine());
                                foreach (Pregled p in temp.karton) if (p.idPregleda==tempID) p.Ispisi();
                                    else Console.WriteLine("Nije pronadjena komponenta u nazivu provedenog postupka koja odgovara zahtjevu.");
                                break;
                            }
                    }
                    //MOZDA JOS KOJA OPCIJA I NACIN PRETRAGE? HMM...
                }
                if (!neuspjelaPretragaKartona)
                {
                    Console.WriteLine("Uspjesno izvrsena pretraga kartona {0} {1}.\n", temp.ime, temp.prezime);
                    break;
                }
            } while (true);

        }
        static void Anamneza(Pacijent p)
        {
            char temp;
            Console.WriteLine("Prije kreiranja kartona izvrsit cemo anamnezu: ");
            Console.Write("Kako pacijent opisuje svoje tegobe: ");
            p.opisTegobaBolesnika = Console.ReadLine();
            Console.Write("Pacijent je aktivni pusac (D/N)? ");
            temp = Convert.ToChar(Console.ReadLine());
            p.pusac = (temp == 'D') ? true : false;
            Console.Write("Pacijent konzumira alkohol (D/N)? ");
            temp = Convert.ToChar(Console.ReadLine());
            p.pusac = (temp == 'D') ? true : false;
            Console.Write("Opis historije nasljednih bolesti u porodici (N/A ukoliko nije prisutna): ");
            p.historijaBolestiuPorodici = Console.ReadLine();
            Console.Write("Alergije pacijenta (N/A ako nisu prisutne): ");
            p.alergije = Console.ReadLine();
            Console.WriteLine("Anamneza uspjesna!");
        }
        static void RegistracijaPregleda(ref List<Pacijent> pacijenti)
        {
            Console.WriteLine("Dobro dosli u modul za registraciju pregleda.");
            bool prekidKreiranjaPregleda = true; //da je lakse u petlji opovrgnuti negaciju
            do
            {
                Pacijent temp = new Pacijent_NormalnaProcedura();
                Pregled pregled=new Pregled(DateTime.Today, "", "", "", temp); //SVAKI KONSTRUKTOR BI TREBAO OVAKO!
                Console.Write("Unesite ime pacijenta kojem kreirate pregled: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem kreirate pregled: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => x.ime == ime) && !pacijenti.Exists(x => x.prezime == prezime))
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Kreirati novog pacijenta te njegov pripadajuci karton\n3. Odustati od kreiranja pregleda");
                    int unos = Convert.ToInt32(Console.ReadLine());
                    //ako je unos 1 petlja ce sama napraviti krug
                    if (unos == 2)
                    {
                        RegistrujPacijenta(ref pacijenti);
                        KreirajKarton(ref pacijenti);
                    }
                    //mozda ovdje jos dodati da ne trazi ime i prezime opet hm?
                    else if (unos == 3) break;
                }
                else
                {
                    temp = pacijenti.Find(x => (x.ime == ime) && (x.prezime == prezime)); //instanciranje mozda sa indeksom?
                    pregled = new Pregled(temp);
                    Console.Write("Unesite datum kada je pregled obavljen (DD/MM/YYYY): ");
                    string s = Console.ReadLine();
                    pregled.DatumVrijemePregleda = DateTime.Parse(s);
                    Console.Write("Koji postupak je proveden prilikom pregleda? ");
                    pregled.postupak = Console.ReadLine();
                    Console.Write("Kakvo je misljenje ljekara nakon pregleda? ");
                    pregled.misljenjeLjekara = Console.ReadLine();
                    Console.Write("Koja terapija je propisana pacijentu? ");
                    pregled.terapija = Console.ReadLine();
                    prekidKreiranjaPregleda = false;
                }
                if (!prekidKreiranjaPregleda)
                {
                    Console.WriteLine("Uspjesno kreiran pregled {0} za pacijenta {1} {2}.\n", pregled.postupak, temp.ime, temp.prezime);
                    temp.karton.Add(pregled);
                    break;
                }
            } while (true);
        }
        static void RegistrujPacijenta(ref List<Pacijent> pacijenti)
        {
            int prioritet;
            do
            {
                Console.Write("Molimo odaberite prioritet pacijenta: 1-hitni 2-normalni: ");
                prioritet = Convert.ToInt32(Console.ReadLine());
                if (prioritet < 1 || prioritet > 2) //minorna provjera unosa
                {
                    Console.WriteLine("Pogresan unos. Birajte ponovo.");
                    continue;
                }
                Pacijent_HitnaProcedura pacijent17324_1 = new Pacijent_HitnaProcedura();
                Pacijent_NormalnaProcedura pacijent17324_2 = new Pacijent_NormalnaProcedura();
                if (prioritet == 1) //samo ako je hitan slucaj
                {
                    EvidentirajPrvuPomoc(ref pacijent17324_1); //should be ok
                    pacijenti.Add(pacijent17324_1);
                    UnosPodataka(pacijent17324_1 as Pacijent); //polimorfno as
                }
                if (prioritet == 2)
                {
                    UnosPodataka(pacijent17324_2 as Pacijent);//polimorfno as
                    pacijenti.Add(pacijent17324_2);
                }
            } while (prioritet < 1 || prioritet > 2);
        }
        static void ObrisiPacijenta(List<Pacijent> pacijenti)
        {
            bool uspjeh = false;
            Pacijent temp=new Pacijent_NormalnaProcedura();
            Console.WriteLine("U sistemu postoje sljedeci pacijenti: ");
            foreach (Pacijent p in pacijenti) p.Ispisi();
            Console.Write("Molimo unesite redni broj pacijenta kojeg zelite obrisati: ");
            int unos = Convert.ToInt32(Console.ReadLine());
            foreach (Pacijent p in pacijenti)
            {
                if (p.idPacijenta == unos)
                {
                    temp = p;
                    uspjeh = true;
                    Console.Write("Uspjesno brisanje!");
                    break;
                }
            }
            if (uspjeh) pacijenti.Remove(temp);
            else Console.WriteLine("Neuspjesno brisanje! Provjerite ID broj pacijenta koji ste unijeli.");
        }
        static void Main(string[] args)
        {
            int unos;
            List<Pacijent> pacijenti = new List<Pacijent>();
            do
            {
                Console.WriteLine("Dobro došli! Odaberite jednu od opcija:\n1.Registruj / Briši pacijenta\n2.Prikaži raspored pregleda pacijenta\n3.Kreiranje kartona pacijenta\n4.Pretraga kartona pacijenta\n5.Registruj novi pregled\n6.Analiza sadržaja\n7.Naplata\n8.Izlaz");
                unos = Convert.ToInt32(Console.ReadLine());
                switch (unos)
                {
                    case 1:
                        {
                            Console.WriteLine("Izaberite opciju:\n1. Registracija pacijenta\n2. Brisanje pacijenta");
                            unos = Convert.ToInt32(Console.ReadLine());
                            if (unos == 1) RegistrujPacijenta(ref pacijenti);
                            if (unos == 2) ObrisiPacijenta(pacijenti);
                            break;
                        }
                    case 3:
                        {
                            KreirajKarton(ref pacijenti);
                            break;
                        }
                    case 4:
                        {
                            PretragaKartona(ref pacijenti);
                            break;
                        }
                    case 5:
                        {
                            RegistracijaPregleda(ref pacijenti);
                            break;
                        }
                }
            } while (unos != 8);

            //OPCIJE:
            //TREBA LI INSTANCIRATI I U POMOCNIM METODAMA TE KLASAMA?
            //PREDNOSTI NASLJEDJIVANJA ORDINACIJA BI BILE DA SE IMPLEMENTIRA INTERFEJS, A NEDOSTACI DA SE NE BI MOGAO IMPLEMENTIRATI UNIVERZALNI RED ČEKANJA

            //TODO: 
            //SPRIJECITI PONOVNO KREIRANJE KARTONA GDJE POSTOJI I NE TRAZITI PONOVNI UNOS IMENA I PREZIMENA CROSS-OPTION
            /*TREBA PRATITI U KALENDARU STA SE DESAVA I ALOCIRATI RASPORED, MORAT CEMO NACI NEKI PRIORITY QUEUE SHIT U C# 
I ONU GLUPOST SA APARATIMA NEKAKO, NOTE TO SELF: NEMOJ KORISTITI LISTE!*/
            //TREBA I OBDUKCIJU ZAKAZATI AKO NAM PRESELI PACIJENT NA AHIRET
            //AKO PACIJENT UMRE TREBALI BISMO MU OTKAZATI I PREGLEDE

            //TREBA RAZDVOJITI OVAJ MODEL OD MAINA U POSEBAN FAJL IZGLEDA? PITATI HHASIC!
            //TREBA LI RADITI ONO IZ BILJESKI? PITATI HHASIC!
            //KOLIKO BODOVA NOSI ZADACA? PITATI HHASIC!
            //DA LI JE BITNO KO STA RADI (NPR. MEDICINSKI TEHNiCAR I KARTONI), JER NE POSTOJE NIVOI PRISTUPA NITI LOGIN? PITATI HHASIC!
            //KAKO UOPCE ZNATI KO KORISTI APP? PITATI HHASIC!
            //KOJI JE SMISAO FUNKCIONALNOSTI NAPLATE KAD SE NE MOZE REALTIME VRSITI PREGLED
            //ISTO TAKO NEMA SMISLA OVO POD 6 JER SE NE MOGU KREIRATI DOKTORI PA TAKO NI POREDITI (JEDINO DA SE HARDCODIRAJU)?

            //Debug
            // foreach (Pregled p in pregledi) p.Ispisi();
            //this is good
            //Debug2
            foreach (Pacijent p in pacijenti) p.Ispisi();
            //this is good
            Console.ReadLine(); //da se ne gasi konzola
                                //KAD PACIJENT PLATI TREBA INKREMENTIRATI NJEGOV BROJ DOLAZAKA U BOLNICU RADI KASNIJIH POPUSTA
        }
    }
}
