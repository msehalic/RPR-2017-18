using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    interface IOrdinacije
    {
        decimal IznosPlacanja(Pregled pregled17324);
        Queue<Pregled> RedCekanja { get; set; }
        string NazivKlinike { get; set; }
        Doktor SefKlinike { get; set; }
    }
}
