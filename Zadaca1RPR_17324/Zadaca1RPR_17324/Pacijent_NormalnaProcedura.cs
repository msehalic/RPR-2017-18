using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    class Pacijent_NormalnaProcedura:Pacijent
    {
        public Pacijent_NormalnaProcedura(int MaticniBroj, string ime, string prezime, DateTime datumRodjenja, char spol, string adresaStanovanja, string bracnoStanje, DateTime datumPrijema) : base(MaticniBroj, ime, prezime, datumRodjenja, spol, adresaStanovanja, bracnoStanje, datumPrijema)
        {
            GenerisiIDPacijenta();
        }
        public Pacijent_NormalnaProcedura()
        {
            GenerisiIDPacijenta();
        }
        /*TREBA PRATITI U KALENDARU STA SE DESAVA I ALOCIRATI RASPORED, MORAT CEMO NACI NEKI PRIORITY QUEUE SHIT U C# 
        I ONU GLUPOST SA APARATIMA NEKAKO, NOTE TO SELF: NEMOJ KORISTITI LISTE!
        URADI ANAMNEZU PACIJENTU KAD BUDES PRAVIO KARTON (OPCIJA POD 3 ZAVISI OD TOGA), HM MOZDA BI SE MOGLA
        IMPLEMENTIRATI NEKAKO U ONOJ LISTI PREGLEDA*/

        //TREBA I OBDUKCIJU ZAKAZATI AKO NAM PRESELI PACIJENT NA AHIRET
        //TODO, TREBA SAMO POKUPITI SVE IZ BAZNOG JER JE STANDARDNI POSTUPAK, PRIPAZITI NA ONAJ WEIRD HITNI PROCEDURE :)
    }
}
