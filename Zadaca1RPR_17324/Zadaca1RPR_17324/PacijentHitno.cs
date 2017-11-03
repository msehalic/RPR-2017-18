using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1RPR_17324
{
    class PacijentHitno : Pacijent
    {
        bool PacijentZiv { get; set; }
        public PacijentHitno() //: base(MaticniBroj, ime, prezime, datumRodjenja, spol, adresaStanovanja, bracnoStanje, datumPrijema)
        {
            PacijentZiv = true;
        }
        public string EvidentirajPrvuPomoc()
        {
            string vrijemeSmrti, razlogSmrti, postupak;
            char prezivio;
            Console.WriteLine("Kojem postupku je podvrgnut pacijent?");
            postupak = Console.ReadLine();
            //i ovdje nekako u karton zgurati
            Console.WriteLine("Pacijent je ziv (D/N)?");
            prezivio = Convert.ToChar(Console.ReadLine());
            PacijentZiv = (prezivio == 'D');
            if (PacijentZiv) return ("Uspjesno obavljen postupak" + postupak);
            else
            {
                Console.Write("Unesite vrijeme smrti: ");
                vrijemeSmrti = Console.ReadLine();
                Console.Write("\nUnesite razlog smrti: ");
                razlogSmrti = Console.ReadLine();
                //treba ovo zapisati negdje, mozda neka klasa pregleda pa u listu da se zapisuju pregledi i komentari tj. karton pacijenta
                return ("Pacijent je nazalost preminuo u" + vrijemeSmrti + "zbog" + razlogSmrti);
            }
        }
        //AKO PACIJENT UMRE TREBALI BISMO MU OTKAZATI I PREGLEDE
        void OtkaziPreglede(List<Pacijent> pacijenti)
        {

        }
    }
}
