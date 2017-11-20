using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doktori
{
   public class Uposlenik
    {
        string imeUposlenika;
        string prezimeUposlenika;
        int brojLicence;
        public Uposlenik()
        {
            ImeUposlenika = "Dietrich";
            PrezimeUposlenika = "Uposlenicic";
            BrojLicence = 0;
        }
        public Uposlenik(string imeUposlenika, string prezimeUposlenika, int brojLicence)
        {
            this.ImeUposlenika = imeUposlenika;
            this.PrezimeUposlenika = prezimeUposlenika;
            this.BrojLicence = brojLicence;
        }

        public string ImeUposlenika { get => imeUposlenika; set => imeUposlenika = value; }
        public string PrezimeUposlenika { get => prezimeUposlenika; set => prezimeUposlenika = value; }
        public int BrojLicence { get => brojLicence; set => brojLicence = value; }
    }
}
