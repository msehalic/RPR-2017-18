using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;

namespace Zadaca1RPR_17324
{
    class Pacijent_HitnaProcedura : Pacijent
    {
        public bool PacijentZiv { get; set; }
        public Pacijent_HitnaProcedura() //: base(MaticniBroj, ime, prezime, datumRodjenja, spol, adresaStanovanja, bracnoStanje, datumPrijema)
        {
            PacijentZiv = true; //defaultni za instance
            GenerisiIDPacijenta();
        }
      
    }
}
