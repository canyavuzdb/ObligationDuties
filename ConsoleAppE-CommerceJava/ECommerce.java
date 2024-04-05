import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class Urun {
    public String Ad;
    public double Fiyat;
    public int StokMiktari;
    public double DegerlendirmePuani;

    public Urun(String ad, double fiyat, int stokMiktari, double degerlendirmePuani) {
        Ad = ad;
        Fiyat = fiyat;
        StokMiktari = stokMiktari;
        DegerlendirmePuani = degerlendirmePuani;
    }
}

class Sepet {
    public List<Urun> Urunler;

    public Sepet() {
        Urunler = new ArrayList<>();
    }

    public void SepeteUrunEkle(Urun urun, int adet) {
        if (urun.StokMiktari >= adet) {
            urun.StokMiktari -= adet;
            Urunler.add(urun);

            SepetTutariniHesapla();

            System.out.println("Sepetiniz Güncellendi:");
            for (Urun urunSepette : Urunler) {
                System.out.println("Ürün Adı: " + urunSepette.Ad + " - Adet: " + adet + " - Toplam Fiyat: " + urunSepette.Fiyat * adet);
            }
            System.out.println("Sepet Toplamı: " + SepetTutariniHesapla());
        } else {
            System.out.println(urun.Ad + " ürünü stokta bulunmuyor! Stoktaki ürün adedi: " + urun.StokMiktari);
        }
    }

    public double SepetTutariniHesapla() {
        double toplamTutar = 0;

        for (Urun urun : Urunler) {
            toplamTutar += urun.Fiyat * urun.StokMiktari;
        }

        return toplamTutar;
    }

    public void SepetiOnayla() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Sepetinizi onaylıyor musunuz? (Evet(e)/Hayır(h)): ");
        String sepetOnayStr = scanner.nextLine();

        if (sepetOnayStr.equalsIgnoreCase("e")) {
            System.out.println("Siparişiniz tamamlandı!");
        } else if (!sepetOnayStr.equalsIgnoreCase("h")) {
            System.out.println("Geçersiz bir seçim yaptınız. Lütfen 'E' veya 'H' giriniz.");
            SepetiOnayla();
        }
    }
}

public class ECommerce {
    public static void main(String[] args) {

        List<Urun> urunler = KullanicidanUrunleriAl();

        SepetIslemleri(urunler);

        SepetIndirimiUygula(urunler);

        System.out.println("Uygulama Sonlandırılıyor...");
    }

    public static void SepetIndirimiUygula(List<Urun> urunler) {
        if (urunler.size() >= 2) {
            // Sepetteki ilk iki ürünün toplam fiyatını hesaplayın
            double toplamFiyat = urunler.get(0).Fiyat * urunler.get(0).StokMiktari + urunler.get(1).Fiyat * urunler.get(1).StokMiktari;

            if (urunler.get(0).Fiyat > urunler.get(1).Fiyat) {
                double indirimMiktari = urunler.get(1).Fiyat;

                urunler.get(0).Fiyat -= indirimMiktari;

                toplamFiyat -= indirimMiktari;

                System.out.println(urunler.get(0).Ad + " ürününe " + indirimMiktari + " TL indirim uygulandı! Güncel toplam fiyat: " + toplamFiyat + " TL");
            }
        } else {
            System.out.println("Bilgilendirme: İndirim uygulanabilmesi için en az iki ürün olmalıdır!");
        }
    }

