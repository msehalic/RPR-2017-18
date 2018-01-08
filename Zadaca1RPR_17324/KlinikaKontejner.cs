using Doktori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zadaca1RPR_17324
{

    public class KlinikaKontejner
    {
        private static List<Pacijent> pacijenti = new List<Pacijent>();
        private static List<Doktor> doktori = new List<Doktor>();
        private static List<Ordinacija> ordinacije = new List<Ordinacija>();
        private static List<Uposlenik> uposlenici = new List<Uposlenik>();
        List<double> naplaceno = new List<double>(); 

        public List<Pacijent> Pacijenti { get => pacijenti; set => pacijenti = value; }
        public List<Doktor> Doktori { get => doktori; set => doktori = value; }
        public List<Ordinacija> Ordinacije { get => ordinacije; set => ordinacije = value; }
        public List<Uposlenik> Uposlenici { get => uposlenici; set => uposlenici = value; }
        public List<double> Naplaceno { get => naplaceno; set => naplaceno = value; }

        //nekoliko doktora za potrebe testiranja
        static Doktor doktor17324_1 = new Doktor("Ahmed", "Ahmedic", 123, 0, "dermatolog"); //dermatolog, broj licence 123
        static Doktor doktor17324_2 = new Doktor("Emina", "Tutic", 456, 0, "kardiolog"); //kardiolog, broj licence 456
        static Doktor doktor17324_3 = new Doktor("Marko", "Kikic", 789, 0, "ortoped"); //ortoped, broj licence 789
        static Doktor doktor17324_4 = new Doktor("Pavle", "Bisercic", 555, 0, "stomatolog"); //stomatolog, broj licence 555

        //kreirajmo ordinacije i postavimo odgovarajuce sefove
        Ordinacija ordinacija17324_dermatolog = new Ordinacija("dermatolog", doktor17324_1);
        Ordinacija ordinacija17324_kardiolog = new Ordinacija("kardiolog", doktor17324_2);
        Ordinacija ordinacija17324_ortoped = new Ordinacija("ortoped", doktor17324_3);
        Ordinacija ordinacija17324_stomatolog = new Ordinacija("stomatolog", doktor17324_4);

        public KlinikaKontejner() 
        {
            doktori.Add(doktor17324_1);
            doktori.Add(doktor17324_2);
            doktori.Add(doktor17324_3);
            doktori.Add(doktor17324_4);
            ordinacije.Add(ordinacija17324_dermatolog);
            ordinacije.Add(ordinacija17324_kardiolog);
            ordinacije.Add(ordinacija17324_ortoped);
            ordinacije.Add(ordinacija17324_stomatolog);
            Uposlenici.Add(new Administrator("Klinika", "Admin", null, 9999, "admin", "admin"));
            Uposlenici.Add(new Tehnicar("Samir", "Samirovic", null, 1000, "samir", "samir1"));
            Uposlenici.Add(new Doktor("Doktor", "Doktorcic", null, 2000, "doktor", "doktor1", 0, "dermatolog"));
          
        }
        public Tuple<int, int, int, int> UnosPodataka(Pacijent p, bool dermatolog, bool kardiolog, bool ortoped, bool stomatolog)
        {
            int cekanjeDermatolog = 0, cekanjeKardiolog = 0, cekanjeOrtoped = 0, cekanjeStomatolog = 0;
            //Dermatolog
            if (dermatolog)
            {
                ordinacija17324_dermatolog.RedCekanja.Enqueue(new Pregled(p));
                cekanjeDermatolog = ordinacija17324_dermatolog.RedCekanja.Count;
            }
            //kardiolog
            if (kardiolog)
            {
                ordinacija17324_kardiolog.RedCekanja.Enqueue(new Pregled(p));
                cekanjeKardiolog = ordinacija17324_kardiolog.RedCekanja.Count;
            }
            //ortoped
            if (ortoped)
            {
                ordinacija17324_ortoped.RedCekanja.Enqueue(new Pregled(p));
                cekanjeOrtoped = ordinacija17324_ortoped.RedCekanja.Count;
            }
            //stomatolog
            if (stomatolog)
            {
                ordinacija17324_stomatolog.RedCekanja.Enqueue(new Pregled(p));
                cekanjeStomatolog = ordinacija17324_stomatolog.RedCekanja.Count;
            }
            return Tuple.Create(cekanjeDermatolog, cekanjeKardiolog, cekanjeOrtoped, cekanjeStomatolog);
        }
        public List<string> GenerisiRaspored(Pacijent p)
        {
            int dermatolog = 0, kardiolog = 0, ortoped = 0, stomatolog = 0;
            List<string> povratniDoktori = new List<string>();
            List<Tuple<string, int, Doktor>> nizCekanjaOrdinacija = new List<Tuple<string, int, Doktor>>();//dinamicki ce se sortirati bez obzira koliko ima ordinacija
            foreach (Pregled pregled17324 in ordinacija17324_dermatolog.RedCekanja) if (pregled17324.P == p) dermatolog = ordinacija17324_dermatolog.RedCekanja.ToList().IndexOf(pregled17324);
            //Dermatolog
            if (dermatolog > 0)
            {
                nizCekanjaOrdinacija.Add(Tuple.Create("dermatolog", dermatolog, ordinacija17324_dermatolog.SefKlinike));
            }
            //kardiolog
            if (kardiolog > 0)
            {
                nizCekanjaOrdinacija.Add(Tuple.Create("kardiolog", kardiolog, ordinacija17324_kardiolog.SefKlinike));

            }
            //ortoped
            if (ortoped > 0)
            {
                nizCekanjaOrdinacija.Add(Tuple.Create("ortoped", ortoped, ordinacija17324_ortoped.SefKlinike));

            }
            //stomatolog
            if (stomatolog > 0)
            {
                nizCekanjaOrdinacija.Add(Tuple.Create("stomatolog", stomatolog, ordinacija17324_stomatolog.SefKlinike));

            }
            nizCekanjaOrdinacija.Sort(delegate (Tuple<string, int, Doktor> x, Tuple<string, int, Doktor> y)
                    {
                        return x.Item2.CompareTo(y.Item2); //sortira po broju ljudi u redu cekanja
                    });
            foreach (Tuple<string, int, Doktor> t in nizCekanjaOrdinacija)
                povratniDoktori.Add(t.Item1);
            return povratniDoktori;
        }


        public void PretragaPoDatumu(Pacijent pacijent17324, bool dobarUnos)
        {
            string tempDan = "";
            //DateTime datum_17324 = DateTime.Parse(tempDan);
            //DEBUG foreach (Pregled p in temp.karton) ("Hej ja sam definiran kao {0}", p.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy"));
            foreach (Pregled p in pacijent17324.Karton) if (pacijent17324.Karton.Exists(x => x.DatumVrijemePregleda.ToString("dd\\/MM\\/yyyy").Equals(tempDan))) tempDan=(p.ToString());
                else throw new Exception("Nije pronadjena komponenta pregleda na datum koji odgovara zahtjevu.");
        }
        public void PretragaPoTerapiji(Pacijent pacijent17324, bool dobarUnos)
        {
            string tempRijec = "";
            foreach (Pregled p in pacijent17324.Karton) if (p.Terapija.Contains(tempRijec)) tempRijec=(p.ToString());
                else throw new Exception("Nije pronadjena komponenta u terapiji koja odgovara zahtjevu.");
        }
        public void PretragaPoPostupku(Pacijent pacijent17324, bool dobarUnos)
        {
            string tempRijec = "";
            foreach (Pregled p in pacijent17324.Karton) if (p.Postupak.Contains(tempRijec)) tempRijec=(p.ToString());
                else throw new Exception("Nije pronadjena komponenta u nazivu provedenog postupka koja odgovara zahtjevu.");

        }
        public void PretragaPoMisljenju(Pacijent pacijent17324, bool dobarUnos)
        {
            string tempRijec="";
            foreach (Pregled p in pacijent17324.Karton) if (p.MisljenjeLjekara.Contains(tempRijec)) tempRijec=(p.ToString());
                else throw new Exception("Nije pronadjena komponenta u misljenju ljekara koja odgovara zahtjevu.");
        }

        public void PretragaPoLicenci(Pacijent pacijent17324, bool dobarUnos)
        {
            int tempLicenca;
            string neki="";
            do
            {
                dobarUnos = Int32.TryParse(neki, out tempLicenca);
            } while (!dobarUnos);
            foreach (Pregled p in pacijent17324.Karton) if (p.D.BrojLicence == tempLicenca) neki=(p.ToString());

        }
        delegate void DelegatZaKriterijPretrage(Pacijent pacijent17324, bool dobarUnos);
        public void PretragaKartona(ref List<Pacijent> pacijenti)
        {
            string ime="", prezime="";
            bool dobarUnos = false;
            int unos = 0;
            Pacijent pacijent17324 = new Pacijent_NormalnaProcedura(); //normalna procedura za dodavanje pacijenta
            bool neuspjelaPretragaKartona = false; //ovo nekako izbaciti kasnije
            do
            {
                if (!pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)) && !pacijenti.Exists(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase)))
                //case insensitive provjera
                {
                    
                }
                else
                {
                    pacijent17324 = pacijenti.Find(x => String.Equals(x.Ime, ime, StringComparison.OrdinalIgnoreCase) && String.Equals(x.Prezime, prezime, StringComparison.OrdinalIgnoreCase));
                    //case insensitive

                    do
                    {
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

                            case 6:
                                {
                                    DelegatZaKriterijPretrage d17324_6 = PretragaPoLicenci;
                                    d17324_6(pacijent17324, dobarUnos);
                                    break;
                                }

                            default:
                                {
                                    continue;
                                }
                        }
                        //MOZDA JOS KOJA OPCIJA I NACIN PRETRAGE? HMM...
                    } while (false);
                }
                if (!neuspjelaPretragaKartona)
                {
                    break;
                }
            } while (true);

        }


        public void RegistrujPacijenta(ref List<Pacijent> pacijenti, ref List<Ordinacija> ordinacije)
        {
            int prioritet = 0;

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
            int unos=0;
            Pacijent temp = new Pacijent_NormalnaProcedura();

            foreach (Pacijent p in pacijenti)
            {
                if (p.IdPacijenta == unos)
                {
                    temp = p;
                    uspjeh = true;
                    break;
                }
            }
            if (uspjeh) pacijenti.Remove(temp);
            else throw new Exception("Neuspjesno brisanje! Provjerite ID broj pacijenta koji ste unijeli.");
        }

        public void XMLSerial(string lokacija, object objekat, Type tipObjekta)
        {
            XmlSerializer xs;
                xs = new XmlSerializer(tipObjekta);
            using (Stream s = File.Create(lokacija))
                xs.Serialize(s, objekat);
        }
        public void XMLSerialNasljedjivanje(string lokacija, object objekat, Type tipObjekta, List<Type> listica)
        {
            XmlSerializer xs;
            xs = new XmlSerializer(tipObjekta, listica.ToArray());
            using (Stream s = File.Create(lokacija))
                xs.Serialize(s, objekat);
        }
        public void BinSerial(string lokacija, object objekat)
        {
            IFormatter serijalizer = new BinaryFormatter();
            FileStream stream = new FileStream(lokacija, FileMode.Create);
            serijalizer.Serialize(stream, objekat);
            stream.Close();
        }

    }
}

