-- odalar Tablosu ve 10 adet satır
CREATE TABLE IF NOT EXISTS odalar (
    odano SERIAL PRIMARY KEY,
    yataksayisi INTEGER,
    odatipi VARCHAR(50),
    katno INTEGER
);

INSERT INTO odalar (yataksayisi,odatipi,katno)
VALUES
    (4, '4 Kişilik', 1),
    (4, '4 Kişilik', 2),
    (4, '4 Kişilik', 1),
    (6, '6 Kişilik', 3),
    (6, '6 Kişilik', 2),
    (6, '6 Kişilik', 1),
    (2, '2 Kişilik', 3),
    (2, '2 Kişilik', 2),
    (3, '3 Kişilik', 1),
    (3, '3 Kişilik', 3);


-- Öğrenciler Tablosu ve 10 adet veri girişi
CREATE TYPE birinci_derece_yakinlar AS (
    adsoyad VARCHAR(50),
    telefonno VARCHAR(11),
    adres TEXT
);
CREATE TABLE IF NOT EXISTS ogrenciler (
    tckimlikno VARCHAR(11) PRIMARY KEY,
    adsoyad VARCHAR(100),
    dogumtarihi DATE,
    cinsiyet VARCHAR(10),
    telefonno VARCHAR(11),
    parmakizi VARCHAR(10), -- Normal şartlarda BYTEA olması gerekir
    adres TEXT,
    ogrenimdurumu VARCHAR(50),
    odano int REFERENCES odalar (odano),
    birinci_derece_yakinlar birinci_derece_yakinlar
);

INSERT INTO ogrenciler
VALUES
    ('99000000001','Ahmet Yılmaz','1995-05-10','Erkek','05364753641', 'F1A2C3E4D5','İstanbul','Lisans',1,(('Ayşe Yılmaz','05439872536','İstanbul'))),
    ('99000000002','Murat Coşgun','1998-08-25','Erkek','05413584411', 'B7D8F9H0J1','İzmir','Yüksek Lisans',2,(('Ahmet Coşgun','05368123641','İzmir'))),
    ('99000000003','Emre Kaya','1997-03-15','Erkek','05398513411', 'K2L3M4N5O6','Ankara','Doktora',3,(('Zeynep Kaya','05386214785','Ankara'))),
    ('99000000004','Burak Yıldız','1996-11-30','Erkek','05384862254', 'P7Q8R9S0T1','Antalya','Lisans',4,(('Ahmet Yıldız','05419357805','Antalya'))),
    ('99000000005','Caner Çelik','1999-06-20','Erkek','05394799185', 'U2V3Y4Z5A6','Eskişehir','Yüksek Lisans',5,(('Aylin Çelik','05362156450','Eskişehir'))),
    ('99000000006','Onur Aksoy','1994-09-05','Erkek','05366312514', 'B1C2D3E4F5','İzmir','Doktora',6,(('Mustafa Aksoy','05379354269','İzmir'))),
    ('99000000007','Serkan Arslan','1997-12-12','Erkek','05413974785', 'G6H7I8J9K0','Ankara','Lisans',7,(('Emine Arslan','05379251441','Ankara'))),
    ('99000000008','Kaan Güneş','1998-04-03','Erkek','05432736478', 'L1M2N3O4P5','Bursa','Yüksek Lisans',8,(('Mehmet Güneş','05398612358','Bursa'))),
    ('99000000009','Oğuzhan Karadağ','1996-07-18','Erkek','05414856952', 'Q6R7S8T9U0','İstanbul','Doktora',9,(('Zehra Karadağ','05419846325','İstanbul'))),
    ('99000000010','Barış Aydın','1999-01-28','Erkek','05384923647', 'V1W2X3Y4Z5','İzmir','Lisans',10,(('Mert Aydın','05398213645','İzmir')));

-- memurlar Tablosu ve 10 adet veri girişi 
CREATE TABLE IF NOT EXISTS memurlar (
    tckimlikno VARCHAR(11) PRIMARY KEY,
    adsoyad VARCHAR(100),
    pozisyon VARCHAR(50),
    maas NUMERIC(10, 2),
    telefonno VARCHAR(11),
    adres TEXT
);

