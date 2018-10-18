using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class MasterStudij : Studij
    {
        List<string> potrebniStudijskiProgrami = new List<string>();
        List<Predmet> predmetiStudija = new List<Predmet>();
        public MasterStudij(string nazivStudija, long brojGodinaStudija, string potrebniProgram) : base(nazivStudija, brojGodinaStudija)
        {
            potrebniStudijskiProgrami.Add(potrebniProgram);
        }
       public override string kreirajIDstudija(string naziv) //verzija za master
        {
            Random r=new Random();
            naziv = naziv.ToUpper();
            string novinaziv = "";
            int brojac = 0; //OLD C++ STYLE za 3 samoglasnika
            for (int i = 0; i < naziv.Length; i++)
            {
                if (naziv[i] != 'A' && naziv[i] != 'E' && naziv[i] != 'I' && naziv[i] != 'O' && naziv[i] != 'U')
                {
                    novinaziv = novinaziv + naziv[i];
                    brojac++;
                    if (brojac == 3) break;
                }
            }
            novinaziv += "MSC";
            novinaziv += DateTime.Now.Date.ToString(); //da je lakse odrediti datum najbolje sadasnji
            novinaziv += r.Next();
            novinaziv += r.Next();
            return novinaziv;
        }
        public override long dajUkupanBrojECTS()
        {
            Int64 brojacECTS = 0;
            foreach (Predmet predmet17324 in this.predmetiStudija) brojacECTS += predmet17324.BrojECTS;
            return brojacECTS;
        }
    }
}
