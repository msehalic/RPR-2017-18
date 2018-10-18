using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MirzaSehalic17324
{
    class Program
    {
        private static Form forma;
        private static Label labela;
        static void ispisGreskeKonzola()
        {
            Console.WriteLine("Nije pronadjen predmet po zadatom kriteriju!");
        }
        static void ispisGreskeForma()
        {
        forma = new Form();
            forma.StartPosition = FormStartPosition.CenterScreen;
            forma.Size = new Size(285, 340);
            forma.MaximumSize = forma.Size;
            forma.MinimumSize = forma.Size;
            forma.MaximizeBox = false;
            forma.Text = "Greska";
            labela = new Label();
            labela.Location = new Point(100, 100);
            labela.Text = "Nije pronadjen predmet po zadatom kriteriju!";
            forma.Controls.Add(labela);
            Application.Run(forma);
        }
        delegate void MojDelegat(); //zajednicki ispis greske
        static void Main(string[] args)
        {
            RPRFaculty Fakultet=new RPRFaculty(); //instanca kontejnerske klase

            Fakultet.listaStudija.Add(new BachelorStudij("Bachelor Racunarstva I Informatike", 3, "KS"));
            Fakultet.listaStudija.Add(new MasterStudij("Master Racunarstva I Informatike", 2, "ETF Bachelor"));
            Fakultet.listaStudija.Add(new PHDStudij("PhD Racunarstva I Informatike", 3));

            Fakultet.listaPredmeta.Add(new RedovniPredmet("Razvoj programskih rjesenja", "Dzenana Djonko", 40, 20, 0, 5));
            Fakultet.listaPredmeta.Add(new RedovniPredmet("Motanje kablova", "Neki zanimljiv profesor", 20, 30, 10, 4));
            Fakultet.listaPredmeta.Add(new RedovniPredmet("Kanali i kodiranje", "Neki dosadan profesor", 30, 20, 20, 6));

            Fakultet.listaPredmeta.Add(new IzborniPredmet("Dobar izborni", "Normalan profesor", 40, 20, 0, 5, 5, 15));
            Fakultet.listaPredmeta.Add(new IzborniPredmet("Motanje kablova", "Neki zanimljiv profesor", 20, 30, 10, 4, 10, 50));
            Fakultet.listaPredmeta.Add(new IzborniPredmet("Kanali i kodiranje", "Neki dosadan profesor", 30, 20, 20, 6, 20, 100));

            Console.WriteLine("Molimo izaberite opciju:\n1. Pretraga po nazivu predmeta\n2. Pretraga po predmetu\n3. Prijava na predmet\n4. Analiza predmeta");
            int unos = Convert.ToInt32(Console.ReadLine());
            switch (unos)
            {
                case 1:
                    Console.WriteLine("Unesite naziv predmeta kojeg zelite pretraziti: ");
                   string nazivPredmeta = Console.ReadLine();
                    List<Predmet> pronadjeniPredmeti = Fakultet.pretragaPoNazivu(nazivPredmeta);
                    if (pronadjeniPredmeti.Count==0)
                    {
                        //konzola
                        MojDelegat delegat17324_1 = ispisGreskeKonzola;
                        delegat17324_1();
                        //forma
                        MojDelegat delegat17324_2 = ispisGreskeForma;
                        delegat17324_2();
                    }
                    break;
    
            }

        }
    }
}