    public static void SepetIslemleri(List<Urun> urunler) {
        Sepet sepet = new Sepet();
        boolean sepeteUrunEklemeIstegi = true;

        while (sepeteUrunEklemeIstegi) {
            Scanner scanner = new Scanner(System.in);
            System.out.println("Sepete ürün eklemek istiyor musunuz? (Evet(e)/Hayır(h)): ");
            String sepeteUrunEklemeIstegiStr = scanner.nextLine();

            if (sepeteUrunEklemeIstegiStr.equalsIgnoreCase("e")) {
                System.out.println("Sepetinize eklemek istediğiniz ürün adını giriniz:");
                String urunAdi = scanner.nextLine();

                System.out.println("Bu üründen kaç adet eklemek istiyorsunuz?: ");
                int miktarStr = Integer.parseInt(scanner.nextLine());

                Urun urun = urunler.stream().filter(x -> x.Ad.equals(urunAdi)).findFirst().orElse(null);

                if (urun == null) {
                    System.out.println("Ürün bulunamadı! Başka bir ürün seçiniz. Stokta bulunan ürünler: " + String.join(", ", urunler.stream().map(x -> x.Ad).toArray(String[]::new)));
                    continue;
                }

                sepet.SepeteUrunEkle(urun, miktarStr);
            } else if (!sepeteUrunEklemeIstegiStr.equalsIgnoreCase("h")) {
                System.out.println("Geçersiz bir seçim yaptınız. Lütfen 'E' veya 'H' giriniz.");
            } else {
                sepeteUrunEklemeIstegi = false;
            }
        }
        sepet.SepetiOnayla();
    }

    public static List<Urun> KullanicidanUrunleriAl() {
        Scanner scanner = new Scanner(System.in);
        // Ürün Sayısını Belirleme
        int urunCesidi;
        do {
            System.out.println("Kaç adet ürün gireceksiniz?");
            urunCesidi = Integer.parseInt(scanner.nextLine());

            if (urunCesidi <= 0) {
                System.out.println("En az 1 adet ürün girmeniz gerekmektedir!");
            }
        } while (urunCesidi <= 0);

        // Ürünlerin Listeye Eklenmesi
        List<Urun> urunler = new ArrayList<>();
        for (int i = 0; i < urunCesidi; i++) {
            System.out.println((i + 1) + ". Ürün Bilgilerini Giriniz:");

            // Ürün Adı
            String urunAdi;
            boolean gecersizKarakter;
            do {
                System.out.print("Ad: ");
                urunAdi = scanner.nextLine();
                gecersizKarakter = false;

                if (urunAdi.length() > 20) {
                    System.out.println("Ürün adı en fazla 20 karakter olabilir!");
                    continue;
                }

                for (char karakter : urunAdi.toCharArray()) {
                    if (!Character.isLetter(karakter)) {
                        gecersizKarakter = true;
                        break;
                    }
                }

                if (gecersizKarakter) {
                    System.out.println("Ürün adı sadece harflerden oluşabilir!");
                }
            } while (gecersizKarakter);

            // Fiyat
            double fiyat;
            do {
                System.out.print("Fiyat: ");
                fiyat = Double.parseDouble(scanner.nextLine());

                if (fiyat < 1 || fiyat > 100) {
                    System.out.println("Fiyat 1 ile 100 arasında olmalıdır!");
                }
            } while (fiyat < 1 || fiyat > 100);

            // Stok Miktari
            int stokMiktari;
            do {
                System.out.print("Stok Miktari: ");
                stokMiktari = Integer.parseInt(scanner.nextLine());

                if (stokMiktari < 1) {
                    System.out.println("Stok miktari en az 1 olmalidir!");
                }
            } while (stokMiktari < 1);

            // Degerlendirme Puani
            double degerlendirmePuani;
            boolean gecerliDegerlendirmePuani;
            do {
                System.out.print("Degerlendirme Puani (5 üzerinden): ");
                degerlendirmePuani = Double.parseDouble(scanner.nextLine());
                gecerliDegerlendirmePuani = degerlendirmePuani >= 0 && degerlendirmePuani <= 5;

                if (!gecerliDegerlendirmePuani) {
                    System.out.println("Degerlendirme puanı 0 ile 5 arasında olmalıdır!");
                }
            } while (!gecerliDegerlendirmePuani);

            urunler.add(new Urun(urunAdi, fiyat, stokMiktari, degerlendirmePuani));
        }

        return urunler;
    }
}

