using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class PHDStudij : Studij
    {
        List<string> istrazivackeGrupe = new List<string>();
        List<Predmet> predmetiStudija = new List<Predmet>();
        public PHDStudij(string nazivStudija, long brojGodinaStudija) : base(nazivStudija, brojGodinaStudija)
        {
        }
        public override string kreirajIDstudija(string naziv) //verzija za master
        {
            Random r = new Random();
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
            novinaziv += "PHD";
            novinaziv += DateTime.Now.Date.ToString(); //da je lakse odrediti datum najbolje sadasnji
            novinaziv += r.Next();
            novinaziv += r.Next();
            return novinaziv;
        }
        public void dodajIstrazivackuGrupu(string istrazivackaGrupa)
        {
            if (istrazivackeGrupe.Count >= 5) throw new Exception("Ne smije postojati preko pet istrazivackih grupa");
            else istrazivackeGrupe.Add(istrazivackaGrupa);
        }
        public override long dajUkupanBrojECTS()
        {
            Int64 brojacECTS = 0;
            foreach (Predmet predmet17324 in this.predmetiStudija) brojacECTS += predmet17324.BrojECTS;
            return brojacECTS;
        }
    }
}
