using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      
        //AKO PACIJENT UMRE TREBALI BISMO MU OTKAZATI I PREGLEDE
        void OtkaziPreglede(List<Pacijent> pacijenti)
        {
            //da li je potrebno ili da ide u main ili da simply obrisemo pacijenta pazeci pri tome na preglede
        }
    }
}
