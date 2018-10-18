using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class Student
    {
        static Int64 globalID; //globalni brojac indeksa

        string imeStudenta;
        string prezimeStudenta;
        long id;
        DateTime datumRodjenja;
        string mjestoRodjenja;

        public Student(string imeStudenta, string prezimeStudenta, long id, DateTime datumRodjenja, string mjestoRodjenja)
        {
            ImeStudenta = imeStudenta;
            PrezimeStudenta = prezimeStudenta;
            id = globalID + 1;
            globalID += 1;
            DatumRodjenja = datumRodjenja;
            MjestoRodjenja = mjestoRodjenja;
        }

        public string ImeStudenta
        {
            get
            {
                return imeStudenta;
            }

            set
            {
                imeStudenta = value;
            }
        }

        public string PrezimeStudenta
        {
            get
            {
                return prezimeStudenta;
            }

            set
            {
                prezimeStudenta = value;
            }
        }

        public long Id
        {
            get
            {
                return id;
            }

           //NECEMO SET DA NAM NEKO MIJENJA ID JER NEMA SMISLA
        }

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }

            set
            {
                datumRodjenja = value;
            }
        }

        public string MjestoRodjenja
        {
            get
            {
                return mjestoRodjenja;
            }

            set
            {
                mjestoRodjenja = value;
            }
        }
    }
}