INSERT INTO memurlar
VALUES
    ('88000000001','Ahmet Demir','Yurt Müdürü',30000,'05551234567','Malatya'),
    ('88000000002','Ayşe Kaya','Yurt Müdür Yardımcısı',25000,'05329876543','Malatya'),
    ('88000000003','Mehmet Yılmaz','Yurt Müdür Yardımcısı',25000,'05412345678','Malatya'),
    ('88000000004','Fatma Demir','Yurt Memuru',20000,'05067890123','Malatya'),
    ('88000000005','Cemil Can','Yurt Memuru',20000,'05378901234','Malatya'),
    ('88000000006','Zehra Yıldırım','Yurt Memuru',20000,'05554567890','Malatya'),
    ('88000000007','Efe Arslan','Yurt Memuru',20000,'05323456789','Malatya'),
    ('88000000008','Selin Korkmaz','Yemekhane Sorumlusu',18000,'05056789012','Malatya'),
    ('88000000009','Caner Yılmaz','Sportif Faaliyetler Sorumlusu',17000,'05389012345','Malatya'),
    ('88000000010','Esra Öztürk','Sportif Faaliyetler Sorumlusu',17000,'05545678901','Malatya');

-- Güvenlikler Tablosu ve 10 adet veri girişi
CREATE TABLE IF NOT EXISTS guvenlikler (
    tckimlikno VARCHAR(11) PRIMARY KEY,
    adsoyad VARCHAR(100),
    pozisyon VARCHAR(50),
    maas NUMERIC(10, 2),
    telefonno VARCHAR(11),
    adres TEXT
);

INSERT INTO guvenlikler
VALUES
    ('77000000001','Cemal Demir','Güvenlik Görevlisi',18000,'05551234567','Malatya'),
    ('77000000002','Elif Yılmaz','Güvenlik Şefi',20000,'05329876543','Malatya'),
    ('77000000003','Engin Kaya','Güvenlik Görevlisi',14000,'05412345678','Malatya'),
    ('77000000004','Ayşe Yıldız','Güvenlik Kamerası Operatörü',14000,'05067890123','Malatya'),
    ('77000000005','Umut Çelik','Giriş Kontrol Görevlisi',14000,'05378901234','Malatya'),
    ('77000000006','Dilara Aksoy','Güvenlik Görevlisi',18000,'05554567890','Malatya'),
    ('77000000007','Baran Arslan','Güvenlik Danışmanı',20000,'05323456789','Malatya'),
    ('77000000008','Zehra Güneş','Güvenlik Görevlisi',18000,'05056789012','Malatya'),
    ('77000000009','Hüseyin Karadağ','Güvenlik Operasyon Sorumlusu',18000,'05389012345','Malatya'),
    ('77000000010','Seda Aydın','Güvenlik Ekip Lideri',25000,'05545678901','Malatya');


-- mobilyalar Tablosu ve 10 adet satır
CREATE TABLE IF NOT EXISTS mobilyalar (
    mobilyakodu SERIAL PRIMARY KEY,
    odano SERIAL REFERENCES odalar(odano),
    tckimlikno VARCHAR(11) REFERENCES ogrenciler(tckimlikno)
);

INSERT INTO mobilyalar (odano, tckimlikno)
VALUES
    (1, '99000000001'),
    (2, '99000000002'),
    (3, '99000000003'),
    (4, '99000000004'),
    (5, '99000000005'),
    (6, '99000000006'),
    (7, '99000000007'),
    (8, '99000000008'),
    (9, '99000000009'),
    (10, '99000000010');

-- Ödemeler tablosu ve 10 adet satır 
CREATE TABLE IF NOT EXISTS odemeler (
    faturano SERIAL PRIMARY KEY,
    odemetarihi TIMESTAMP,
    tckimlikno VARCHAR(11) REFERENCES ogrenciler(tckimlikno)
);

INSERT INTO odemeler (odemetarihi, tckimlikno)
VALUES 
    ('2023-01-15 14:30:00', '99000000001'),
    ('2023-02-20 09:45:00', '99000000002'),
    ('2023-03-25 17:15:00', '99000000003'),
    ('2023-04-10 11:00:00', '99000000004'),
    ('2023-05-05 08:20:00', '99000000005'),
    ('2023-06-12 16:40:00', '99000000006'),
    ('2023-07-19 13:10:00', '99000000007'),
    ('2023-08-03 10:55:00', '99000000008'),
    ('2023-09-28 19:25:00', '99000000009'),
    ('2023-10-15 15:50:00', '99000000010');


-- Yemek öğünleri tablosu ve 10 adet satır 
CREATE TABLE IF NOT EXISTS yemekogunleri (
    yemekid SERIAL PRIMARY KEY,
    verilidigigun DATE,
    tutar NUMERIC(10, 2),
    ogun VARCHAR(10),
    menu TEXT
);

