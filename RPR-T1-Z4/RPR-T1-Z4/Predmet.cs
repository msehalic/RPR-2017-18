using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPR_T1_Z4
{
    class Predmet
    {
        private Student[] nizStudenta=new Student[MaxBrojStudenata];
        string nazivPredmeta, sifraPredmeta;
        static int maxBrojStudenata=10;

        public Predmet(string nazivPredmeta, string sifraPredmeta, int maxBroj)
        {
            NazivPredmeta = nazivPredmeta;
            SifraPredmeta = sifraPredmeta;
            maxBrojStudenata = maxBroj;
        }

        public Predmet()
        {
            NazivPredmeta = "NESTO";
            SifraPredmeta = "123";
            maxBrojStudenata = 10;
        }

        public string NazivPredmeta { get => nazivPredmeta; set => nazivPredmeta = value; }
        public string SifraPredmeta { get => sifraPredmeta; set => sifraPredmeta = value; }
        public static int MaxBrojStudenata { get => maxBrojStudenata;} //ne smijes dozvoliti promjenu

       public void upisi (ref Student s)
        {
            nizStudenta[nizStudenta.Length - 1] = s;
            Array.Resize(ref nizStudenta, nizStudenta.Length);
        }
        public void ispisi (ref Student s)
        {
            int index = Array.IndexOf(nizStudenta, s);
            for (int a = index; a < nizStudenta.Length - 1; a++)
            {
                nizStudenta[a] = nizStudenta[a + 1];
            }
            Array.Resize(ref nizStudenta, nizStudenta.Length - 1);
        }

    }
}
