using Doktori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{

    class Program
    {
        static void UnosPodataka(Pacijent p, ref List<Ordinacija> ordinacije)
        {
            string temp;
            bool dobarUnos = true;
            Console.Write("Unesite ime pacijenta: ");
            p.ime = Console.ReadLine();
            Console.Write("Unesite prezime pacijenta: ");
            p.prezime = Console.ReadLine();
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Unesite datum rodjenja pacijenta (DD/MM/YYYY): ");
                temp = Console.ReadLine();
                dobarUnos = DateTime.TryParse(temp, out p.datumRodjenja);
            } while (!dobarUnos);
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Unesite maticni broj pacijenta (13 cifara): ");
                temp = Console.ReadLine();
                dobarUnos = UInt64.TryParse(temp, out p.MaticniBroj); //brine se da li je veci od 0 sa UInt
                if (dobarUnos)
                {
                    if (!(temp.Length == 13)) dobarUnos = false; //ako nema 13 cifara nije ispravan
                    //provjerimo sada prvi dio maticnog broja
                    string datumUString = p.datumRodjenja.ToString("ddMMyyyy");
                    datumUString = datumUString.Remove(4, 1); //cifra hiljadica godine rodjenja
                    string maticniUString = temp.Substring(0, temp.Length - 6); //skratimo 6 posljednjih cifara
                    if (datumUString.Equals(maticniUString) == false) dobarUnos = false; //provjerili prve cifre maticnog
                }
            } while (!dobarUnos);
            do
            {
                Console.Write("Unesite spol pacijenta (M/Z): ");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out p.spol);
                if (p.spol != 'M' && p.spol != 'Z') dobarUnos = false;
            } while (!dobarUnos);
            Console.Write("Unesite adresu stanovanja pacijenta: ");
            p.adresaStanovanja = Console.ReadLine();
            Console.Write("Unesite bracno stanje pacijenta: ");
            p.bracnoStanje = Console.ReadLine();
            p.datumPrijema = DateTime.Today;
            Console.WriteLine("Pacijent {0} {1} sa ID {2} uspjesno kreiran.\n", p.ime, p.prezime, p.idPacijenta);
            Console.WriteLine("Molimo unesite preglede koje pacijent zeli obaviti: ");
            //dermatolog
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Pacijent zeli zakazati pregled kod dermatologa (D/N)? ");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out char zeliPregled);
                if (zeliPregled == 'D') foreach(Ordinacija o in ordinacije) if (o is OrdinacijaDermatolog)
                        {
                            ((OrdinacijaDermatolog)o).RedCekanja.Enqueue(new Pregled(p));
                            Console.WriteLine("Vi ste {0}. u redu cekanja za ordinaciju dermatologa.\n", ((OrdinacijaDermatolog)o).RedCekanja.Count); //na pocetku je dovoljno ovo za mjerenje cekanja, kasnije moramo pojedinacno naci svakog pacijenta
                        }
                if (zeliPregled != 'D' && zeliPregled != 'N') dobarUnos = false;
            } while (!dobarUnos);
            //kardiolog
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Pacijent zeli zakazati pregled kod kardiologa (D/N)? ");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out char zeliPregled);
                if (zeliPregled == 'D') foreach (Ordinacija o in ordinacije) if (o is OrdinacijaKardiolog)
                        {
                            ((OrdinacijaKardiolog)o).RedCekanja.Enqueue(new Pregled(p));
                            Console.WriteLine("Vi ste {0}. u redu cekanja za ordinaciju kardiologa.\n", ((OrdinacijaKardiolog)o).RedCekanja.Count); //na pocetku je dovoljno ovo za mjerenje cekanja, kasnije moramo pojedinacno naci svakog pacijenta
                        }
                if (zeliPregled != 'D' && zeliPregled != 'N') dobarUnos = false;
            } while (!dobarUnos);
            //ortoped
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Pacijent zeli zakazati pregled kod ortopeda (D/N)? ");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out char zeliPregled);
                if (zeliPregled == 'D') foreach (Ordinacija o in ordinacije) if (o is OrdinacijaOrtoped)
                        {
                            ((OrdinacijaOrtoped)o).RedCekanja.Enqueue(new Pregled(p));
                            Console.WriteLine("Vi ste {0}. u redu cekanja za ordinaciju ortopeda.\n", ((OrdinacijaOrtoped)o).RedCekanja.Count); //na pocetku je dovoljno ovo za mjerenje cekanja, kasnije moramo pojedinacno naci svakog pacijenta
                        }
                if (zeliPregled != 'D' && zeliPregled != 'N') dobarUnos = false;
            } while (!dobarUnos);
            //stomatolog
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Pacijent zeli zakazati pregled kod stomatologa (D/N)? ");
                temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out char zeliPregled);
                if (zeliPregled == 'D') foreach (Ordinacija o in ordinacije) if (o is OrdinacijaStomatolog)
                        {
                            ((OrdinacijaStomatolog)o).RedCekanja.Enqueue(new Pregled(p));
                            Console.WriteLine("Vi ste {0}. u redu cekanja za ordinaciju stomatologa.\n", ((OrdinacijaStomatolog)o).RedCekanja.Count); //na pocetku je dovoljno ovo za mjerenje cekanja, kasnije moramo pojedinacno naci svakog pacijenta
                        }
                if (zeliPregled != 'D' && zeliPregled != 'N') dobarUnos = false;
            } while (!dobarUnos);
        }
        static void EvidentirajPrvuPomoc(ref Pacijent_HitnaProcedura p)
        {
            Pregled hitni17324_1 = new Pregled(DateTime.Today, "", "", "", p); //kreiramo instancu pregleda koju cemo nadopunjavati
            p.datumPrijema = DateTime.Today; //obzirom da je hitni slucaj, datum prvog pregleda odgovara prijemu
            bool dobarUnos = true;
            Console.Write("Kojem postupku je podvrgnut pacijent? ");
            hitni17324_1.postupak = Console.ReadLine();
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Pacijent je ziv (D/N)? ");
                var temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out char prezivio);
                p.PacijentZiv = (prezivio == 'D') ? true : false;
                if (prezivio != 'D' && prezivio != 'N') dobarUnos = false;
            } while (!dobarUnos);
            if (p.PacijentZiv)
            {
                Console.WriteLine("Uspjesno obavljen postupak " + hitni17324_1.postupak + ", ID pregleda: {0}", hitni17324_1.idPregleda);
                Console.Write("Kakvo je misljenje ljekara nakon hitne intervencije? ");
                hitni17324_1.misljenjeLjekara = Console.ReadLine();
                Console.Write("Kakva je terapija propisana bolesniku? ");
                hitni17324_1.terapija = Console.ReadLine();
            }
            else
            {
                do
                {
                    if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                    Console.Write("Unesite vrijeme smrti (DD/MM/YYYY): ");
                    var temp = Console.ReadLine();
                    dobarUnos = DateTime.TryParse(temp, out hitni17324_1.VrijemeSmrti);
                } while (!dobarUnos);
                Console.Write("Unesite uzrok/razlog smrti: ");
                hitni17324_1.misljenjeLjekara = Console.ReadLine();
                char obdukcija17324_1;
                do
                {
                    if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                    Console.Write("Da li ce biti zakazana obdukcija (D/N)? ");
                    var temp = Console.ReadLine();
                    temp = temp.ToUpper();
                    dobarUnos = Char.TryParse(temp, out obdukcija17324_1);
                    if (obdukcija17324_1 != 'D' && obdukcija17324_1 != 'N') dobarUnos = false;
                } while (!dobarUnos);
                if (obdukcija17324_1 == 'D')
                {
                    do
                    {
                        if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                        Console.Write("Unesite datum i vrijeme obdukcije (DD/MM/YYYY): ");
                        var temp = Console.ReadLine();
                        dobarUnos = DateTime.TryParse(temp, out hitni17324_1.Obdukcija);
                    } while (!dobarUnos);
                }
            }
            p.karton.Add(hitni17324_1);
        }
        static void KreirajKarton(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
        {
            Pacijent temp = new Pacijent_NormalnaProcedura(); //normalna procedura za dodavanje pacijenta
            bool prekidKreiranjaKartona = true; //da je lakse u petlji opovrgnuti negaciju
            do
            {
                Console.Write("Unesite ime pacijenta kojem kreirate karton: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem kreirate karton: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase))) 
                    //case insensitive provjera
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Kreirati novog pacijenta\n3. Odustati od kreiranja kartona");
                    int unos = Convert.ToInt32(Console.ReadLine());
                    //ako je unos 1 petlja ce sama napraviti krug
                    if (unos == 2) RegistrujPacijenta(ref pacijenti, ref ordinacije);
                    //mozda ovdje jos dodati da ne trazi ime i prezime opet hm?
                    else if (unos == 3) break;
                }
                else
                {
                    Anamneza(pacijenti.Find(x => (String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)) && (String.Equals(x.prezime, prezime, StringComparison.OrdinalIgnoreCase)))); //odmah napravi anamnezu
                    //case insensitive provjera
                    prekidKreiranjaKartona = false;
                    temp = pacijenti.Find(x => (String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)) && (String.Equals(x.prezime, prezime, StringComparison.OrdinalIgnoreCase)));
                }
                if (!prekidKreiranjaKartona)
                {
                    Console.WriteLine("Uspjesno kreiran karton za pacijenta {0} {1}.\n", temp.ime, temp.prezime);
                    temp.IspravanKarton = true;
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
                if (!pacijenti.Exists(x => String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)))
                    //case insensitive provjera
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen. Provjerite da li je evidentiran u sistemu te da li mu je kreiran karton.\nDa li zelite:\n1. Pokusati ponovo\n2. Odustati od pretrage kartona");
                    int unos = Convert.ToInt32(Console.ReadLine());
                    //ako je unos 1 petlja ce sama napraviti krug
                    if (unos == 2) break;
                }
                else
                {
                    temp = pacijenti.Find(x => String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase) && String.Equals(x.prezime, prezime, StringComparison.OrdinalIgnoreCase));
                    //case insensitive
                    bool sveUredu;
                    do
                    {
                        Console.WriteLine("Dobro dosli u modul za pretragu kartona pacijenta {0} {1}. \nIzaberite kriterij pretrage:\n1. Datum pregleda\n2. Riječ ili fraza koja je podstring propisane terapije\n3. Riječ ili fraza koja je podstring mišljenja ljekara nakon pregleda\n4. Riječ ili fraza koja je podstring provedenog postupka\n5. ID provedenog pregleda\n6. Broj licence doktora koji je izvrsio pregled", temp.ime, temp.prezime);
                        var parse = Console.ReadLine();
                        sveUredu = Int32.TryParse(parse, out int unos);
                        switch (unos)
                        {
                            case 1:
                                {
                                    Console.Write("Unesite datum za koji zelite izlistati preglede (DD/MM/YYYY): ");
                                    var tempDan = Console.ReadLine();
                                    //DateTime datum_17324 = DateTime.Parse(tempDan);
                                    //DEBUG foreach (Pregled p in temp.karton) Console.WriteLine("Hej ja sam definiran kao {0}", p.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy"));
                                    foreach (Pregled p in temp.karton) if (temp.karton.Exists(x => x.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy").Equals(tempDan))) p.Ispisi();
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
                                    foreach (Pregled p in temp.karton) if (p.idPregleda == tempID) p.Ispisi();
                                        else Console.WriteLine("Nije pronadjen ID postojeceg pacijenta koji odgovara zahtjevu.");
                                    break;
                                }
                            case 6:
                                {
                                    Console.Write("Unesite licencu doktora cije preglede zelite izlistati: ");
                                    int tempLicenca = Convert.ToInt32(Console.ReadLine());
                                    foreach (Pregled p in temp.karton) if (p.d.brojLicence == tempLicenca) p.Ispisi();
                                        else Console.WriteLine("Nije pronadjen pregled sa brojem licence koji odgovara zahtjevu.");
                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine("Pogresan unos. Birajte ponovo.");
                                    sveUredu = false;
                                    continue;
                                }
                        }
                        //MOZDA JOS KOJA OPCIJA I NACIN PRETRAGE? HMM...
                    } while (!sveUredu);
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
            bool dobarUnos = true;
            Console.WriteLine("Prije kreiranja kartona izvrsit cemo anamnezu: ");
            Console.Write("Kako pacijent opisuje svoje tegobe: ");
            p.opisTegobaBolesnika = Console.ReadLine();
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Pacijent je aktivni pusac (D/N)? ");
                var temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out char pomocnik);
                p.pusac = (pomocnik == 'D') ? true : false;
                if (pomocnik != 'D' && pomocnik != 'N') dobarUnos = false;
            } while (!dobarUnos);
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Pacijent konzumira alkohol (D/N)? ");
                var temp = Console.ReadLine();
                temp = temp.ToUpper();
                dobarUnos = Char.TryParse(temp, out char pomocnik);
                p.alkoholicar = (pomocnik == 'D') ? true : false;
                if (pomocnik != 'D' && pomocnik != 'N') dobarUnos = false;
            } while (!dobarUnos);
            Console.Write("Opis historije nasljednih bolesti u porodici (N/A ukoliko nije prisutna): ");
            p.historijaBolestiuPorodici = Console.ReadLine();
            Console.Write("Alergije pacijenta (N/A ako nisu prisutne): ");
            p.alergije = Console.ReadLine();
            Console.WriteLine("Anamneza uspjesna!");
        }
        static void RegistracijaPregleda(ref List<Pacijent> pacijenti, ref List<Doktor> doktori, ref List<Ordinacija> ordinacije)
        {
            Console.WriteLine("Dobro dosli u modul za registraciju pregleda.");
            bool prekidKreiranjaPregleda = true; //da je lakse u petlji opovrgnuti negaciju
            do
            {
                Pacijent temp = new Pacijent_NormalnaProcedura();
                Pregled pregled = new Pregled(DateTime.Today, "", "", "", temp); //SVAKI KONSTRUKTOR BI TREBAO OVAKO!
                Console.Write("Unesite ime pacijenta kojem kreirate pregled: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem kreirate pregled: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)))
                    //case insensitive
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Kreirati novog pacijenta te njegov pripadajuci karton\n3. Odustati od kreiranja pregleda");
                    int unos = Convert.ToInt32(Console.ReadLine());
                    //ako je unos 1 petlja ce sama napraviti krug
                    if (unos == 2)
                    {
                        RegistrujPacijenta(ref pacijenti, ref ordinacije);
                        KreirajKarton(ref pacijenti, ref ordinacije);
                    }
                    //mozda ovdje jos dodati da ne trazi ime i prezime opet hm?
                    else if (unos == 3) break;
                }
                //ovdje treba slucaj kad nema karton i ponuditi da se kreira, napravio sam bool za provjeru :)
                else
                {
                    temp = pacijenti.Find(x => (String.Equals(x.ime, ime, StringComparison.OrdinalIgnoreCase)) && (String.Equals(x.prezime, prezime, StringComparison.OrdinalIgnoreCase))); //instanciranje mozda sa indeksom?
                    if (temp.IspravanKarton == false) //ako nema karton, kreiraj
                    {
                        Console.WriteLine("Pacijent sa tim imenom i prezimenom je pronadjen, ali nema kreiran karton.\nDa li zelite:\n1. Kreirati karton pacijentu \n2. Odustati od kreiranja pregleda");
                        int unos = Convert.ToInt32(Console.ReadLine());
                        if (unos == 1) KreirajKarton(ref pacijenti, ref ordinacije);
                        else break;
                    }
                    else
                    {
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
                        do
                        {
                            Console.Write("Molimo unesite broj licence doktora koji propisuje terapiju: ");

                            var licenca = Convert.ToInt32(Console.ReadLine());
                            //sada provjerimo da li je validan doktor ili je prevarant :)
                            foreach (Doktor doktor17324 in doktori)
                                if (doktor17324.brojLicence == licenca)
                                {
                                    Console.WriteLine("Terapiju propisao doktor {0} {1}", doktor17324.imeDoktora, doktor17324.prezimeDoktora);
                                    pregled.d = doktor17324;
                                    pregled.d.BrojPregledanihPacijenata++; //inkrementiramo mu brojac pacijenata
                                    prekidKreiranjaPregleda = false;
                                }
                            if (prekidKreiranjaPregleda) Console.WriteLine("Neispravna licenca. Pokusajte ponovno. ");
                        } while (prekidKreiranjaPregleda);
                    }
                }
                if (!prekidKreiranjaPregleda)
                {
                    Console.WriteLine("Uspjesno kreiran pregled sa ID {0} za pacijenta {1} {2}.\n", pregled.idPregleda, temp.ime, temp.prezime);
                    temp.karton.Add(pregled);
                    break;
                }
            } while (true);
        }
        static void RegistrujPacijenta(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
        {
            int prioritet;
            bool dobarUnos = true;
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.Write("Molimo odaberite prioritet pacijenta: 1-hitni 2-normalni: ");
                var temp = Console.ReadLine();
                dobarUnos = Int32.TryParse(temp, out prioritet);
                if (prioritet < 1 || prioritet > 2) dobarUnos = false;
            } while (!dobarUnos);
            Pacijent_HitnaProcedura pacijent17324_1 = new Pacijent_HitnaProcedura();
            Pacijent_NormalnaProcedura pacijent17324_2 = new Pacijent_NormalnaProcedura();
            if (prioritet == 1) //samo ako je hitan slucaj
            {
                EvidentirajPrvuPomoc(ref pacijent17324_1); //should be ok
                pacijenti.Add(pacijent17324_1);
                UnosPodataka(pacijent17324_1 as Pacijent, ref ordinacije); //polimorfno as
            }
            if (prioritet == 2)
            {
                UnosPodataka(pacijent17324_2 as Pacijent, ref ordinacije);//polimorfno as
                pacijenti.Add(pacijent17324_2);
            }
        }
        static void ObrisiPacijenta(List<Pacijent> pacijenti)
        {
            bool uspjeh = false;
            Pacijent temp = new Pacijent_NormalnaProcedura();
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
        static void DodajBrisi(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
        {
            int unos;
            bool dobarUnos = true;
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.WriteLine("Izaberite opciju:\n1. Registracija pacijenta\n2. Brisanje pacijenta");
                var temp = Console.ReadLine();
                dobarUnos = Int32.TryParse(temp, out unos);
                if (unos < 1 || unos > 2) dobarUnos = false;
            } while (!dobarUnos);
            if (unos == 1) RegistrujPacijenta(ref pacijenti, ref ordinacije);
            if (unos == 2) ObrisiPacijenta(pacijenti);
        }
        static void Main(string[] args)
        {
            int unos;
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
                            RegistracijaPregleda(ref pacijenti, ref doktori, ref ordinacije);
                            break;
                        }
                    default:
                        {
                            Console.Write("Neispravan unos. Pokusajte ponovo: ");
                            continue;
                        }
                }
            } while (unos != 8);

            //OPCIJE:
            //TREBA LI INSTANCIRATI U OBLIKU INDEKSA I U POMOCNIM METODAMA TE KLASAMA?

            //TODO: 
            //NAPISATI
            //DOKUMENTACIJU
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //DICTIONARY I DELEGATI U MAINU ZA MENI
            //OPCIJA DA DOKTOR OSLOBODI ORDINACIJU
            //DODATI TEHNICARE I UPRAVU
            //MOZDA DODATI OPCIJU DA SE POSTAVI ODSUSTVO DOKTORA
            //SPRIJECITI PONOVNO KREIRANJE PACIJENATA KARTONA GDJE POSTOJI I NE TRAZITI PONOVNI UNOS IMENA I PREZIMENA CROSS-OPTION
            /*TREBA PRATITI U KALENDARU STA SE DESAVA I ALOCIRATI RASPORED, MORAT CEMO NACI NEKI PRIORITY QUEUE SHIT U C# 
I ONU GLUPOST SA APARATIMA NEKAKO, NOTE TO SELF: NEMOJ KORISTITI LISTE!*/
            //TREBA RAZDVOJITI OVAJ MODEL OD MAINA U POSEBAN FAJL 
            //VOZACKA I PREGLEDI ZA POSAO IMPLEMENTIRATI U REGISTRACIJI PREGLEDA+DOKTORA, TREBA I AUTO KREIRATI RASPORED ONDA

            //HHASIC FAQ PROVJERI AKO ZAPNE
            //KAD PACIJENT PLATI TREBA INKREMENTIRATI NJEGOV BROJ DOLAZAKA U BOLNICU RADI KASNIJIH POPUSTA
        }
    }
}
