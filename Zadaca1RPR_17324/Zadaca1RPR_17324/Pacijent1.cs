using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    abstract partial class Pacijent//partial dio sa metodama
    {
        string ime, prezime, datumRodjenja, adresaStanovanja, bracnoStanje, datumPrijema;
        char spol;
        int posjetioKliniku = 0; //broji koliko je puta odredjeni pacijent bio u klinici, kada dostigne 3 idu popusti itd.
        public long MaticniBroj
        {
            get
            {
                return MaticniBroj;
            }
            set
            {
                var ima13Cifara = Math.Floor(Math.Log10(value) + 1) == 13; //provjera da ima 13 cifara
                if (value>0 && ima13Cifara) MaticniBroj = value;
            }
        }

        List<Pacijent> pacijenti = new List<Pacijent>();

    }
}
