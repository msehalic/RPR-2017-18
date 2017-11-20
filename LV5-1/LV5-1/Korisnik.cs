using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace LV5_1
{
    class Korisnik
    {
        private string ime { get; set; }
        private string prezime { get; set; }
        private bool muskarac { get; set; }
        private string grad { get; set; }
        private string telefon { get; set; }
        private DateTime datumRodjenja { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private bool admin { get; set; }
        private bool moderator { get; set; }
        private Image slikaKorisnika;
        public Korisnik(string ime, string prezime, bool muskarac, string grad, string telefon, DateTime datumRodjenja, string username, string password, Image slikaKorisnika, bool admin, bool moderator)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.muskarac = muskarac;
            this.grad = grad;
            this.telefon = telefon;
            this.datumRodjenja = datumRodjenja;
            this.username = username;
            this.password = password;
            this.slikaKorisnika = slikaKorisnika;
            this.admin = admin;
            this.moderator = moderator;
        }
    }
}