INSERT INTO yemekogunleri (verilidigigun, tutar, ogun, menu)
VALUES 
    ('2023-01-15', 25.50, 'Sabah', 'Sebzeli Makarna, Salata, Ayran'),
    ('2023-02-20', 30.00, 'Akşam', 'Izgara Tavuk, Bulgur Pilavı, Cacık'),
    ('2023-03-25', 22.75, 'Sabah', 'Karnabahar Yemeği, Yoğurt'),
    ('2023-04-10', 28.20, 'Akşam', 'Hoşaf, Patates Püresi, Mevsim Salatası'),
    ('2023-05-05', 24.90, 'Sabah', 'Kuru Fasulye, Pilav, Turşu'),
    ('2023-06-12', 26.40, 'Akşam', 'Sebzeli Kuzu Güveç, Bulgur Pilavı, Cacık'),
    ('2023-07-19', 21.10, 'Sabah', 'Mantarlı Tavuk Sote, Roka Salatası'),
    ('2023-08-03', 27.55, 'Akşam', 'Karnabahar Köftesi, Mercimek Çorbası'),
    ('2023-09-28', 23.80, 'Sabah', 'Zeytinyağlı Pırasa, Yoğurtlu Semizotu'),
    ('2023-10-15', 29.25, 'Akşam', 'Kuzu Tandır, Bulgur Pilavı, Şekerpare Tatlısı');


-- Nöbet bölgeleri tablosu ve 10 adet saatır 
CREATE TABLE IF NOT EXISTS nobet_bolgeleri (
    bolgekodu VARCHAR(10) PRIMARY KEY,
    bolgeadi VARCHAR(50)
);

INSERT INTO nobet_bolgeleri (bolgekodu, bolgeadi)
VALUES 
    ('BOLGE01', 'Yurt Ana Girişi'),
    ('BOLGE02', 'Yurt Arka girişi');


-- Nöbetler tablosu ve 10 adet veri girişi
CREATE TABLE IF NOT EXISTS nobetler (
    nobetid SERIAL PRIMARY KEY,
    baslangicsaat TIMESTAMP,
    bitissaat TIMESTAMP,
    tckimlikno VARCHAR(11) REFERENCES guvenlikler(tckimlikno),
    bolgekodu VARCHAR(10) REFERENCES nobet_bolgeleri(bolgekodu)
);

INSERT INTO nobetler (baslangicsaat, bitissaat, tckimlikno, bolgekodu)
VALUES 
    ('2023-01-15 08:00:00', '2023-01-15 16:00:00', '77000000001', 'BOLGE01'),
    ('2023-02-20 22:00:00', '2023-02-21 06:00:00', '77000000002', 'BOLGE02'),
    ('2023-03-25 14:00:00', '2023-03-25 22:00:00', '77000000003', 'BOLGE02'),
    ('2023-04-10 18:00:00', '2023-04-11 02:00:00', '77000000004', 'BOLGE01'),
    ('2023-05-05 10:00:00', '2023-05-05 18:00:00', '77000000005', 'BOLGE01'),
    ('2023-06-12 20:00:00', '2023-06-13 04:00:00', '77000000006', 'BOLGE02'),
    ('2023-07-19 12:00:00', '2023-07-19 20:00:00', '77000000007', 'BOLGE02'),
    ('2023-08-03 16:00:00', '2023-08-04 00:00:00', '77000000008', 'BOLGE01'),
    ('2023-09-28 09:00:00', '2023-09-28 17:00:00', '77000000009', 'BOLGE01'),
    ('2023-10-15 22:00:00', '2023-10-16 06:00:00', '77000000010', 'BOLGE02');



-- olaylar tablosu ve 10 adet veri girişi
CREATE TABLE IF NOT EXISTS olaylar (
    olayid SERIAL PRIMARY KEY,
    olaytarihi TIMESTAMP,
    olayaciklamasi TEXT,
    olayyeri VARCHAR(100)
);

INSERT INTO olaylar (olaytarihi, olayaciklamasi, olayyeri)
VALUES 
    ('2023-01-15 13:45:00', 'İllegal Giriş Tespiti', 'Bina Girişi'),
    ('2023-02-20 21:30:00', 'Araç Güvenliği Kontrolü', 'Otopark Alanı'),
    ('2023-03-25 16:15:00', 'Yabancı Şahıs Tespiti', 'Lobi Alanı'),
    ('2023-04-10 10:00:00', 'Yangın Tatbikatı', 'Toplantı Salonu'),
    ('2023-05-05 08:45:00', 'Kayıp Eşya Teslimi', 'Resepsiyon'),
    ('2023-06-12 17:30:00', 'Şüpheli Paket Kontrolü', 'Posta Odası'),
    ('2023-07-19 14:20:00', 'Alarm Tetiklendi', 'Depo Alanı'),
    ('2023-08-03 11:10:00', 'İllegal Giriş Tespiti', 'Arka Giriş'),
    ('2023-09-28 18:00:00', 'Öğrenci Yardım İsteği', 'Kütüphane'),
    ('2023-10-15 15:00:00', 'Güvenlik Kamerası Arızası', 'Bina Geneli');



