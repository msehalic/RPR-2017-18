﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doktori
{
    class Tehnicar : Uposlenik
    {
        //cisto da postoji funkcionalnost
        public Tehnicar()
        {
        }

        public Tehnicar(string imeUposlenika, string prezimeUposlenika, int brojLicence) : base(imeUposlenika, prezimeUposlenika, brojLicence)
        {
        }
    }
}