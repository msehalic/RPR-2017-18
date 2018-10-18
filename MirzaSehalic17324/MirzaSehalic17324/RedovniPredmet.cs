using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class RedovniPredmet : Predmet
    {
        public RedovniPredmet(string nazivPredmeta, string nazivProfesora, long brojPredavanja, long brojVjezbi, long brojTutorijala, long brojECTS) : base(nazivPredmeta, nazivProfesora, brojPredavanja, brojVjezbi, brojTutorijala, brojECTS)
        {
        }
    }
}
