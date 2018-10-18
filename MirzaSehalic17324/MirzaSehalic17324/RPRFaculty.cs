using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class RPRFaculty : IPretraga //KONTEJNERSKA KLASA
    {
        public List<Studij> listaStudija = new List<Studij>();
        public List<Predmet> listaPredmeta = new List<Predmet>();
        public List<Student> listaStudenata = new List<Student>();
        public List<Predmet> pretragaPoNazivu(string uneseni) //ako naziv sadrzi unesene karaktere
        {
            List<Predmet> povratnaLista = new List<Predmet>();
            foreach (Predmet predmet17324 in listaPredmeta) if (predmet17324.NazivPredmeta.Contains(uneseni)) povratnaLista.Add(predmet17324);
            return povratnaLista;
        }
        public List<Predmet> pretragaPoPredmetu(Predmet predmet) //ako je tacno kreiran model jednak postojecem
        {
            List<Predmet> povratnaLista = new List<Predmet>();
            foreach (Predmet predmet17324 in listaPredmeta) if (predmet == predmet17324) povratnaLista.Add(predmet17324);
            return povratnaLista;
        }

    }
}
