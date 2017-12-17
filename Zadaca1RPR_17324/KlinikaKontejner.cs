using Doktori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{

    public class KlinikaKontejner
    {
        public List<Pacijent> pacijenti = new List<Pacijent>();
        public List<Doktor> doktori = new List<Doktor>();
        public List<Ordinacija> ordinacije = new List<Ordinacija>();
        public List<Uposlenik> uposlenici = new List<Uposlenik>();
        public KlinikaKontejner()
        {
            uposlenici.Add(new Uposlenik("Jovo", "Jovic", 9999, "admin", "admin"));
        }
        public Tuple<int, int, int, int> UnosPodataka(Pacijent p, bool dermatolog, bool kardiolog, bool ortoped, bool stomatolog)
        {
            int cekanjeDermatolog = 0, cekanjeKardiolog = 0, cekanjeOrtoped = 0, cekanjeStomatolog = 0;
            //Dermatolog
            if (dermatolog) foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="dermatolog")
                    {
                        o.RedCekanja.Enqueue(new Pregled(p));
                        cekanjeDermatolog = o.RedCekanja.Count;
                    }
            //kardiolog
            if (kardiolog) foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="kardiolog")
                    {
                        o.RedCekanja.Enqueue(new Pregled(p));
                        cekanjeKardiolog = o.RedCekanja.Count;
                    }
            //ortoped
            if (ortoped) foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="ortoped")
                    {
                        o.RedCekanja.Enqueue(new Pregled(p));
                        cekanjeOrtoped = o.RedCekanja.Count;
                    }
            //stomatolog
            if (stomatolog) foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="stomatolog")
                    {
                        o.RedCekanja.Enqueue(new Pregled(p));
                        cekanjeStomatolog = o.RedCekanja.Count;
                    }
            return Tuple.Create(cekanjeDermatolog, cekanjeKardiolog, cekanjeOrtoped, cekanjeStomatolog);
        }
        public void GenerisiRaspored(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
        {
            bool dobarUnos = true;
            List<Tuple<string, int, Doktor>> nizCekanjaOrdinacija = new List<Tuple<string, int, Doktor>>();//dinamicki ce se sortirati bez obzira koliko ima ordinacija
            do
            {

                Console.Write("Unesite ime pacijenta kojem printate racun: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem printate racun: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)))
                //case insensitive
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Odustati od prikaza rasporeda");
                    var temp = Console.ReadLine();
                    dobarUnos = Int32.TryParse(temp, out int unosPonovo);
                    if (unosPonovo != 2) dobarUnos = false;
                }
                else
                {
                    var pacijent17324 = pacijenti.Find(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase) && String.Equals(x.Prezime, prezime, StringComparison.OrdinalIgnoreCase));
                    //polimorfizam lvl 9999:
                    foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="stomatolog") nizCekanjaOrdinacija.Add(Tuple.Create("stomatolog", o.RedCekanja.Count, o.SefKlinike));
                    foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="kardiolog") nizCekanjaOrdinacija.Add(Tuple.Create("kardiolog", o.RedCekanja.Count, o.SefKlinike));
                    foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="ortoped") nizCekanjaOrdinacija.Add(Tuple.Create("ortoped", o.RedCekanja.Count, o.SefKlinike));
                    foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="dermatolog") nizCekanjaOrdinacija.Add(Tuple.Create("dermatolog", o.RedCekanja.Count, o.SefKlinike));
                    nizCekanjaOrdinacija.Sort(delegate (Tuple<string, int, Doktor> x, Tuple<string, int, Doktor> y)
                    {
                        return x.Item2.CompareTo(y.Item2); //sortira po broju ljudi u redu cekanja
                    });
                    Console.WriteLine("Vas raspored je sljedeci: ");
                    foreach (Tuple<string, int, Doktor> t in nizCekanjaOrdinacija)
                        if (t.Item2 != 0) Console.WriteLine("Posjetit cete doktora {0} {1}, specijalista {2}, u cijoj ste ordinaciji {3}. u redu cekanja.", t.Item3.ImeUposlenika, t.Item3.PrezimeUposlenika, t.Item1, t.Item2);
                    Console.Write(Environment.NewLine); //cuz it's cool 
                    //nema potrebe ispisivati ordinacije za koje se pacijent nije ni prijavio :)
                }
            } while (!dobarUnos);
        }
        public void KreirajKarton(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
        {
            bool dobarUnos = false;
            Pacijent temp = new Pacijent_NormalnaProcedura(); //normalna procedura za dodavanje pacijenta
            bool prekidKreiranjaKartona = true; //da je lakse u petlji opovrgnuti negaciju
            do
            {
                Console.Write("Unesite ime pacijenta kojem kreirate karton: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem kreirate karton: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)))
                //case insensitive provjera
                {
                    do
                    {
                        Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Kreirati novog pacijenta\n3. Odustati od kreiranja kartona");
                        var unosStringa = Console.ReadLine();
                        dobarUnos = Int32.TryParse(unosStringa, out int unos);
                        if (!dobarUnos)
                        {
                            Console.Write("Neispravan unos. Pokusajte ponovo");
                            continue;
                        }
                        //ako je unos 1 petlja ce sama napraviti krug
                        if (unos == 2) RegistrujPacijenta(ref pacijenti, ref ordinacije);
                        //mozda ovdje jos dodati da ne trazi ime i prezime opet hm?
                        else if (unos == 3) prekidKreiranjaKartona = false;
                    } while (!dobarUnos);
                }
                else
                {
                    Anamneza(pacijenti.Find(x => (String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && (String.Equals(x.Prezime, prezime, StringComparison.OrdinalIgnoreCase)))); //odmah napravi anamnezu
                    //case insensitive provjera
                    prekidKreiranjaKartona = false;
                    temp = pacijenti.Find(x => (String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && (String.Equals(x.Prezime, prezime, StringComparison.OrdinalIgnoreCase)));
                }
                if (!prekidKreiranjaKartona)
                {
                    Console.WriteLine("Uspjesno kreiran karton za pacijenta {0} {1}.\n", temp.Ime, temp.Prezime);
                    temp.IspravanKarton = true;
                    break;
                }
            } while (prekidKreiranjaKartona);
        }
        public void PretragaPoDatumu(Pacijent pacijent17324, bool dobarUnos)
        {
            string tempDan;
            do
            {
                Console.Write("Unesite datum za koji zelite izlistati preglede (DD/MM/YYYY): ");
                tempDan = Console.ReadLine();
                dobarUnos = DateTime.TryParseExact(tempDan, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nebitan);
                if (!dobarUnos) Console.Write("Pogresan unos. Pokusajte ponovo.");
            } while (!dobarUnos);
            //DateTime datum_17324 = DateTime.Parse(tempDan);
            //DEBUG foreach (Pregled p in temp.karton) Console.WriteLine("Hej ja sam definiran kao {0}", p.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy"));
            foreach (Pregled p in pacijent17324.Karton) if (pacijent17324.Karton.Exists(x => x.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy").Equals(tempDan))) Console.WriteLine(p.ToString());
                else Console.WriteLine("Nije pronadjena komponenta pregleda na datum koji odgovara zahtjevu.");
        }
        public void PretragaPoTerapiji(Pacijent pacijent17324, bool dobarUnos)
        {
            Console.Write("Unesite rijec ili frazu koju pretrazujete unutar imena terapije koju zelite izlistati: ");
            string tempRijec = Console.ReadLine();
            foreach (Pregled p in pacijent17324.Karton) if (p.Terapija.Contains(tempRijec)) Console.WriteLine(p.ToString());
                else Console.WriteLine("Nije pronadjena komponenta u terapiji koja odgovara zahtjevu.");
        }
        public void PretragaPoPostupku(Pacijent pacijent17324, bool dobarUnos)
        {
            Console.Write("Unesite rijec ili frazu koju pretrazujete unutar naziva provedenog postupka kojeg zelite izlistati: ");
            string tempRijec = Console.ReadLine();
            foreach (Pregled p in pacijent17324.Karton) if (p.Postupak.Contains(tempRijec)) Console.WriteLine(p.ToString());
                else Console.WriteLine("Nije pronadjena komponenta u nazivu provedenog postupka koja odgovara zahtjevu.");

        }
        public void PretragaPoMisljenju(Pacijent pacijent17324, bool dobarUnos)
        {
            Console.Write("Unesite rijec ili frazu koju pretrazujete unutar misljenja ljekara nakon pregleda kojeg zelite izlistati: ");
            string tempRijec = Console.ReadLine();
            foreach (Pregled p in pacijent17324.Karton) if (p.MisljenjeLjekara.Contains(tempRijec)) Console.WriteLine(p.ToString());
                else Console.WriteLine("Nije pronadjena komponenta u misljenju ljekara koja odgovara zahtjevu.");
        }
        public void PretragaPoIDu(Pacijent pacijent17324, bool dobarUnos)
        {
            int tempID;
            do
            {
                Console.Write("Unesite ID pregleda kojeg zelite izlistati: ");
                var UnosStringa = Console.ReadLine();
                dobarUnos = Int32.TryParse(UnosStringa, out tempID);
            } while (!dobarUnos);
            foreach (Pregled p in pacijent17324.Karton) if (p.IdPregleda == tempID) Console.WriteLine(p.ToString());
                else Console.WriteLine("Nije pronadjen ID postojeceg pacijenta koji odgovara zahtjevu.");
        }
        public void PretragaPoLicenci(Pacijent pacijent17324, bool dobarUnos)
        {
            int tempLicenca;
            do
            {
                Console.Write("Unesite licencu doktora cije preglede zelite izlistati: ");
                var UnosStringa = Console.ReadLine();
                dobarUnos = Int32.TryParse(UnosStringa, out tempLicenca);
            } while (!dobarUnos);
            foreach (Pregled p in pacijent17324.Karton) if (p.D.BrojLicence == tempLicenca) Console.WriteLine(p.ToString());
                else Console.WriteLine("Nije pronadjen pregled sa brojem licence koji odgovara zahtjevu.");

        }
        delegate void DelegatZaKriterijPretrage(Pacijent pacijent17324, bool dobarUnos);
        public void PretragaKartona(ref List<Pacijent> pacijenti)
        {
            bool dobarUnos = false;
            Pacijent pacijent17324 = new Pacijent_NormalnaProcedura(); //normalna procedura za dodavanje pacijenta
            bool neuspjelaPretragaKartona = false; //ovo nekako izbaciti kasnije
            do
            {
                Console.Write("Unesite ime pacijenta kojem zelite pretraziti karton: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem zelite pretraziti karton: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)))
                //case insensitive provjera
                {
                    do
                    {
                        Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen. Provjerite da li je evidentiran u sistemu te da li mu je kreiran karton.\nDa li zelite:\n1. Pokusati ponovo\n2. Odustati od pretrage kartona");
                        var unosStringa = Console.ReadLine();
                        dobarUnos = Int32.TryParse(unosStringa, out int unos);
                        if (!dobarUnos)
                        {
                            Console.Write("Neispravan unos. Pokusajte ponovo. ");
                            continue;
                        }
                        //ako je unos 1 petlja ce sama napraviti krug
                        if (unos == 2) break;
                    } while (!dobarUnos);
                }
                else
                {
                    pacijent17324 = pacijenti.Find(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase) && String.Equals(x.Prezime, prezime, StringComparison.OrdinalIgnoreCase));
                    //case insensitive
                    bool sveUredu;
                    do
                    {
                        Console.WriteLine("Dobro dosli u modul za pretragu kartona pacijenta {0} {1}. \nIzaberite kriterij pretrage:\n1. Datum pregleda\n2. Riječ ili fraza koja je podstring propisane terapije\n3. Riječ ili fraza koja je podstring mišljenja ljekara nakon pregleda\n4. Riječ ili fraza koja je podstring provedenog postupka\n5. ID provedenog pregleda\n6. Broj licence doktora koji je izvrsio pregled", pacijent17324.Ime, pacijent17324.Prezime);
                        var parse = Console.ReadLine();
                        sveUredu = Int32.TryParse(parse, out int unos);
                        switch (unos)
                        {
                            case 1:
                                {
                                    DelegatZaKriterijPretrage d17324_1 = PretragaPoDatumu;
                                    d17324_1(pacijent17324, dobarUnos);
                                    break;
                                }
                            case 2:
                                {
                                    DelegatZaKriterijPretrage d17324_2 = PretragaPoTerapiji;
                                    d17324_2(pacijent17324, dobarUnos);
                                    break;
                                }
                            case 3:
                                {
                                    DelegatZaKriterijPretrage d17324_3 = PretragaPoMisljenju;
                                    d17324_3(pacijent17324, dobarUnos);
                                    break;
                                }
                            case 4:
                                {
                                    DelegatZaKriterijPretrage d17324_4 = PretragaPoPostupku;
                                    d17324_4(pacijent17324, dobarUnos);
                                    break;
                                }
                            case 5:
                                {
                                    DelegatZaKriterijPretrage d17324_5 = PretragaPoIDu;
                                    d17324_5(pacijent17324, dobarUnos);
                                    break;
                                }
                            case 6:
                                {
                                    DelegatZaKriterijPretrage d17324_6 = PretragaPoLicenci;
                                    d17324_6(pacijent17324, dobarUnos);
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
                    Console.WriteLine("Uspjesno izvrsena pretraga kartona {0} {1}.\n", pacijent17324.Ime, pacijent17324.Prezime);
                    break;
                }
            } while (true);

        }
        public void Anamneza(Pacijent p)
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
        public void RegistracijaPregleda(ref List<Pacijent> pacijenti, ref List<Doktor> doktori, ref List<Ordinacija> ordinacije, ref List<Tuple<Pregled, decimal>> paroviRacuna)
        {
            Console.WriteLine("Dobro dosli u modul za registraciju pregleda.");
            bool prekidKreiranjaPregleda = true; //da je lakse u petlji opovrgnuti negaciju
            do
            {
                Pacijent temp = new Pacijent_NormalnaProcedura();
                Pregled pregled = new Pregled(DateTime.Today, "", "", "", temp); //SVAKI KONSTRUKTOR BI TREBAO OVAKO!
                Console.Write("Unesite ime pacijenta kojem kreirate pregled: ");
                string ime = Console.ReadLine();
                bool dobarUnos = false;
                bool izadjiIzPetljeOdmah = false;
                Console.Write("Unesite prezime pacijenta kojem kreirate pregled: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)))
                //case insensitive
                {
                    do
                    {
                        Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Kreirati novog pacijenta te njegov pripadajuci karton\n3. Odustati od kreiranja pregleda");
                        var unosStringa = Console.ReadLine();
                        dobarUnos = Int32.TryParse(unosStringa, out int unos);
                        if (!dobarUnos)
                        {
                            Console.Write("Neispravan unos. Pokusajte ponovo. ");
                            continue;
                        }
                        //ako je unos 1 petlja ce sama napraviti krug
                        if (unos == 2)
                        {
                            RegistrujPacijenta(ref pacijenti, ref ordinacije);
                            KreirajKarton(ref pacijenti, ref ordinacije);
                        }
                        //mozda ovdje jos dodati da ne trazi ime i prezime opet hm?
                        else if (unos == 3) break;
                    } while (!dobarUnos);
                }
                //ovdje treba slucaj kad nema karton i ponuditi da se kreira, napravio sam bool za provjeru :)
                else
                {
                    temp = pacijenti.Find(x => (String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && (String.Equals(x.Prezime, prezime, StringComparison.OrdinalIgnoreCase))); //instanciranje mozda sa indeksom?
                    if (temp.IspravanKarton == false) //ako nema karton, kreiraj
                    {
                        do
                        {
                            Console.WriteLine("Pacijent sa tim imenom i prezimenom je pronadjen, ali nema kreiran karton.\nDa li zelite:\n1. Kreirati karton pacijentu \n2. Odustati od kreiranja pregleda");
                            var unosStringa = Console.ReadLine();
                            dobarUnos = Int32.TryParse(unosStringa, out int unos);
                            if (!dobarUnos)
                            {
                                Console.Write("Neispravan unos. Pokusajte ponovo. ");
                                continue;
                            }
                            if (unos == 1) KreirajKarton(ref pacijenti, ref ordinacije);
                            else break;
                        } while (!dobarUnos);
                    }
                    else
                    {
                        pregled = new Pregled(temp);
                        do
                        {
                            Console.Write("Unesite datum kada je pregled obavljen (DD/MM/YYYY): ");
                            string s = Console.ReadLine();
                           // dobarUnos = DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out pregled.DatumVrijemePregleda);
                            if (!dobarUnos) Console.Write("Pogresan unos. Pokusajte ponovo.");
                        } while (!dobarUnos);
                        Console.Write("Koji postupak je proveden prilikom pregleda? ");
                        pregled.Postupak = Console.ReadLine();
                        Console.Write("Kakvo je misljenje ljekara nakon pregleda? ");
                        pregled.MisljenjeLjekara = Console.ReadLine();
                        Console.Write("Koja terapija je propisana pacijentu? ");
                        pregled.Terapija = Console.ReadLine();
                        do
                        {
                            int licenca;
                            do
                            {
                                Console.Write("Molimo unesite broj licence doktora koji propisuje terapiju: ");
                                var unosStringa = Console.ReadLine();
                                dobarUnos = Int32.TryParse(unosStringa, out licenca);
                            } while (!dobarUnos);
                            //sada provjerimo da li je validan doktor ili je prevarant :)
                            foreach (Doktor doktor17324 in doktori)
                                if (doktor17324.BrojLicence == licenca)
                                {
                                    Console.WriteLine("Terapiju propisao doktor {0} {1}", doktor17324.ImeUposlenika, doktor17324.PrezimeUposlenika);
                                    pregled.D = doktor17324;
                                    pregled.D.BrojPregledanihPacijenata++; //inkrementiramo mu brojac pacijenata
                                    prekidKreiranjaPregleda = false;
                                    do
                                    {
                                        dobarUnos = true;
                                        if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                                        Console.Write("Zelite li zavrsiti pregled i pozvati narednog pacijenta (D/N)? ");
                                        string unos = Console.ReadLine();
                                        unos = unos.ToUpper();
                                        dobarUnos = Char.TryParse(unos, out char krajPregleda);
                                        if (krajPregleda == 'D')
                                        {
                                            //saznati koja je ordinacija brute force (lose ali sta cu)
                                            foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="dermatolog")
                                                {
                                                    if (o.SefKlinike.BrojLicence == doktor17324.BrojLicence)
                                                    {
                                                        Console.WriteLine("Uspjesno zavrsen pregled kod dermatologa.");
                                                        o.RedCekanja.Dequeue();
                                                        if (o.RedCekanja.Count() == 0) Console.WriteLine("Nema vise pacijenata u redu cekanja.");
                                                        else Console.WriteLine("Iduci pacijent je: {0} {1}", o.RedCekanja.Peek().P.Ime, o.RedCekanja.Peek().P.Prezime);
                                                        paroviRacuna.Add(Tuple.Create(pregled, o.IznosPlacanja(pregled)));
                                                        izadjiIzPetljeOdmah = true;
                                                    }
                                                }
                                            if (izadjiIzPetljeOdmah) break;
                                            foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="kardiolog")
                                                {
                                                    if (o.SefKlinike.BrojLicence == doktor17324.BrojLicence) o.RedCekanja.Dequeue();
                                                    {
                                                        Console.WriteLine("Uspjesno zavrsen pregled kod kardiologa.");
                                                        if (o.RedCekanja.Count() == 0) Console.WriteLine("Nema vise pacijenata u redu cekanja.");
                                                        else Console.WriteLine("Iduci pacijent je: {0} {1}", o.RedCekanja.Peek().P.Ime, o.RedCekanja.Peek().P.Prezime);
                                                        paroviRacuna.Add(Tuple.Create(pregled, o.IznosPlacanja(pregled)));
                                                        izadjiIzPetljeOdmah = true;
                                                    }
                                                }
                                            if (izadjiIzPetljeOdmah) break;
                                            foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="ortoped")
                                                {
                                                    if (o.SefKlinike.BrojLicence == doktor17324.BrojLicence) o.RedCekanja.Dequeue();
                                                    {
                                                        Console.WriteLine("Uspjesno zavrsen pregled kod ortopeda.");
                                                        if (o.RedCekanja.Count() == 0) Console.WriteLine("Nema vise pacijenata u redu cekanja.");
                                                        else Console.WriteLine("Iduci pacijent je: {0} {1}", o.RedCekanja.Peek().P.Ime, o.RedCekanja.Peek().P.Prezime);
                                                        paroviRacuna.Add(Tuple.Create(pregled, o.IznosPlacanja(pregled)));
                                                        izadjiIzPetljeOdmah = true;
                                                    }
                                                }
                                            if (izadjiIzPetljeOdmah) break;
                                            foreach (Ordinacija o in ordinacije) if (o.NazivKlinike=="stomatolog")
                                                {
                                                    if (o.SefKlinike.BrojLicence == doktor17324.BrojLicence) o.RedCekanja.Dequeue();
                                                    {
                                                        Console.WriteLine("Uspjesno zavrsen pregled kod stomatologa.");
                                                        if (o.RedCekanja.Count() == 0) Console.WriteLine("Nema vise pacijenata u redu cekanja.");
                                                        else Console.WriteLine("Iduci pacijent je: {0} {1}", o.RedCekanja.Peek().P.Ime, o.RedCekanja.Peek().P.Prezime);
                                                        paroviRacuna.Add(Tuple.Create(pregled, o.IznosPlacanja(pregled)));
                                                        izadjiIzPetljeOdmah = true;
                                                    }
                                                }
                                            if (izadjiIzPetljeOdmah) break;
                                        }
                                        if (krajPregleda != 'D' && krajPregleda != 'N') dobarUnos = false;
                                    } while (!dobarUnos);
                                }
                            if (prekidKreiranjaPregleda) Console.WriteLine("Neispravna licenca. Pokusajte ponovno. ");
                        } while (prekidKreiranjaPregleda);
                    }
                }
                if (!prekidKreiranjaPregleda)
                {
                    Console.WriteLine("Uspjesno kreiran pregled sa ID {0} za pacijenta {1} {2}.\n", pregled.IdPregleda, temp.Ime, temp.Prezime);
                    temp.Karton.Add(pregled);
                    break;
                }
            } while (true);
        }
        public void RegistrujPacijenta(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
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
                //EvidentirajPrvuPomoc(ref pacijent17324_1); //should be ok
                pacijenti.Add(pacijent17324_1);
                UnosPodataka(pacijent17324_1 as Pacijent, true, true, true, true); //polimorfno as
            }
            if (prioritet == 2)
            {
                UnosPodataka(pacijent17324_2 as Pacijent, true, true, true, true);//polimorfno as
                pacijenti.Add(pacijent17324_2);
            }
        }
        public void ObrisiPacijenta(List<Pacijent> pacijenti)
        {
            bool uspjeh = false;
            bool dobarUnos = false;
            int unos;
            Pacijent temp = new Pacijent_NormalnaProcedura();
            Console.WriteLine("U sistemu postoje sljedeci pacijenti: ");
            foreach (Pacijent p in pacijenti) Console.WriteLine(p.ToString());
            do
            {
                Console.Write("Molimo unesite ID pacijenta kojeg zelite obrisati: ");
                var unosStringa = Console.ReadLine();
                dobarUnos = Int32.TryParse(unosStringa, out unos);
                if (!dobarUnos) Console.Write("Pogresan unos. Pokusajte ponovo. ");
            } while (!dobarUnos);
            foreach (Pacijent p in pacijenti)
            {
                if (p.IdPacijenta == unos)
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
        public void DodajBrisi(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
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
        public void Naplata(ref List<Pacijent> pacijenti, ref List<Tuple<Pregled, decimal>> pregledIznosNaplate, ref List<decimal> naplaceno)
        {
            decimal saldoUkupni = 0M;
            string temp;
            int unos;
            bool pronadjen = false;
            bool dobarUnos = true;
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.WriteLine("Dobro dosli u modul za printanje racuna. Molimo izaberite vrstu placanja: \n1. Gotovinsko placanje\n2. Placanje na rate");
                temp = Console.ReadLine();
                dobarUnos = Int32.TryParse(temp, out unos);
                if (unos < 1 || unos > 2) dobarUnos = false;
            } while (!dobarUnos);
            do
            {

                Console.Write("Unesite ime pacijenta kojem printate racun: ");
                string ime = Console.ReadLine();
                Console.Write("Unesite prezime pacijenta kojem printate racun: ");
                string prezime = Console.ReadLine();
                if (!pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)))
                //case insensitive
                {
                    Console.WriteLine("Pacijent sa tim imenom i prezimenom nije pronadjen\nDa li zelite:\n1. Pokusati ponovo\n2. Odustati od naplate");
                    temp = Console.ReadLine();
                    dobarUnos = Int32.TryParse(temp, out int unosPonovo);
                    if (unosPonovo != 2) dobarUnos = false;
                }
                else
                {
                    var pacijent17324 = pacijenti.Find(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase) && String.Equals(x.Prezime, prezime, StringComparison.OrdinalIgnoreCase));
                    //case insensitive
                    if (pregledIznosNaplate.Count == 0)
                    {
                        Console.WriteLine("Opcenito nema evidentiranih pregleda koji nisu placeni.");
                        break;
                    }
                    foreach (Tuple<Pregled, decimal> t in pregledIznosNaplate)
                    {
                        if (t.Item1.P == pacijent17324)
                        {
                            Console.WriteLine("Pregled \"{0}\", iznos {1}", t.Item1.Postupak, t.Item2);
                            saldoUkupni += t.Item2;
                            pronadjen = true;
                        }
                    }
                    if (!pronadjen)
                    {
                        Console.WriteLine("Nema evidentiranih pregleda za placanje kod pacijenta {0} {1}.", pacijent17324.Ime, pacijent17324.Prezime);
                        break;
                    }
                    pacijent17324.PosjetioKliniku++; //inkrementacija nakon placanja;
                    if (unos == 2 && pacijent17324.PosjetioKliniku < 3)
                    {
                        saldoUkupni *= 1.15M; //ako novi pacijent placa na rate onda je cijena veca za 15%
                        Console.WriteLine("Cijena je uvecana za 15% jer je pacijent platio na rate, a nije redovan u klinici.");
                    }
                    if (unos == 1 && pacijent17324.PosjetioKliniku >= 3)
                    {
                        saldoUkupni *= 0.9M; //ako novi pacijent placa na rate onda je cijena veca za 15%
                        Console.WriteLine("Cijena je smanjena za 10% jer je pacijent platio u gotovini, kao redovan u klinici.");
                    }
                    Console.WriteLine("\nUkupni saldo za pacijenta {0} {1} je {2} KM.", pacijent17324.Ime, pacijent17324.Prezime, saldoUkupni);
                    if (unos == 2) //sredjujemo broj rata
                    {
                        do
                        {
                            Console.Write("Obzirom da ste izabrali placanje na rate molimo unesite broj zeljenih rata (max 12): ");
                            var unosBrojaRata = Console.ReadLine();
                            dobarUnos = Int32.TryParse(unosBrojaRata, out int brojRata);
                            if (brojRata > 12) dobarUnos = false;
                            if (!dobarUnos) Console.Write("Pogresan unos. Pokusajte ponovo: ");
                            else Console.Write("Mjesecna rata iznosi {0} KM, izabrali ste placanje na {1} rata. ", Decimal.Round(saldoUkupni / brojRata, 2), brojRata); //zaokruzimo na 2 decimale
                        } while (!dobarUnos);
                    }
                    naplaceno.Add(saldoUkupni);
                    saldoUkupni = 0; //resetujemo saldo
                }

            } while (!dobarUnos);

        }
        public void Analiza(ref List<Pacijent> pacijenti, ref List<Doktor> doktori, ref List<Ordinacija> ordinacije, ref List<decimal> naplaceno)
        {
            bool dobarUnos = true;
            string temp;
            int unos;
            do
            {
                if (!dobarUnos) Console.Write("Neispravan unos. Pokusajte ponovo: "); //ako smo u petlji 1+ puta neispravan je unos
                Console.WriteLine("Dobro dosli u modul za analizu poslovanja. Molimo izaberite vrstu analize: \n1. Analiza prosječnog broja pregledanih pacijenata\n2. Analiza prosječnog iznosa računa\n3. Analiza udjela pusaca i alkoholicara medju pacijentima");
                temp = Console.ReadLine();
                dobarUnos = Int32.TryParse(temp, out unos);
                if (unos < 1 || unos > 3) dobarUnos = false;
            } while (!dobarUnos);
            if (unos == 1)
            {
                double sumaPregledanih = 0;
                if (doktori.Count == 0) Console.WriteLine("Nema registriranih doktora.");
                else
                {
                    foreach (Doktor d in doktori) sumaPregledanih += d.BrojPregledanihPacijenata;
                    Console.WriteLine("Prosjecan broj pregledanih pacijenata po doktoru iznosi: {0}.", sumaPregledanih / doktori.Count);
                }
            }
            if (unos == 2)
            {
                decimal sumaRacuna = 0;
                if (naplaceno.Count == 0) Console.WriteLine("Nema naplacenih pregleda.");
                else
                {
                    foreach (decimal d in naplaceno) sumaRacuna += d;
                    Console.WriteLine("Prosjecan iznos naplacenih pregleda iznosi: {0}.", sumaRacuna / naplaceno.Count);
                }
            }
            if (unos == 3)
            {
                double sumaPusaca = 0;
                double sumaAlkoholicara = 0;
                if (pacijenti.Count == 0) Console.WriteLine("Nema evidentiranih pacijenata.");
                else
                {
                    foreach (Pacijent p in pacijenti)
                    {
                        if (p.pusac) sumaPusaca++;
                        if (p.alkoholicar) sumaAlkoholicara++;
                    }
                    sumaPusaca *= 100;
                    sumaAlkoholicara *= 100;
                    //pretvaranje u procente
                    Console.WriteLine("Udio pusaca medju pacijentima iznosi {0}%, dok udio alkoholicara iznosi {1}%.", sumaPusaca / pacijenti.Count, sumaAlkoholicara / pacijenti.Count);
                }
            }
        }

    }
}
