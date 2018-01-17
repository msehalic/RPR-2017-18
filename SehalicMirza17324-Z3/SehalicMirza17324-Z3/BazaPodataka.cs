﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehalicMirza17324_Z2
{
    public class BazaPodataka
    {
        OracleConnection spajanjeSaBazom;
        Zadaca1RPR_17324.KlinikaKontejner klinika17324 = new Zadaca1RPR_17324.KlinikaKontejner();

        public BazaPodataka()
        {
        }

        public void UspostaviKonekciju()
        {
            spajanjeSaBazom = new OracleConnection
            {
                ConnectionString = @"Data Source=
 (DESCRIPTION =
 (ADDRESS = (PROTOCOL = TCP)(HOST = 80.65.65.66)(PORT = 1521))
 (CONNECT_DATA =
 (SERVER = DEDICATED)
 (SERVICE_NAME = etflab.db.lab.etf.unsa.ba)
 )
 );User Id= MS17324;Password= Bhc3fOl1;Persist Security Info=True;"
            };
            spajanjeSaBazom.Open();

        }
        public void DiskonektujSe() => spajanjeSaBazom.Close();

        public void UcitajUposlenike()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Uposlenik u, Administrator a WHERE u.brojLicence = a.brojLicence";
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                klinika17324.Uposlenici.Clear();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Image Slika;
                    byte[] Bajtovi = row["slikaUposlenika"] as byte[];
                    if (Bajtovi == null)
                    {
                        Slika = null;
                    }
                    else
                    {
                        using (var stream = new MemoryStream(Bajtovi))
                        {
                            Bitmap bmp = new Bitmap(stream);
                            Slika = bmp;
                        }
                    }
                    klinika17324.Uposlenici.Add(new Doktori.Administrator(row["imeUposlenika"].ToString(), row["prezimeUposlenika"].ToString(),
                       Slika, Convert.ToInt32(row["brojLicence"]), row["korisnickoIme"].ToString(), row["lozinka"].ToString()));
                    klinika17324.Uposlenici.Last().Lozinka = row["lozinka"].ToString();
                    klinika17324.Uposlenici.Last().BrojLicence = Int32.Parse(row["brojLicence"].ToString());
                }
            }
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Uposlenik u, Tehnicar t WHERE u.brojLicence = t.brojLicence";
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                klinika17324.Uposlenici.Clear();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Image Slika;
                    byte[] Bajtovi = row["slikaUposlenika"] as byte[];
                    if (Bajtovi == null)
                    {
                        Slika = null;
                    }
                    else
                    {
                        using (var stream = new MemoryStream(Bajtovi))
                        {
                            Bitmap bmp = new Bitmap(stream);
                            Slika = bmp;
                        }
                    }
                    klinika17324.Uposlenici.Add(new Doktori.Tehnicar(row["imeUposlenika"].ToString(), row["prezimeUposlenika"].ToString(),
                       Slika, Convert.ToInt32(row["brojLicence"]), row["korisnickoIme"].ToString(), row["lozinka"].ToString()));
                    klinika17324.Uposlenici.Last().Lozinka = row["lozinka"].ToString();
                    klinika17324.Uposlenici.Last().BrojLicence = Int32.Parse(row["brojLicence"].ToString());
                }
            }


            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Uposlenik u, Doktor d WHERE u.brojLicence = d.brojLicence";
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                klinika17324.Uposlenici.Clear();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Image Slika;
                    byte[] Bajtovi = row["slikaUposlenika"] as byte[];
                    if (Bajtovi == null)
                    {
                        Slika = null;
                    }
                    else
                    {
                        using (var stream = new MemoryStream(Bajtovi))
                        {
                            Bitmap bmp = new Bitmap(stream);
                            Slika = bmp;
                        }
                    }
                    klinika17324.Uposlenici.Add(new Doktori.Doktor(row["imeUposlenika"].ToString(), row["prezimeUposlenika"].ToString(),
                       Slika, Convert.ToInt32(row["brojLicence"]), row["korisnickoIme"].ToString(), row["lozinka"].ToString(), Convert.ToInt32(row["brojPregledanihPacijenata"]), row["specijalizacija"].ToString()));
                    klinika17324.Uposlenici.Last().Lozinka = row["lozinka"].ToString();
                    klinika17324.Uposlenici.Last().BrojLicence = Int32.Parse(row["brojLicence"].ToString());
                }
            }

        }
        public void UcitajPacijente()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Pacijent";
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                klinika17324.Pacijenti.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    DateTime datumRodjenja = Convert.ToDateTime(row["datumRodjenja"].ToString());

                    Image slikaPacijenta;
                    byte[] Bajtovi = row["slikaPacijenta"] as byte[];
                    if (Bajtovi == null)
                    {
                        slikaPacijenta = null;
                    }
                    else
                    {
                        using (var stream = new MemoryStream(Bajtovi))
                        {
                            Bitmap bmp = new Bitmap(stream);
                            slikaPacijenta = bmp;
                        }
                    }
                    klinika17324.Pacijenti.Add(new Zadaca1RPR_17324.Pacijent(row["korisnickoIme"].ToString(), row["lozinka"].ToString(), row["ime"].ToString(), row["prezime"].ToString(),
                        row["adresaStanovanja"].ToString(), row["bracnoStanje"].ToString(), datumRodjenja, Convert.ToChar(row["spol"]), Convert.ToUInt64(row["maticniBroj"]),slikaPacijenta));
                    klinika17324.Pacijenti.Last().KorisnickoIme = row["korisnickoIme"].ToString();
                    klinika17324.Pacijenti.Last().Lozinka = row["lozinka"].ToString();
                }

            }
        }
        public void SacuvajUposlenike()
        {
            //admin
            foreach (Doktori.Administrator a in klinika17324.Uposlenici)
            {
                using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
                {
                    string sqlInsert = String.Format("insert into Administrator (brojLicence, imeUposlenika, prezimeUposlenika, slikaUposlenika, korisnickoIme, lozinka) values " +
                        "({0}, '{1}', {2}, {3}, {4}, {5})", a.BrojLicence, a.ImeUposlenika, a.PrezimeUposlenika, a.SlikaUposlenika, a.KorisnickoIme, a.Lozinka);
                    cmd.CommandText = sqlInsert;
                    cmd.ExecuteNonQuery();
                }
            }
            //tehnicari
            foreach (Doktori.Tehnicar t in klinika17324.Uposlenici)
            {
                using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
                {
                    string sqlInsert = String.Format("insert into Tehnicar (brojLicence, imeUposlenika, prezimeUposlenika, slikaUposlenika, korisnickoIme, lozinka) values " +
                        "({0}, '{1}', {2}, {3}, {4}, {5})", t.BrojLicence, t.ImeUposlenika, t.PrezimeUposlenika, t.SlikaUposlenika, t.KorisnickoIme, t.Lozinka);
                    cmd.CommandText = sqlInsert;
                    cmd.ExecuteNonQuery();
                }
            }
            //doktori
            foreach (Doktori.Doktor d in klinika17324.Uposlenici)
            {
                using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
                {
                    string sqlInsert = String.Format("insert into Doktor (brojLicence, imeUposlenika, prezimeUposlenika, slikaUposlenika, korisnickoIme, lozinka, brojPregledanihPacijenata, specijalizacija) values " +
                        "({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7})", d.BrojLicence, d.ImeUposlenika, d.PrezimeUposlenika, d.SlikaZaBazu, d.KorisnickoIme, d.Lozinka, d.BrojPregledanihPacijenata.ToString(), d.Specijalizacija);
                    cmd.CommandText = sqlInsert;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SacuvajPacijente()
        {
            foreach (Zadaca1RPR_17324.Pacijent p in klinika17324.Pacijenti)
            {
                using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
                {
                    string sqlInsert = String.Format("insert into Pacijent (korisnickoIme, lozinka, ime, prezime, adresaStanovanja, bracnoStanje, datumRodjenja, spol, maticniBroj, slikaPacijenta) values " +
                        "({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})", p.KorisnickoIme, p.Lozinka, p.Ime, p.Prezime, p.AdresaStanovanja, p.BracnoStanje, p.DatumRodjenja, p.Spol, p.MaticniBroj, p.SlikaZaBazu);
                    cmd.CommandText = sqlInsert;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ObrisiDoktore()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from DOKTOR";
                cmd.ExecuteNonQuery();
            }
        }
        public void ObrisiTehnicare()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from TEHNICAR";
                cmd.ExecuteNonQuery();
            }
        }
        public void ObrisiAdministratore()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from ADMINISTRATOR";
                cmd.ExecuteNonQuery();
            }
        }
        public void ObrisiPreglede()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from PREGLED";
                cmd.ExecuteNonQuery();
            }
        }
        public void ObrisiSveUposlenike()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from ADMINISTRATOR";
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from DOKTOR";
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from TEHNICAR";
                cmd.ExecuteNonQuery();
            }
        }
        public void ObrisiSvePacijente()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from PACIJENT";
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from PACIJENT_NORMALNAPROCEDURA";
                cmd.ExecuteNonQuery();
            }
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from PACIJENT_HITNAPROCEDURA";
                cmd.ExecuteNonQuery();
            }
        }
        public void ObrisiOrdinacije()
        {
            using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
            {
                cmd.CommandText = "delete from ORDINACIJA";
                cmd.ExecuteNonQuery();
            }
        }
        public void ObrisiSve()
        {
            List<string> listaKomandi = new List<string>
            {
                "delete from DOKTOR",
                "delete from TEHNICAR",
                "delete from ORDINACIJA",
                "delete from ADMINISTRATOR",
                "delete from UPOSLENIK",
                "delete from PREGLED",
                "delete from PACIJENT",
                "delete from PACIJENT_NORMALNAPROCEDURA",
                "delete from PACIJENT_HITNAPROCEDURA"
            };
            foreach (string s in listaKomandi)
            {
                using (OracleCommand cmd = spajanjeSaBazom.CreateCommand())
                {
                    cmd.CommandText = s;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}