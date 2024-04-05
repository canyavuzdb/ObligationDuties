using System;
using System.Collections.Generic;

public class Urun
{
    public string Ad { get; set; }
    public double Fiyat { get; set; }
    public int StokMiktari { get; set; }
    public double DegerlendirmePuani { get; set; }
    public int UrunAdet { get; set; }

    public Urun(string ad, double fiyat, int stokMiktari, double degerlendirmePuani)
    {
        Ad = ad;
        Fiyat = fiyat;
        StokMiktari = stokMiktari;
        DegerlendirmePuani = degerlendirmePuani;
    }
}

public class Sepet
{
    public List<Urun> Urunler { get; set; }
    public int UrunAdet { get; set; }
    public double ToplamTutar { get; set; }

    public Sepet()
    {
        Urunler = new List<Urun>();
    }

    public void UrunEkle(Urun urun, int adet, int urunAdet)
    {
        if (urun.StokMiktari >= adet)
        {
            urun.StokMiktari -= adet;
            Urunler.Add(urun);
            urun.UrunAdet = urunAdet;

            HesaplaSepetTutarini();

            Console.WriteLine("Sepetiniz Guncellendi:");
            foreach (Urun urunSepette in Urunler)
            {
                Console.WriteLine("Urun Adi: {0} - Adet: {1} - Toplam Fiyat: {2}", urunSepette.Ad, urunSepette.UrunAdet, urunSepette.Fiyat * urunSepette.UrunAdet);
            }
            Console.WriteLine("Sepet Toplami: {0}", ToplamTutar);
        }
        else
        {
            Console.WriteLine("{0} urunu stokta bulunmuyor! Stoktaki urun adedi: {1}", urun.Ad, urun.StokMiktari);
        }
    }


    public void HesaplaSepetTutarini()
    {
        ToplamTutar = 0;

        foreach (Urun urun in Urunler)
        {
            ToplamTutar += urun.Fiyat * urun.UrunAdet;
        }
    }

