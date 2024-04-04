using System;
using System.Collections.Generic;

public class Urun //Product Modeli -  Models
{
    public string Ad { get; set; }
    public double Fiyat { get; set; }
    public int StokMiktari { get; set; }
    public int UrunCesit { get; set; }
    public double DegerlendirmePuani { get; set; }
    public bool GecersizKarakter { get; set; }
    public int  UrunAdet { get; set; }

    public Urun(string ad, double fiyat, int stokMiktari, double degerlendirmePuani, int urunCesit, bool gecersizKarakter)
    {
        Ad = ad;
        Fiyat = fiyat;
        StokMiktari = stokMiktari;
        UrunCesit = urunCesit;

        DegerlendirmePuani = degerlendirmePuani;
        GecersizKarakter = gecersizKarakter;
    }
}

// public class Sepet
// {
//     public List<Urun> Urunler { get; set; }
//     public int UrunAdet { get; set; }
//     public int ToplamTutar { get; set; }
// }

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

        // Sıralanmış ürün listesini yazdırın.
        foreach (Urun urun in urunler)
        {
            Console.WriteLine("Urun Adı: {0} - Birim Fiyatı: {1} - Stok Miktarı: {2} - Degerlendirme Puanı: {3}", urun.Ad, urun.Fiyat, urun.StokMiktari, urun.DegerlendirmePuani);
        }
        // Ürünleri Yazdır
        Console.WriteLine("-------------------");


        // Sepete Ekleme
        bool sepeteUrunEklemeIstegi = true;

        while (sepeteUrunEklemeIstegi)
        {
            Console.WriteLine("Sepete Ürün Eklemek İster misiniz? (Evet(e)/Hayır(h)): ");
            string sepeteEklemeIstegiStr = Console.ReadLine();

            if (sepeteEklemeIstegiStr.ToLower() == "e")
            {
                while (sepeteUrunEklemeIstegi)
                {
                    Console.WriteLine("Ürün adını giriniz:");
                    string urunAdi = Console.ReadLine();

                    Console.WriteLine("Kaç adet ürün eklemek istiyorsunuz?: ");
                    int miktarStr = int.Parse(Console.ReadLine());

                    if (miktarStr >= 2)
                    {
                        Urun urun = urunler.Find(x => x.Ad == urunAdi);

                        if (urun == null)
                        {
                            Console.WriteLine("Ürün bulunamadı!");
                            continue;
                        }

                        if (urun.StokMiktari >= miktarStr)
                        {
                            for (int i = 0; i < miktarStr; i++)
                            {
                                
                                Console.WriteLine("{0} ürünü sepete eklendi.", urunAdi);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Stokta yeterli ürün bulunmamaktadır! Mevcut stok: {0}", urun.StokMiktari);
                        }
                    }
                    else
                    {
                        Console.WriteLine("En az 2 ürün eklemeniz gerekiyor!");
                    }
                }


                // List<Urun> urunler = UrunleriAl();
            }
            else if (sepeteEklemeIstegiStr.ToLower() == "h")
            {
                sepeteUrunEklemeIstegi = false;

                // Sepet durumunu gösterin.
                // Örnek:
                foreach (Urun urun in urunler)
                {
                    Console.WriteLine("Urun Adı: {0} - Birim Fiyatı: {1} - Stok Miktarı: {2} - Degerlendirme Puanı: {3}", urun.Ad, urun.Fiyat, urun.StokMiktari, urun.DegerlendirmePuani);
                }

                Console.WriteLine("Uygulama Sonlandırılıyor...");
            }
            // else if(){

            // }
            else
            {
                Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen 'E' veya 'H' giriniz.");
            }
        }

        // List<Sepet> sepetler = SepeteUrunEkle();

    }



    public static List<Urun> UrunleriAl()
    {
        // Urun  Sayisini Belirleme
        int urunCesidi;
        do
        {
            Console.WriteLine("Kaç Adet Ürün Gireceksiniz?");
            string? urunGirdi = Console.ReadLine();
            urunCesidi = int.TryParse(urunGirdi, out int urunDeger) ? urunDeger : 0;

            if (urunCesidi <= 0)
            {
                Console.WriteLine("En az 1 adet ürün girmeniz gerekir!");
            }
        } while (urunCesidi <= 0);



        // Urunlerin Listeye Eklenmesi
        List<Urun> urunler = new List<Urun>();
        for (int i = 0; i < urunCesidi; i++)
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

            // Degerlendirme Puani
            double degerlendirmePuani;
            bool gecerliDegerlendirmePuani = false;
            do
            {
                Console.Write("Değerlendirme Puanı (5 üzerinden): ");
                string degerlendirmePuaniDeger = Console.ReadLine();

                if (!double.TryParse(degerlendirmePuaniDeger, out degerlendirmePuani))
                {
                    Console.WriteLine("Geçersiz bir değerlendirme puanı girdiniz. Lütfen sadece rakam ve virgül giriniz! (Örn: 3,5)");
                    continue;
                }

                if (degerlendirmePuani < 0 || degerlendirmePuani > 5)
                {
                    Console.WriteLine("Değerlendirme puanı 0 ile 5 arasında olmalıdır!");
                    gecerliDegerlendirmePuani = false;
                }
                else
                {
                    gecerliDegerlendirmePuani = true;
                }

            } while (!gecerliDegerlendirmePuani);

            urunler.Add(new Urun(urunAdi, fiyat, stokMiktari, degerlendirmePuani, urunCesidi, gecersizKarakter));
        }

        return urunler;
    }


    public static List<Urun> UrunleriListele()
    {

        List<Urun> urunler = new List<Urun>();

        // while (true)
        // {
        //     Console.WriteLine("Kaç adet ürün eklemek istiyorsunuz?: ");
        //     int miktarStr = int.Parse(Console.ReadLine());

        //     if (miktarStr >= 2)
        //     {
        //         for (int i = 0; i < miktarStr; i++)
        //         {
        //             string stoktaMi = Console.ReadLine();
        //             Console.WriteLine("Urun Miktarını Giriniz: ");
        //             Urun urun = urunler.Find(x => x.Ad == stoktaMi);
        //             if (urun == null)
        //             {
        //                 Console.WriteLine("Ürün bulunamadı!");
        //             }
        //             else
        //             {
        //                 Console.WriteLine("{0} ürünü sepete eklendi.", urun.Ad);

        //             }
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("En az 2 ürün eklemeniz gerekiyor!");
        //     }
        // }




        // while (true)
        // {
        //     Console.WriteLine("Kaç adet ürün eklemek istiyorsunuz?: ");
        //     int urunAdedi = int.Parse(Console.ReadLine());

        //     if (urunAdedi >= 2)
        //     {
        //         for (int i = 0; i < urunAdedi; i++)
        //         {
        //             Console.WriteLine("{0}. Ürün Adı: ", i + 1);
        //             string urunAdi = Console.ReadLine();
        //             Urun urun = urunler.Find(x => x.Ad == urunAdi);

        //             if (urun != null && urun.StokMiktari > 0)
        //             {
        //                 urun.StokMiktari--;
        //                 urunler.Add(urun);
        //             }
        //             else
        //             {
        //                 Console.WriteLine("{0} ürünü stokta bulunmuyor!", urunAdi);
        //             }
        //         }

        //         // Sepet tutarını hesapla
        //         HesaplaSepetTutarini(urunler);

        //         break; // Döngüden çık
        //     }
        //     else
        //     {
        //         Console.WriteLine("En az 2 ürün eklemeniz gerekiyor!");
        //     }
        // }
        return urunler;

    }
    // static void HesaplaSepetTutarini(List<Urun> urunler)
    // {
    //     double toplamTutar = 0;

    //     for (int i = 0; i < urunler.Count; i++)
    //     {
    //         toplamTutar += urunler[i].Fiyat * urunler[i].UrunAdet;
    //     }

    //     Console.WriteLine("Sepet Tutarı: {0}", toplamTutar);
    // }


    // static List<Sepet> SepeteUrunEkle()
    // {
    //     List<Sepet> sepetler = new List<Sepet>();
    //     return sepetler;



    // }
}

