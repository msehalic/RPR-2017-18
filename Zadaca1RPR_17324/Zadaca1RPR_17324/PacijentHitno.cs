using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    class PacijentHitno : Pacijent
    {
        public bool PacijentZiv { get; set; }
        public PacijentHitno() //: base(MaticniBroj, ime, prezime, datumRodjenja, spol, adresaStanovanja, bracnoStanje, datumPrijema)
        {
            PacijentZiv = true; //defaultni za instance
        }
      
        //AKO PACIJENT UMRE TREBALI BISMO MU OTKAZATI I PREGLEDE
        void OtkaziPreglede(List<Pacijent> pacijenti)
        {

        }
    }
}
