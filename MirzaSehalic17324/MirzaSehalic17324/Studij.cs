using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    abstract class Studij
    {
        private string nazivStudija;
        private string IDStudija;
        Int64 brojGodinaStudija;
        public Studij(string nazivStudija, long brojGodinaStudija)
        {
            NazivStudija = nazivStudija;
            IDStudija = kreirajIDstudija(nazivStudija);
            BrojGodinaStudija = brojGodinaStudija;
        }

        public long BrojGodinaStudija
        {
            get
            {
                return brojGodinaStudija;
            }

            set
            {
                brojGodinaStudija = value;
            }
        }

        public string IDStudija1
        {
            get
            {
                return IDStudija;
            }

            set
            {
                IDStudija = value;
            }
        }

        public string NazivStudija
        {
            get
            {
                return nazivStudija;
            }

            set
            {
                nazivStudija = value;
            }
        }
        public abstract string kreirajIDstudija(string naziv);
        public abstract Int64 dajUkupanBrojECTS();
    }
}
