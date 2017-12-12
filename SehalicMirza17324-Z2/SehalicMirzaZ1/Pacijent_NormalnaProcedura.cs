using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doktori;

namespace Zadaca1RPR_17324
{
   public class Pacijent_NormalnaProcedura:Pacijent
    {
        public Pacijent_NormalnaProcedura(UInt64 MaticniBroj, string ime, string prezime, DateTime datumRodjenja, char spol, string adresaStanovanja, string bracnoStanje, DateTime datumPrijema) : base(MaticniBroj, ime, prezime, datumRodjenja, spol, adresaStanovanja, bracnoStanje, datumPrijema)
        {
            GenerisiIDPacijenta();
        }
        public Pacijent_NormalnaProcedura()
        {
            GenerisiIDPacijenta();
        }
    }
}
