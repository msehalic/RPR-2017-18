using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPR_T1_Z4
{
    class Program
    {
        static void Main(string[] args)
        {
            Predmet[] predmeti = new Predmet[1];
            predmeti[0] = new Predmet("LAG", "123", 100);
            Student[] studenti = new Student[1];
            Console.WriteLine("Opcije:\n1.Unos studenata\n2.Upis Studenta na predmet\n3.Ispis studenta sa predmeta\n4.Izlaz");
            int unos = Convert.ToInt32(Console.ReadLine());
            do
            {
                switch (unos)
                {
                    case 1:
                        Console.Write("Unesite ime studenta: ");
                        string ime = Console.ReadLine();
                        Console.Write("Unesite prezime studenta: ");
                        string prezime = Console.ReadLine();
                        Console.Write("Unesite indeks studenta: ");
                        int indeks = Convert.ToInt32(Console.ReadLine());
                        studenti[studenti.Length - 1] = new Student(ime, prezime, indeks);
                        Array.Resize(ref studenti, studenti.Length);
                        Console.WriteLine("Uspjesno ste unijeli studenta" + ime + " " + prezime + ", sa brojem indeksa: " + indeks);
                        break;
                    case 2:
                        Predmet izabraniPredmet=new Predmet();
                        Console.Write("Birajte predmet unosom sifre:");
                        foreach (Predmet p in predmeti) Console.WriteLine(p.NazivPredmeta + "sifra: " + p.SifraPredmeta);
                        string sifra = Console.ReadLine();
                        foreach (Predmet p in predmeti)
                            if (p.SifraPredmeta == sifra) izabraniPredmet = p;
                        //OVDJE MOZE BITI I IZBOR IZMEDJU VEC UPISANIH STUDENATA ALI MRSKO MI
                        Console.Write("Unesite ime studenta: ");
                        string ime2 = Console.ReadLine();
                        Console.Write("Unesite prezime studenta: ");
                        string prezime2 = Console.ReadLine();
                        Console.Write("Unesite indeks studenta: ");
                        int indeks2 = Convert.ToInt32(Console.ReadLine());
                        Student st = new Student(ime2, prezime2, indeks2);
                        studenti[studenti.Length - 1] = st;
                        Array.Resize(ref studenti, studenti.Length);
                        //BITNA LINIJA
                        izabraniPredmet.upisi(ref st);
                        break;
                    case 4:
                        break;
                }
            } while (unos != 4);
        }
    }
}
