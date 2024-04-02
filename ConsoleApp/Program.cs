using System;

public class KarakterSayma
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Karakter sayma programına hosgeldiniz!"); // Uygulamaya hosgeldiniz mesaji

        int maxKarakterSayisi = GetKarakterDeger("Lutfen maksimum karakter sayisini belirleyiniz: ", 1, int.MaxValue); // Maksimum karakter sayisi

        string cumle = GetCumle(maxKarakterSayisi); // Cumle girişi

        bool duyarlilik = GetDuyarlilik(); // Buyuk/Kucuk harf duyarliliği

        char arananKarakter = GetKarakter(); // Harf girisi

        int sayi = KarakterSay(cumle, arananKarakter, duyarlilik); // Harf tekrar sayisi

        Console.WriteLine($"'{arananKarakter}' karakteri metin icinde {sayi} defa gecmektedir."); // Sonucu goster
    }

    public static int GetKarakterDeger(string mesaj, int min, int max)
    {
        while (true)
        {
            Console.WriteLine(mesaj);
            string? girdi = Console.ReadLine();
            int sayiDegeri = int.TryParse(girdi, out int deger) ? deger : 0;

            if (sayiDegeri == 0)
            {

                Console.WriteLine("Gecerli bir sayi giriniz!");
                continue;
            }

            if (sayiDegeri < min || sayiDegeri > max)
            {
                Console.WriteLine($"{min} ile {max} arasinda bir sayi giriniz!");
                continue;
            }

            return sayiDegeri;
        }
    }

    public static string GetCumle(int maxKarakterSayisi)
    {
        while (true)
        {
            Console.WriteLine($"Lutfen {maxKarakterSayisi} karakterden az ya da esit karaktere sahip bir cumle giriniz: ");
            string? cumle = Console.ReadLine();

            if (cumle.Length <= maxKarakterSayisi)
            {
                return cumle;
            }

            Console.WriteLine("Karakter limiti asildi! Tekrar deneyiniz.");
        }
    }

    public static bool GetDuyarlilik()
    {
        while (true)
        {
            Console.WriteLine("Buyuk/kucuk harf duyarliliği aktif olsun mu? (Evet(e)/Hayir(h)): ");
            string? cevap = Console.ReadLine();

            if (cevap.Equals("e"))
            {
                return true;
            }
            else if (cevap.Equals("h"))
            {
                return false;
            }

            Console.WriteLine("Geçersiz cevap! Lütfen 'Evet' veya 'Hayır' giriniz.");
        }
    }

    public static char GetKarakter()
    {
        while (true)
        {
            Console.WriteLine("Analiz etmek icin bir harf giriniz: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Gecerli bir karakter giriniz!");
                continue;
            }
            Console.WriteLine();

            char karakter = input[0];
            if (char.IsLetterOrDigit(karakter))
            {
                return karakter;
            }

            Console.WriteLine("Gecerli bir karakter giriniz!");
        }
    }

    public static int KarakterSay(string cumle, char arananKarakter, bool duyarlilik)
    {
        // if (duyarlilik)
        // {
        //     cumle = cumle.ToUpper();
        //     arananKarakter = char.ToUpper(arananKarakter);
        // }
        // else
        // {
        //     cumle = cumle.ToLower();
        //     arananKarakter = char.ToLower(arananKarakter);
        // }
        
        string duyarlilikCumle = duyarlilik ? cumle.ToUpper() : cumle.ToLower();
        char duyarlilikArananKarakter = duyarlilik ? char.ToUpper(arananKarakter) : char.ToLower(arananKarakter);

        // Console.WriteLine(duyarlilikCumle);
        // Console.WriteLine(duyarlilikArananKarakter);

        int count = duyarlilikCumle.Count(c => c == duyarlilikArananKarakter);
        return count;

    }
}
