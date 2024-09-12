using System;
using Npgsql;
using System.Collections.Generic;

namespace YurtOtomasyonuProject
{
    public class OdemeManager
    {
        private Database db;

        public OdemeManager(Database database)
        {
            db = database;
        }

        public void OdemeEkle(Odeme odeme)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO odemeler (odemetarihi, tckimlikno, faturatutar) VALUES (@odemetarihi, @tckimlikno, @faturatutar)", conn);
                cmd.Parameters.AddWithValue("odemetarihi", odeme.OdemeTarihi);
                cmd.Parameters.AddWithValue("tckimlikno", odeme.TcKimlikNo);
                cmd.Parameters.AddWithValue("faturatutar", odeme.FaturaTutar);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Odeme> OdemeListele()
        {
            List<Odeme> odemeler = new List<Odeme>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM odemeler", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Odeme odeme = new Odeme
                    {
                        FaturaNo = reader.GetInt32(0),
                        OdemeTarihi = reader.GetDateTime(1), // Tarih ve saat burada doğrudan alınır
                        TcKimlikNo = reader.GetString(2),
                        FaturaTutar = reader.GetDecimal(3)
                    };
                    odemeler.Add(odeme);
                }
            }
            return odemeler;
        }

        public void OdemeSil(int faturaNo)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM odemeler WHERE faturano = @faturano", conn);
                cmd.Parameters.AddWithValue("faturano", faturaNo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}