    public void SepetOnaylama()
    {
        Console.WriteLine("Sepetinizi onayliyor musunuz? (Evet(e)/Hayir(h)): ");
        string? sepetOnayStr = Console.ReadLine();

        if (sepetOnayStr.ToLower() == "e")
        {
            Console.WriteLine("Siparişiniz tamamlandi!");
        }
        else if (sepetOnayStr.ToLower() != "h")
        {
            Console.WriteLine("Gecersiz bir secim yaptiniz. Lutfen 'E' veya 'H' giriniz.");
            SepetOnaylama();
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Urun> urunler = UrunleriAl();

        SiralamaIslemleri(urunler);

        SepetIslemleri(urunler);

        SepetIndirimiUygula(urunler);

        Console.WriteLine("Uygulama Sonlandiriliyor...");
    }
    public static void SepetIndirimiUygula(List<Urun> urunler)
    {
        try
        {
            // Sepetteki ilk iki ürünün toplam fiyatını hesaplayın
            double toplamFiyat = urunler[0].Fiyat * urunler[0].UrunAdet + urunler[1].Fiyat * urunler[1].UrunAdet;

            if (urunler[0].Fiyat > urunler[1].Fiyat)
            {
                double indirimMiktari = urunler[1].Fiyat;

                urunler[0].Fiyat -= indirimMiktari;

                toplamFiyat -= indirimMiktari;

                Console.WriteLine("{0} urunune {1} TL indirim uygulandi! Guncel toplam fiyat: {2} TL", urunler[0].Ad, indirimMiktari, toplamFiyat);
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Bilgilendirme: Indirim uygulanabilmesi icin en az iki urun olmalidir!");
            // Console.WriteLine("{0}", ex.Message);
        }
    }

    public static void SepetIslemleri(List<Urun> urunler)
    {
        Sepet sepet = new Sepet();
        bool sepeteUrunEklemeIstegi = true;

        while (sepeteUrunEklemeIstegi)
        {
            Console.WriteLine("Sepete urun eklemek istiyor musunuz? (Evet(e)/Hayir(h)): ");
            string? sepeteUrunEklemeIstegiStr = Console.ReadLine();

            if (sepeteUrunEklemeIstegiStr.ToLower() == "e")
            {
                Console.WriteLine("Sepetinize eklemek istediginiz urun adini giriniz:");
                string? urunAdi = Console.ReadLine();

                Console.WriteLine("Bu urunden kac adet eklemek istiyorsunuz?: ");
                int miktarStr = int.Parse(Console.ReadLine());

                if (miktarStr >= 2)
                {
                    Urun urun = urunler.Find(x => x.Ad == urunAdi);

                    if (urun == null)
                    {
                        Console.WriteLine("urun bulunamadi! Baska bir urun seciniz. Stokta bulunan urunler: {0}", string.Join(", ", urunler.Select(x => x.Ad)));
                        continue;
                    }

                    sepet.UrunEkle(urun, miktarStr, miktarStr);
                }
                else
                {
                    Console.WriteLine("En az 2 urun eklemeniz gerekiyor!");
                }
            }
            else if (sepeteUrunEklemeIstegiStr.ToLower() != "h")
            {
                Console.WriteLine("Gecersiz bir secim yaptiniz. Lutfen 'E' veya 'H' giriniz.");
            }
            else
            {
                sepeteUrunEklemeIstegi = false;
            }
        }
        sepet.SepetOnaylama();
    }
    public static void SiralamaIslemleri(List<Urun> urunler)
    {
        Console.WriteLine("Siralama Kriterini Seciniz:");
        Console.WriteLine("1. Ad");
        Console.WriteLine("2. Stok Miktari");
        Console.WriteLine("3. Degerlendirme Puani");
        string? kriterGirdi = Console.ReadLine();
        int siralamaKriteri = int.TryParse(kriterGirdi, out int kriterDeger) ? kriterDeger : 0;

        Console.WriteLine("Siralama Turunu Seciniz:");
        Console.WriteLine("1. Artan");
        Console.WriteLine("2. Azalan");
        string? turGirdi = Console.ReadLine();
        int siralamaTuru = int.TryParse(turGirdi, out int turDeger) ? turDeger : 0;

        switch (siralamaKriteri)
        {
            case 1:
                if (siralamaTuru == 1)
                {
                    urunler.Sort((x, y) => x.Ad.CompareTo(y.Ad));
                }
                else
                {
                    urunler.Sort((x, y) => y.Ad.CompareTo(x.Ad));
                }
                break;
            case 2:
                if (siralamaTuru == 1)
                {
                    urunler.Sort((x, y) => x.StokMiktari.CompareTo(y.StokMiktari));
                }
                else
                {
                    urunler.Sort((x, y) => y.StokMiktari.CompareTo(x.StokMiktari));
                }
                break;
            case 3:
                if (siralamaTuru == 1)
                {
                    urunler.Sort((x, y) => x.DegerlendirmePuani.CompareTo(y.DegerlendirmePuani));
                }
                else
                {
                    urunler.Sort((x, y) => y.DegerlendirmePuani.CompareTo(x.DegerlendirmePuani));
                }
                break;
        }

        foreach (Urun urun in urunler)
        {
            Console.WriteLine("Urun Adi: {0} - Birim Fiyati: {1} - Stok Miktari: {2} - Degerlendirme Puani: {3}", urun.Ad, urun.Fiyat, urun.StokMiktari, urun.DegerlendirmePuani);
        }
    }
    public static List<Urun> UrunleriAl()
    {
        // Urun  Sayisini Belirleme
        int urunCesidi;
        do
        {
            Console.WriteLine("Kac Adet urun Gireceksiniz?");
            string? urunGirdi = Console.ReadLine();
            urunCesidi = int.TryParse(urunGirdi, out int urunDeger) ? urunDeger : 0;

            if (urunCesidi <= 0)
            {
                Console.WriteLine("En az 1 adet urun girmeniz gerekir!");
            }
        } while (urunCesidi <= 0);



        // Urunlerin Listeye Eklenmesi
        List<Urun> urunler = new List<Urun>();
        for (int i = 0; i < urunCesidi; i++)
        {
            Console.WriteLine("{0}. Urun Bilgilerini Girinniz:", i + 1);

            // Urun Adi
            string? urunAdi;
            bool gecersizKarakter = true;
            do
            {
                Console.Write("Ad: ");
                urunAdi = Console.ReadLine();

                if (urunAdi.Length > 20)
                {
                    Console.WriteLine("urun adi en fazla 20 karakter olabilir!");
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
                    Console.WriteLine("urun adi sadece harflerden oluşabilir!");
                }
            } while (gecersizKarakter);


            // Fiyat
            double fiyat;
            do
            {
                Console.Write("Fiyat: ");
                string? fiyatGirdi = Console.ReadLine();
                if (!double.TryParse(fiyatGirdi, out fiyat))
                {
                    Console.WriteLine("Gecersiz bir fiyat girdiniz. Lutfen sadece rakam giriniz! (orn: 12.50)");
                    continue;
                }

                if (fiyat < 1 || fiyat > 100)
                {
                    Console.WriteLine("Fiyat 1 ile 100 arasinda olmalidir!");
                }
            } while (fiyat < 1 || fiyat > 100);

            // Stok Miktari
            int stokMiktari;
            do
            {
                Console.Write("Stok Miktari: ");
                string? stokMiktariDeger = Console.ReadLine();
                if (!int.TryParse(stokMiktariDeger, out stokMiktari))
                {
                    Console.WriteLine("Gecersiz bir stok miktari girdiniz. Lutfen sadece rakam giriniz! (orn: 1)");
                    continue;
                }
                if (stokMiktari < 1)
                {
                    Console.WriteLine("Stok miktari en az 1 olmalidir!");
                }
            } while (stokMiktari < 1);

            // Degerlendirme Puani
            double degerlendirmePuani;
            bool gecerliDegerlendirmePuani = false;
            do
            {
                Console.Write("Degerlendirme Puani (5 uzerinden): ");
                string? degerlendirmePuaniDeger = Console.ReadLine();

                if (!double.TryParse(degerlendirmePuaniDeger, out degerlendirmePuani))
                {
                    Console.WriteLine("Gecersiz bir degerlendirme puani girdiniz. Lutfen sadece rakam ve virgul giriniz! (orn: 3,5)");
                    continue;
                }

                if (degerlendirmePuani < 0 || degerlendirmePuani > 5)
                {
                    Console.WriteLine("Degerlendirme puani 0 ile 5 arasinda olmalidir!");
                }
                else
                {
                    gecerliDegerlendirmePuani = true;
                }
            } while (!gecerliDegerlendirmePuani);

            urunler.Add(new Urun(urunAdi, fiyat, stokMiktari, degerlendirmePuani));
        }

        return urunler;
    }
}
