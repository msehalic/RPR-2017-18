using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class BachelorStudij : Studij
    {
        List<string> listaKantona = new List<string>();
        List<Predmet> predmetiStudija = new List<Predmet>();
        public BachelorStudij(string nazivStudija, long brojGodinaStudija, string kanton) : base(nazivStudija, brojGodinaStudija)
        {
            listaKantona.Add(kanton); //dodaje uneseni kanton na listu dozvoljenih
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
            novinaziv += "BSC";
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
