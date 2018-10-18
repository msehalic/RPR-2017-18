using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class Predmet
    {
        string nazivPredmeta;
        string nazivProfesora;
        Int64 brojPredavanja;
        Int64 brojVjezbi;
        Int64 brojTutorijala;
        Int64 brojECTS;

        public string NazivPredmeta
        {
            get
            {
                return nazivPredmeta;
            }

            set
            {
                nazivPredmeta = value;
            }
        }

        public string NazivProfesora
        {
            get
            {
                return nazivProfesora;
            }

            set
            {
                nazivProfesora = value;
            }
        }

        public long BrojPredavanja
        {
            get
            {
                return brojPredavanja;
            }

            set
            {
                brojPredavanja = value;
            }
        }

        public long BrojVjezbi
        {
            get
            {
                return brojVjezbi;
            }

            set
            {
                brojVjezbi = value;
            }
        }

        public long BrojTutorijala
        {
            get
            {
                return brojTutorijala;
            }

            set
            {
                brojTutorijala = value;
            }
        }

        public long BrojECTS
        {
            get
            {
                return brojECTS;
            }

            set
            {
                brojECTS = value;
            }
        }

        public Predmet(string nazivPredmeta, string nazivProfesora, long brojPredavanja, long brojVjezbi, long brojTutorijala, long brojECTS)
        {
            this.NazivPredmeta = nazivPredmeta;
            this.NazivProfesora = nazivProfesora;
            this.BrojPredavanja = brojPredavanja;
            this.BrojVjezbi = brojVjezbi;
            this.BrojTutorijala = brojTutorijala;
            this.BrojECTS = brojECTS;
        }
    }
}
