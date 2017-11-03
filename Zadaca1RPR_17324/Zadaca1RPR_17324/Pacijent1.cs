using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    abstract partial class Pacijent//partial dio sa metodama
    {
        string ime, prezime, datumRodjenja, spol, adresaStanovanja, bracnoStanje, datumPrijema;
        public int maticniBroj
        {
            get
            {
                return maticniBroj;
            }
            set
            {
                var ima13Cifara = Math.Floor(Math.Log10(value) + 1) == 13; //provjera da ima 13 cifara
                if (value>0 && ima13Cifara) maticniBroj = value;
            }
        }

        List<Pacijent> pacijenti = new List<Pacijent>();

    }
}