-- etkinlikler tablosu ve 10 adet veri girişi
CREATE TABLE IF NOT EXISTS etkinlikler (
    etkinlikid SERIAL PRIMARY KEY,
    etkinlikadi VARCHAR(100),
    etkinliktarihi DATE
);

INSERT INTO etkinlikler (etkinlikadi, etkinliktarihi)
VALUES 
    ('Kültür ve Sanat Günleri', '2023-01-15'),
    ('Spor Turnuvası', '2023-02-20'),
    ('Bilgi Teknolojileri Sempozyumu', '2023-03-25'),
    ('Öğrenci Meclisi Toplantısı', '2023-04-10'),
    ('Kariyer Geliştirme Semineri', '2023-05-05'),
    ('Çevre Temizliği Kampanyası', '2023-06-12'),
    ('Sağlık Haftası etkinlikleri', '2023-07-19'),
    ('Bilim Fuarı', '2023-08-03'),
    ('Müzik Festivali', '2023-09-28'),
    ('Yaz Kampı', '2023-10-15');
    


-- İstekveSikayet Tablosu ve 10 adet veri girişi
CREATE TABLE IF NOT EXISTS istekler_sikayetler (
    isteksikayetid SERIAL PRIMARY KEY,
    isteksikayetaciklama TEXT,
    isteksikayettarih TIMESTAMP,
    isteksikayettakibi TEXT
);

INSERT INTO istekler_sikayetler (isteksikayetaciklama, isteksikayettarih, isteksikayettakibi)
VALUES 
    ('Yemeklerde çeşitlilik istiyoruz.', '2023-01-15 13:45:00', 'İnceleniyor'),
    ('Otoparkta aydınlatma eksikliği var.', '2023-02-20 21:30:00', 'Çözüldü'),
    ('Kantin fiyatları yüksek.', '2023-03-25 16:15:00', 'İnceleniyor'),
    ('Spor salonu ekipmanları yenilensin.', '2023-04-10 10:00:00', 'Planlama aşamasında'),
    ('Wi-Fi sinyali zayıf.', '2023-05-05 08:45:00', 'Çözüldü'),
    ('Sınıflarda yazıcı eksik.', '2023-06-12 17:30:00', 'İnceleniyor'),
    ('Çamaşırhane sık sık arıza veriyor.', '2023-07-19 14:20:00', 'Çözüldü'),
    ('Tuvaletlerin temizliği yetersiz.', '2023-08-03 11:10:00', 'İnceleniyor'),
    ('Eksik ders kitapları var.', '2023-09-28 18:00:00', 'Çözülecek'),
    ('Kütüphane çalışma saatleri uzatılsın.', '2023-10-15 15:00:00', 'Planlama aşamasında');



CREATE TABLE IF NOT EXISTS memurlar_etkinlik (
    memurlartckimlikno VARCHAR(11) not null REFERENCES memurlar(tckimlikno),
    etkinlikid int not null REFERENCES etkinlikler(etkinlikid)
);

INSERT INTO memurlar_etkinlik(memurlartckimlikno, etkinlikid)
VALUES
('88000000001',1),
('88000000002',2),
('88000000003',3),
('88000000004',4),
('88000000005',5),
('88000000006',6),
('88000000007',7),
('88000000008',8),
('88000000009',9),
('88000000010',10);

-- select*from memurlar m inner join memurlar_etkinlik me on me.memurlartckimlikno = m.tckimlikno inner join etkinlikler e on me.etkinlikid = e.etkinlikid



CREATE TABLE IF NOT EXISTS guvenlik_olaylari (
    guvenliklertckimlikno VARCHAR(11) not null REFERENCES guvenlikler(tckimlikno),
    olayid int not null REFERENCES olaylar(olayid)
);

INSERT INTO guvenlik_olaylari(guvenliklertckimlikno, olayid)
VALUES
('77000000001',1),
('77000000002',2),
('77000000003',3),
('77000000004',4),
('77000000005',5),
('77000000006',6),
('77000000007',7),
('77000000008',8),
('77000000009',9),
('77000000010',10);

-- select*from guvenlikler g inner join guvenlik_olaylari guo on guo.guvenliklertckimlikno = g.tckimlikno inner join olaylar o on guo.olayid = o.olayid 
 
