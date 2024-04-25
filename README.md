# ObligationDuties

Bu repo icerisinde *STAJ PROGRAMI DEĞERLENDİRME* Ödevlerini barindirir.

*Soru 1:*
Kullanıcının gireceği text içerisinde istenilen karakteri büyük/küçük harf duyarlılığına göre sayacak bir program
tasarlanmalıdır.
• Karakter Sayısı ve Cümle Girişi:
Kullanıcıdan maksimum karakter sayısını belirlemesini isteyin.
Kullanıcıdan bu limit dahilinde bir cümle girmesini isteyin. Eğer girilen cümle karakter limitini
aşıyorsa, uyarı verin ve kullanıcıdan cümleyi yeniden girmesini isteyin.
• Büyük/Küçük Harf Duyarlılığı Seçeneği:
Cümle ve harf analizi yapmadan önce, kullanıcıdan büyük/küçük harf duyarlılığı tercihini alın. Örneğin,
kullanıcıya "Büyük/küçük harf duyarlılığı aktif olsun mu? (Evet/Hayır)" diye sorabilirsiniz. İstenen
değerler haricinde bir cevap girildiğinde hata mesajı verilmedir. Örneğin: Evet/Hayır seçenekleri
haricinde bir değer girilmesi durumunda “Lü?en geçerli bir cevap giriniz.” şeklinde hata mesajı
çıkmalıdır.

• Harf Tekrar Sayısı Analizi:
Kullanıcıdan analiz edilmek üzere bir karakter girmesini isteyin.
Herhangi bir karakter girilmeden ilerlendiğinde “Geçerli bir karakter giriniz” şeklinde hata mesajı
çıkmalıdır.
Daha önce alınan büyük/küçük harf duyarlılığı tercihine göre, girilen cümlede bu harfin kaç defa
tekrar edildiğini hesaplayın.

*Örnek Program Akışı:*
Maksimum karakter sayısı belirleyin: 50
Lütfen bir cümle girin: Merhaba Dünya!
Büyük/küçük harf duyarlılığı akif olsun mu? (Evet/Hayır): Hayır
Analiz etmek için bir harf girin: a
Girilen cümlede 'a' harfi toplamda 3 defa geçmektedir.

--------------------------------------------------------------------------------------------------------------------------------------------------------
*Soru 2:*
Bir e-ticaret plaWormu için dinamik bir ürün yönetim sistemi tasarlanması gerekiyor. Bu sistem, kullanıcıdan
alınan girdilere göre ürünleri kaydetme, sonra da belirli kriterlere göre bu ürünleri sıralama yeteneğine sahip
olacak. Kullanıcının ürün sayısı, her bir ürün için ad, fiyat, stok miktarı ve değerlendirme puanı gibi bilgileri
girebilmesini, sonrasında ise bu ürünlerin farklı kriterlere göre sıralanabilmesini ve kullanıcının seçeceği ürünleri
sepete eklemesini sağlayan bir Java programı tasarlanmalıdır.
Ürün Bilgilerinin Alınması:
- Kullanıcıdan kaç adet ürün gireceğini sorun. (Birden fazla farklı ürün girişi yapılmalıdır, aksi taktirde
uyarı verin)
- Her bir ürün için kullanıcıdan ürün adı, fiyati, stok miktarı ve değerlendirme puanını (5 üzerinden)
alın.
- Girilen fiyat bilgisi 1 ve 100 arasında olmalıdır. Aksi takdirde kullanıcıya uyarı verip tekrar girilmesi
istenmelidir.
- Stok miktarı en az 1 olmalıdır. 1’den az olduğunda kullanıcıya uyarı verip tekrar girilmesi istenmelidir.

- Ürün adı bilgisi en fazla 20 karakter olmalıdır. Aksi takdirde kullanıcıya uyarı verip tekrar girilmesi
istenmelidir.
• Sıralama:
- Kullanıcıdan ürünleri hangi kritere göre sıralamak istediğini sorun (örneğin, ad, stok, değerlendirme).
- Kullanıcıdan sıralamanın artan mı yoksa azalan mı olacağını sorun.
- Seçilen kritere ve sıralama türüne göre ürün listesini sıralayın.
• Sepete Ekleme:
- Sıralama sonrası, kullanıcıya sepete ürün ekleyip eklemek istemediğini sorun.
- Kullanıcı ürün eklemek istiyorsa, sepeee en az iki ürün olacak şekilde ürün adını ve eklemek istediği
adedi belirterek ürün girişi sağlanır.
- Girilen ürün adı kontrol edilir ve stok miktarı yeterli ise ürün sepete eklenir. Aksi takdirde, stokta yeterli
ürün olmadığı belirtilir ve kullanıcıdan yeni bir adet girmesi istenir.
• Sepete Tutarı Hesaplama:
- Kullanıcı ürün eklemeyi bitirdiğinde, sepetin toplam tutarı aşağıdaki mantiğa göre hesaplanacaktir:
- Sepeee eklenme sırasına göre ilk ürün fiyati ikinci üründen fazla ise ilk üründen ikinci ürünün birim
maliyeti kadar indirim yapılır. Bu mantik sepetin tüm ürünleri dikkate alınarak hesaplanacaktir.

*Örnek Program Akışı:*
Kaç farklı ürün gireceksiniz: 2
Ürün 1:
Ürün Adı: Kalem
Birim Fiyat: 1.50
Stok Miktarı: 100
Değerlendirme Puanı: 4.5
Ürün 2:
Ürün Adı: Deher
Birim Fiyat: 3.00
Stok Miktarı: 50
Değerlendirme Puanı: 4.7
Ürünleri hangi kritere göre sıralamak istersiniz? (name/stock/ra@ng)
Seçilen Kriter: ra@ng
Sıralama türü artan mı azalan mı olsun? (artan/azalan)
Seçilen Sıralama Türü: azalan
Sıralanmış Ürünler:
Deher - Fiyat: 3.00, Stok: 50, Değerlendirme: 4.7
Kalem - Fiyat: 1.50, Stok: 100, Değerlendirme: 4.5
Sepete ürün eklemek ister misiniz? (Evet/Hayır): Evet
Eklemek istediğiniz ürünün adı: Deher
Eklemek istediğiniz adet: 2
Kalem sepe@nize eklendi.
Sepete ürün eklemek ister misiniz? (Evet/Hayır): Evet
Eklemek istediğiniz ürünün adı: Kalem
Eklemek istediğiniz adet: 2
Kalem sepe@nize eklendi.
Sepete başka ürün eklemek ister misiniz? (Evet/Hayır): Hayır
Sepe@niz:
Deher - Adet: 2, Toplam Fiyat : 3.00
Kalem - Adet: 2, Toplam Fiyat : 3.00
Sepet Toplamı: 6.00