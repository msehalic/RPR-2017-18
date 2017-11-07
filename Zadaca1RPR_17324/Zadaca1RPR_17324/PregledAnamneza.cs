using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    sealed partial class PregledAnamneza //razdvojeno da se ne gomilaju varijable
    {
        public string opisTegobaBolesnika;
        //opceniti problemi
        public bool imaSrcaneProbleme { get; set;}
        public bool imaKostaneProbleme { get; set; }
        public bool imaNervneProbleme { get; set; }
        public bool imaEndokrineProbleme { get; set; }
        public bool imaSlusneProbleme { get; set; }
        public bool imaOcneProbleme { get; set; }
        public bool imaKozneProbleme { get; set; }
        public bool imaDisajneProbleme { get; set; }
        public bool imaPlasticneProbleme { get; set; }
        public bool imaKrvneProbleme { get; set; }
        public bool imaZubneProbleme { get; set; }
        public bool imaAlergije { get; set; }
        //vakcinisanje
        public bool primioTetanus { get; set; }
        public bool primioRubeolu { get; set; }
        public bool primioGripu { get; set; }
        public bool primioHepatitis { get; set; }
        public bool primioBCG { get; set; }
        //operacije
        public string prijasnjeOperacije;
        //opceniti simptomi
        public bool malaksalost { get; set; }
        public bool nesanica { get; set; }
        public bool temperatura { get; set; }
        public bool znojenje { get; set; }
        public bool kasalj { get; set; }
        public bool vrtoglavica { get; set; }
        public bool povracanje { get; set; }
        //navike
        public bool pusac { get; set; }
        public int brojCigareta { get; set; }
        public bool alkoholicar { get; set; }
        public bool opojneDroge { get; set; }
        //porodica
        public bool slucajVisokogPritiska { get; set; }
        public bool secernaBolest { get; set; }
        public bool karcinomi { get; set; }
        public bool hemofilija { get; set; }
        public bool psihickiProblemi { get; set; }
    }
}
