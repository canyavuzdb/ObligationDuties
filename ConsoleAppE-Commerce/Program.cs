using System;
using System.Collections.Generic;

public class Urun //Product Modeli -  Models
{
    public string Ad { get; set; }
    public double Fiyat { get; set; }
    public int StokMiktari { get; set; }
    public int UrunAdet { get; set; }
    public double DegerlendirmePuani { get; set; }
    public bool GecersizKarakter { get; set; }

    public Urun(string ad, double fiyat, int stokMiktari, double degerlendirmePuani, int urunAdet, bool gecersizKarakter)
    {
        Ad = ad;
        Fiyat = fiyat;
        StokMiktari = stokMiktari;
        DegerlendirmePuani = degerlendirmePuani;
        UrunAdet = urunAdet;
        GecersizKarakter = gecersizKarakter;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Ürünleri Al ve Kontrol Et
        List<Urun> urunler = UrunleriAl();

        // Sıralama Kriterini Seç
        Console.WriteLine("Sıralama Kriterini Seçiniz:");
        Console.WriteLine("1. Ad");
        Console.WriteLine("2. Stok Miktarı");
        Console.WriteLine("3. Değerlendirme Puanı");
        string? kriterGirdi = Console.ReadLine();
        int siralamaKriteri = int.TryParse(kriterGirdi, out int kriterDeger) ? kriterDeger : 0;

        // Sıralama Türünü Seç
        Console.WriteLine("Sıralama Türünü Seçiniz:");
        Console.WriteLine("1. Artan");
        Console.WriteLine("2. Azalan");
        string? turGirdi = Console.ReadLine();
        int siralamaTuru = int.TryParse(turGirdi, out int turDeger) ? turDeger : 0;

        // Ürünleri Sırala
        var siraliUrunler = urunler.OrderBy(x => x.Ad).ThenBy(x => x.Fiyat);

        foreach (var urun in siraliUrunler)
        {
            Console.WriteLine(urun);
        }

        // Sıralama Yönünü Belirle
        if (siralamaTuru == 2)
        {
            urunler.Reverse();
        }

        // Ürünleri Yazdır
        Console.WriteLine("-------------------");
        foreach (var urun in urunler)
        {
            Console.WriteLine("Ad: {0}", urun.Ad);
            Console.WriteLine("Fiyat: {0}", urun.Fiyat);
            Console.WriteLine("Stok Miktarı: {0}", urun.StokMiktari);
            Console.WriteLine("Değerlendirme Puanı: {0}", urun.DegerlendirmePuani);
            Console.WriteLine("-------------------");
        }

 
    }

    static List<Urun> UrunleriAl()
    {
        // Urun  Sayisini Belirleme
        int urunSayisi;
        do
        {
            Console.WriteLine("Kaç Adet Ürün Gireceksiniz?");
            string? urunGirdi = Console.ReadLine();
            urunSayisi = int.TryParse(urunGirdi, out int urunDeger) ? urunDeger : 0;

            if (urunSayisi <= 0)
            {
                Console.WriteLine("En az 1 adet ürün girmeniz gerekir!");
            }
        } while (urunSayisi <= 0);



        // Urunlerin Listeye Eklenmesi
        List<Urun> urunler = new List<Urun>();
        for (int i = 0; i < urunSayisi; i++)
        {
            Console.WriteLine("{0}. Urun Bilgilerini Girinniz:", i + 1);

            // Urun
            string urunAdi;
            bool gecersizKarakter = true;
            do
            {
                Console.Write("Ad: ");
                urunAdi = Console.ReadLine();

                if (urunAdi.Length > 20)
                {
                    Console.WriteLine("Ürün adı en fazla 20 karakter olabilir!");
                    continue;
                }

                foreach (char karakter in urunAdi)
                {
                    if (char.IsLetter(karakter))
                    {
                        gecersizKarakter = false;
                        break;
                    }
                }

                if (gecersizKarakter)
                {
                    Console.WriteLine("Ürün adı sadece harflerden oluşabilir!");
                }
            } while (gecersizKarakter);


            // Fiyat
            double fiyat;
            do
            {
                Console.Write("Fiyat: ");
                string fiyatGirdi = Console.ReadLine();
                if (!double.TryParse(fiyatGirdi, out fiyat))
                {
                    Console.WriteLine("Geçersiz bir fiyat girdiniz. Lütfen sadece rakam giriniz! (Örn: 12.50)");
                    continue;
                }

                if (fiyat < 1 || fiyat > 100)
                {
                    Console.WriteLine("Fiyat 1 ile 100 arasında olmalıdır!");
                }
            } while (fiyat < 1 || fiyat > 100);

            // Stok Miktari
            int stokMiktari;
            do
            {
                Console.Write("Stok Miktarı: ");
                string stokMiktariDeger = Console.ReadLine();

                if (!int.TryParse(stokMiktariDeger, out stokMiktari))
                {
                    Console.WriteLine("Geçersiz bir stok miktarı girdiniz. Lütfen sadece rakam giriniz! (Örn: 1)");
                    continue;
                }
                if (stokMiktari < 1)
                {
                    Console.WriteLine("Stok miktarı en az 1 olmalıdır!");
                }
            } while (stokMiktari < 1);

            // Degerlendirme puani
            double degerlendirmePuani;
            do
            {
                Console.Write("Değerlendirme Puanı (5 üzerinden): ");
                string degerlendirmePuaniDeger = Console.ReadLine();
                degerlendirmePuani = double.TryParse(degerlendirmePuaniDeger, out degerlendirmePuani) ? degerlendirmePuani : 0;
                if (degerlendirmePuani < 0 || degerlendirmePuani > 5)
                {
                    Console.WriteLine("Değerlendirme puanı 0 ile 5 arasında olmalıdır!");
                }
            } while (degerlendirmePuani < 0 || degerlendirmePuani > 5);

            urunler.Add(new Urun(urunAdi, fiyat, stokMiktari, degerlendirmePuani, urunSayisi, gecersizKarakter));
        }

        return urunler;
    }
}
