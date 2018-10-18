using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class StraniStudent:Student
    {
        string brojVize;

        public StraniStudent(string imeStudenta, string prezimeStudenta, long id, DateTime datumRodjenja, string mjestoRodjenja, string brojVize) : base(imeStudenta, prezimeStudenta, id, datumRodjenja, mjestoRodjenja)
        {
            BrojVize = imeStudenta.ElementAt(1) + prezimeStudenta.ElementAt(1) + datumRodjenja.Date.ToString(); //inicijali + datum rodjenja
        }

        public string BrojVize
        {
            get
            {
                return brojVize;
            }

            set
            {
                brojVize = value;
            }
        }
    }
}
