using System;
using System.Collections.Generic;

public class Urun
{
    public string Ad { get; set; }
    public double Fiyat { get; set; }
    public int StokMiktari { get; set; }
    public double DegerlendirmePuani { get; set; }

    public Urun(string ad, double fiyat, int stokMiktari, double degerlendirmePuani)
    {
        Ad = ad;
        Fiyat = fiyat;
        StokMiktari = stokMiktari;
        DegerlendirmePuani = degerlendirmePuani;
    }
}
public class Program
{

    static void Main(string[] args)
    {


        //Siralama kriterlerini belirleme
        Console.WriteLine("E-Commerce programına hosgeldiniz!");
        Console.WriteLine("***********************************");
        Console.WriteLine("Sıralama Kriterini Seçiniz:");
        Console.WriteLine("1. Ad");
        Console.WriteLine("2. Stok Miktarı");
        Console.WriteLine("3. Değerlendirme Puanı");
        string? kriterGirdi = Console.ReadLine();
        int siralamaKriteri = int.TryParse(kriterGirdi, out int degerKriteri) ? degerKriteri : 0;

        Console.WriteLine("Sıralama Türünü Seçiniz:");
        Console.WriteLine("1. Artan");
        Console.WriteLine("2. Azalan");
        string? turuGirdi = Console.ReadLine();
        int siralamaTuru = int.TryParse(turuGirdi, out int degerTuru) ? degerTuru : 0;


    }

}
