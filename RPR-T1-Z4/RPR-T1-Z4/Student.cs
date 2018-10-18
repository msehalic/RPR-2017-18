using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPR_T1_Z4
{
    class Student
    {
        private string ime, prezime;
        private int brIndexa;

        public Student(string ime, string prezime, int brIndexa)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.BrIndexa = brIndexa;
        }

        public int BrIndexa { get => brIndexa; set => brIndexa = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public override string ToString()
        {
            return Prezime + " " + Ime + " (" + BrIndexa + ")";
        }
    }
}
