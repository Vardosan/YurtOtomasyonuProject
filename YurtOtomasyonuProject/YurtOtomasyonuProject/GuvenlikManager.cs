using System;
using Npgsql;
using System.Collections.Generic;

namespace YurtOtomasyonuProject
{
    public class GuvenlikManager
    {
        private Database db;

        public GuvenlikManager(Database database)
        {
            db = database;
        }

        public void GuvenlikEkle(Guvenlik guvenlik)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO guvenlikler (tckimlikno, adsoyad, pozisyon, maas, telefonno, adres) VALUES (@tckimlikno, @adsoyad, @pozisyon, @maas, @telefonno, @adres)", conn);
                cmd.Parameters.AddWithValue("tckimlikno", guvenlik.TcKimlikNo);
                cmd.Parameters.AddWithValue("adsoyad", guvenlik.AdSoyad);
                cmd.Parameters.AddWithValue("pozisyon", guvenlik.Pozisyon);
                cmd.Parameters.AddWithValue("maas", guvenlik.Maas);
                cmd.Parameters.AddWithValue("telefonno", guvenlik.TelefonNo);
                cmd.Parameters.AddWithValue("adres", guvenlik.Adres);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Guvenlik> GuvenlikListele()
        {
            List<Guvenlik> guvenlikler = new List<Guvenlik>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM guvenlikler", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Guvenlik guvenlik = new Guvenlik
                    {
                        TcKimlikNo = reader.GetString(0),
                        AdSoyad = reader.GetString(1),
                        Pozisyon = reader.GetString(2),
                        Maas = reader.GetDecimal(3),
                        TelefonNo = reader.GetString(4),
                        Adres = reader.GetString(5)
                    };
                    guvenlikler.Add(guvenlik);
                }
            }
            return guvenlikler;
        }

        public void GuvenlikSil(string tcKimlikNo)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM guvenlikler WHERE tckimlikno = @tckimlikno", conn);
                cmd.Parameters.AddWithValue("tckimlikno", tcKimlikNo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
