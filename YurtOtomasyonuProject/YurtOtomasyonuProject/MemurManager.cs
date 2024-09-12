using System;
using Npgsql;
using System.Collections.Generic;

namespace YurtOtomasyonuProject
{
    public class MemurManager
    {
        private Database db;

        public MemurManager(Database database)
        {
            db = database;
        }

        public void MemurEkle(Memur memur)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("INSERT INTO memurlar (tckimlikno, adsoyad, pozisyon, maas, telefonno, adres) VALUES (@tckimlikno, @adsoyad, @pozisyon, @maas, @telefonno, @adres)", conn);
                cmd.Parameters.AddWithValue("tckimlikno", memur.TcKimlikNo);
                cmd.Parameters.AddWithValue("adsoyad", memur.AdSoyad);
                cmd.Parameters.AddWithValue("pozisyon", memur.Pozisyon);
                cmd.Parameters.AddWithValue("maas", memur.Maas);
                cmd.Parameters.AddWithValue("telefonno", memur.TelefonNo);
                cmd.Parameters.AddWithValue("adres", memur.Adres);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Memur> MemurListele()
        {
            List<Memur> memurlar = new List<Memur>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM memurlar", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Memur memur = new Memur
                    {
                        TcKimlikNo = reader.GetString(0),
                        AdSoyad = reader.GetString(1),
                        Pozisyon = reader.GetString(2),
                        Maas = reader.GetDecimal(3),
                        TelefonNo = reader.GetString(4),
                        Adres = reader.GetString(5)
                    };
                    memurlar.Add(memur);
                }
            }
            return memurlar;
        }

        public void MemurSil(string tcKimlikNo)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM memurlar WHERE tckimlikno = @tckimlikno", conn);
                cmd.Parameters.AddWithValue("tckimlikno", tcKimlikNo);
                cmd.ExecuteNonQuery();
            }
        }

        public void MemurGuncelle(Memur memur)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("UPDATE memurlar SET adsoyad = @adsoyad, pozisyon = @pozisyon, maas = @maas, telefonno = @telefonno, adres = @adres WHERE tckimlikno = @tckimlikno", conn);
                cmd.Parameters.AddWithValue("adsoyad", memur.AdSoyad);
                cmd.Parameters.AddWithValue("pozisyon", memur.Pozisyon);
                cmd.Parameters.AddWithValue("maas", memur.Maas);
                cmd.Parameters.AddWithValue("telefonno", memur.TelefonNo);
                cmd.Parameters.AddWithValue("adres", memur.Adres);
                cmd.Parameters.AddWithValue("tckimlikno", memur.TcKimlikNo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}


