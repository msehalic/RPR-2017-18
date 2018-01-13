using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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
    }
}
