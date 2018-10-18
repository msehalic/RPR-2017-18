using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirzaSehalic17324
{
    class DomaciStudent : Student
    {
        public DomaciStudent(string imeStudenta, string prezimeStudenta, long id, DateTime datumRodjenja, string mjestoRodjenja) : base(imeStudenta, prezimeStudenta, id, datumRodjenja, mjestoRodjenja)
        {
        }
    }
}
