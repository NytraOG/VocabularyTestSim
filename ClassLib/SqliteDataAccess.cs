﻿using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using ClassLib.Models;
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

        public static void SpeichereAntwort(AntwortenModel antwort, string testrunOid)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute($"insert into Antwort (Infinitiv, SimplePast, PastParticiple, Translation, TestRun_Oid) " +
                                   $"values ({antwort.Infinitiv}, {antwort.SimplePastEingabe}), {antwort.PastParticipleEingabe}, {antwort.ÜbersetzungEingabe}, {testrunOid}");
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
