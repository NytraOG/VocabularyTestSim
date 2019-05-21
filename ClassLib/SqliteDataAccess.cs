using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ClassLib
{
    public class SqliteDataAccess
    {
        public static List<VokabelModel> LadeVokabeln()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<VokabelModel>("select * from Vokabel", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void LöscheVokabeln(IList<VokabelModel> ausgewählteVokabeln)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                foreach (var vokabel in ausgewählteVokabeln)
                {
                    cnn.Execute($"delete from Vokabel where Infinitiv = '{vokabel.Infinitiv}'");
                }
            }
        }

        public static void SpeichereVokabel(VokabelModel vokabel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Vokabel (Infinitiv, SimplePast, PastParticiple, Translation) values (@Infinitiv, @SimplePast, @PastParticiple, @Translation)",
                            vokabel);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
