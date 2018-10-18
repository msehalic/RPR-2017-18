using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class IzborniPredmet:Predmet
    {
        Int64 minBrojStudenata;
        Int64 maxBrojStudenata;
        string statusPredmeta="Nepotvrdjen";

        public IzborniPredmet(string nazivPredmeta, string nazivProfesora, long brojPredavanja, long brojVjezbi, long brojTutorijala, long brojECTS, long maxBrojStudenata, long minBrojStudenata) : base(nazivPredmeta, nazivProfesora, brojPredavanja, brojVjezbi, brojTutorijala, brojECTS)
        {
            MaxBrojStudenata = maxBrojStudenata;
            MinBrojStudenata = minBrojStudenata;
        }
        public long MaxBrojStudenata
        {
            get
            {
                return maxBrojStudenata;
            }

            set
            {
                maxBrojStudenata = value;
            }
        }

        public long MinBrojStudenata
        {
            get
            {
                return minBrojStudenata;
            }

            set
            {
                minBrojStudenata = value;
            }
        }
    }
}
