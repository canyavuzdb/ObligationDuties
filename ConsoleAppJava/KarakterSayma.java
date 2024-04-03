import java.util.Scanner;

public class KarakterSayma {
    public static void main(String[] args){

        System.out.println("Karakter sayma programina hosgeldiniz!");

        int maxKarakterSayisi = GetKarakterDeger("Lutfen maksimum karakter sayisini belirleyiniz: ", 1, Integer.MAX_VALUE);

        String cumle = GetCumle(maxKarakterSayisi);
        
        boolean duyarlilik = GetDuyarlilik();

        char arananKarakter = GetKarakter();

        int sayi = KarakterSay(cumle, arananKarakter, duyarlilik);

        System.out.println("Girdiginiz cumlede " + sayi + " adet " + arananKarakter + " karakteri vardir.");
    }   

    public static int GetKarakterDeger(String mesaj, int min, int max)
    {
        Scanner scanner = new Scanner(System.in);

        while (true)
        {
            System.out.println(mesaj);
            String girdi = scanner.nextLine();
            int sayiDegeri = Integer.parseInt(girdi);

            if (sayiDegeri == 0)
            {
                System.out.println("Gecerli bir sayi giriniz!");
                continue;
            }
            else if (sayiDegeri < min || sayiDegeri > max)
            {
                System.out.println("Gecerli bir sayi giriniz!");
                continue;
            }
    
            return sayiDegeri;
        }
    }

    public static String GetCumle(int maxKarakterSayisi)
    {
        Scanner scanner = new Scanner(System.in);
        while (true)
        {
            System.out.println("Lutfen " + maxKarakterSayisi + " karakterden az ya da esit karaktere sahip bir cumle giriniz: ");
            String cumle = scanner.nextLine();
            if (cumle.length() <= maxKarakterSayisi)
            {
                return cumle;
            }
                System.out.println("Karakter limiti asildi!");

        }
        
    }

    public static boolean GetDuyarlilik()
    {
        Scanner scanner = new Scanner(System.in);
        while (true)
        {
            System.out.println("Buyuk/kucuk harf duyarliliği aktif olsun mu? (Evet(e)/Hayir(h)): ");
            String cevap = scanner.nextLine();
            if (cevap.equals("e"))
            {
                return true;
            }
            else if (cevap.equals("h"))
            {
                return false;
            }
            System.out.println("Gecersiz cevap! Lutfen 'Evet' veya 'Hayir' giriniz.");
        }

    }

    public static char GetKarakter()
    {
        Scanner scanner = new Scanner(System.in);
        while (true)
        {
            System.out.println("Analiz etmek icin bir harf giriniz: ");
            String input = scanner.nextLine();
            if (input.length() != 1)
            {
                System.out.println("Gecerli bir karakter giriniz!");
                continue;
            }
            char karakter = input.charAt(0);
            if (Character.isLetterOrDigit(karakter))
            {
                return karakter;
            }
            System.out.println("Gecerli bir karakter giriniz!");
        }
    }

    public static int KarakterSay(String cumle, char arananKarakter, boolean duyarlilik)
    {
        int sayac = 0;
        for (int i = 0; i < cumle.length(); i++)
        {
            char karakter = cumle.charAt(i);
            if (karakter == arananKarakter && duyarlilik == true)
            {
                sayac++;
            }
            else if (karakter == arananKarakter && duyarlilik == false)
            {
                sayac++;
            }
        }
        return sayac;
    }
}