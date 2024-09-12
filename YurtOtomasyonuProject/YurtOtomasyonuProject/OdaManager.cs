using System;
using Npgsql;
using System.Collections.Generic;

namespace YurtOtomasyonuProject
{
    public class OdaManager
    {
        private Database db;

        public OdaManager(Database database)
        {
            db = database;
        }

        public void OdaEkle(Oda oda)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO odalar (yataksayisi, odatipi, katno) VALUES (@yataksayisi, @odatipi, @katno)", conn);
                cmd.Parameters.AddWithValue("yataksayisi", oda.YatakSayisi);
                cmd.Parameters.AddWithValue("odatipi", oda.OdaTipi);
                cmd.Parameters.AddWithValue("katno", oda.KatNo);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Oda> OdaListele()
        {
            List<Oda> odalar = new List<Oda>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM odalar", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Oda oda = new Oda
                    {
                        OdaNo = reader.GetInt32(0),
                        YatakSayisi = reader.GetInt32(1),
                        OdaTipi = reader.GetString(2),
                        KatNo = reader.GetInt32(3)
                    };
                    odalar.Add(oda);
                }
            }
            return odalar;
        }

        public void OdaSil(int odaNo)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM odalar WHERE odano = @odano", conn);
                cmd.Parameters.AddWithValue("odano", odaNo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

