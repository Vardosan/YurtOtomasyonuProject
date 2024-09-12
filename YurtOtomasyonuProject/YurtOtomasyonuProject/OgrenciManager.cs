using System;
using Npgsql;
using System.Collections.Generic;
using YurtOtomasyonuProject;

namespace YurtOtomasyonuProject
{
    public class OgrenciManager
    {
        private Database db;

        public OgrenciManager(Database database)
        {
            db = database;
        }

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand(@"INSERT INTO ogrenciler 
                (tckimlikno, adsoyad, dogumtarihi, cinsiyet, telefonno, parmakizi, adres, ogrenimdurumu, odano) 
                VALUES 
                (@tckimlikno, @adsoyad, @dogumtarihi, @cinsiyet, @telefonno, @parmakizi, @adres, @ogrenimdurumu, @odano)", conn);

                cmd.Parameters.AddWithValue("tckimlikno", ogrenci.TcKimlikNo);
                cmd.Parameters.AddWithValue("adsoyad", ogrenci.AdSoyad);
                cmd.Parameters.AddWithValue("dogumtarihi", ogrenci.DogumTarihi);
                cmd.Parameters.AddWithValue("cinsiyet", ogrenci.Cinsiyet);
                cmd.Parameters.AddWithValue("telefonno", ogrenci.TelefonNo);
                cmd.Parameters.AddWithValue("parmakizi", ogrenci.Parmakizi);
                cmd.Parameters.AddWithValue("adres", ogrenci.Adres);
                cmd.Parameters.AddWithValue("ogrenimdurumu", ogrenci.OgrenimDurumu);
                cmd.Parameters.AddWithValue("odano", ogrenci.OdaNo);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Ogrenci> OgrenciListele()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM ogrenciler", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ogrenci ogrenci = new Ogrenci
                    {
                        TcKimlikNo = reader.GetString(0),
                        AdSoyad = reader.GetString(1),
                        DogumTarihi = reader.GetDateTime(2),
                        Cinsiyet = reader.GetString(3),
                        TelefonNo = reader.GetString(4),
                        Parmakizi = reader.GetString(5),
                        Adres = reader.GetString(6),
                        OgrenimDurumu = reader.GetString(7),
                        OdaNo = reader.GetInt32(8)
                    };
                    ogrenciler.Add(ogrenci);
                }
            }
            return ogrenciler;
        }

        public void OgrenciSil(string tcKimlikNo)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM ogrenciler WHERE tckimlikno = @tckimlikno", conn);
                cmd.Parameters.AddWithValue("tckimlikno", tcKimlikNo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

