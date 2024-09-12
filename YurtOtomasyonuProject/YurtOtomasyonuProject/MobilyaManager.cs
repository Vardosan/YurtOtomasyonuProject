using System;
using Npgsql;
using System.Collections.Generic;

namespace YurtOtomasyonuProject
{
    public class MobilyaManager
    {
        private Database db;

        public MobilyaManager(Database database)
        {
            db = database;
        }

        public void MobilyaEkle(Mobilya mobilya)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO mobilyalar (mobilyakodu, odano, tckimlikno) VALUES (@mobilyakodu, @odano, @tckimlikno)", conn);
                cmd.Parameters.AddWithValue("mobilyakodu", mobilya.MobilyaKodu);
                cmd.Parameters.AddWithValue("odano", mobilya.OdaNo);
                cmd.Parameters.AddWithValue("tckimlikno", mobilya.TcKimlikNo);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Mobilya> MobilyaListele()
        {
            List<Mobilya> mobilyalar = new List<Mobilya>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM mobilyalar", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mobilya mobilya = new Mobilya
                    {
                        MobilyaKodu = reader.GetInt32(0),
                        OdaNo = reader.GetInt32(1),
                        TcKimlikNo = reader.GetString(2)
                    };
                    mobilyalar.Add(mobilya);
                }
            }
            return mobilyalar;
        }

        public void MobilyaSil(int mobilyaKodu)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM mobilyalar WHERE mobilyakodu = @mobilyakodu", conn);
                cmd.Parameters.AddWithValue("mobilyakodu", mobilyaKodu);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

