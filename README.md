# ObligationDuties

Bu repo icerisinde *STAJ PROGRAMI DEĞERLENDİRME* Ödevlerini barindirir.

*Soru 1:*
Kullanıcının gireceği text içerisinde istenilen karakteri büyük/küçük harf duyarlılığına göre sayacak bir program
tasarlanmalıdır.
• Karakter Sayısı ve Cümle Girişi:
Kullanıcıdan maksimum karakter sayısını belirlemesini isteyin.
Kullanıcıdan bu limit dahilinde bir cümle girmesini isteyin. Eğer girilen cümle karakter limi@ni
aşıyorsa, uyarı verin ve kullanıcıdan cümleyi yeniden girmesini isteyin.
• Büyük/Küçük Harf Duyarlılığı Seçeneği:
Cümle ve harf analizi yapmadan önce, kullanıcıdan büyük/küçük harf duyarlılığı tercihini alın. Örneğin,
kullanıcıya "Büyük/küçük harf duyarlılığı ak@f olsun mu? (Evet/Hayır)" diye sorabilirsiniz. İstenen
değerler haricinde bir cevap girildiğinde hata mesajı verilmedir. Örneğin: Evet/Hayır seçenekleri
haricinde bir değer girilmesi durumunda “Lü?en geçerli bir cevap giriniz.” şeklinde hata mesajı
çıkmalıdır.

• Harf Tekrar Sayısı Analizi:
Kullanıcıdan analiz edilmek üzere bir karakter girmesini isteyin.
Herhangi bir karakter girilmeden ilerlendiğinde “Geçerli bir karakter giriniz” şeklinde hata mesajı
çıkmalıdır.
Daha önce alınan büyük/küçük harf duyarlılığı tercihine göre, girilen cümlede bu harfin kaç defa
tekrar edildiğini hesaplayın.
• Örnek Program Akışı:

Maksimum karakter sayısı belirleyin: 50
LüWen bir cümle girin: Merhaba Dünya!
Büyük/küçük harf duyarlılığı ak@f olsun mu? (Evet/Hayır): Hayır
Analiz etmek için bir harf girin: a
Girilen cümlede 'a' harfi toplamda 3 defa geçmektedir.
--------------------------------------------------------------------------------------------------------------------------------------------------------
*Soru 2:*
Bir e-@caret plaWormu için dinamik bir ürün yöne@m sistemi tasarlanması gerekiyor. Bu sistem, kullanıcıdan
alınan girdilere göre ürünleri kaydetme, sonra da belirli kriterlere göre bu ürünleri sıralama yeteneğine sahip
olacak. Kullanıcının ürün sayısı, her bir ürün için ad, fiyat, stok miktarı ve değerlendirme puanı gibi bilgileri
girebilmesini, sonrasında ise bu ürünlerin farklı kriterlere göre sıralanabilmesini ve kullanıcının seç@ği ürünleri
sepete eklemesini sağlayan bir Java programı tasarlanmalıdır.
Ürün Bilgilerinin Alınması:
- Kullanıcıdan kaç adet ürün gireceğini sorun. (Birden fazla farklı ürün girişi yapılmalıdır, aksi tak@rde
uyarı verin)
- Her bir ürün için kullanıcıdan ürün adı, fiya_, stok miktarı ve değerlendirme puanını (5 üzerinden)
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
- Kullanıcı ürün eklemek is@yorsa, sepeee en az iki ürün olacak şekilde ürün adını ve eklemek istediği
adedi belirterek ürün girişi sağlanır.
- Girilen ürün adı kontrol edilir ve stok miktarı yeterli ise ürün sepete eklenir. Aksi takdirde, stokta yeterli
ürün olmadığı belir@lir ve kullanıcıdan yeni bir adet girmesi istenir.
• Sepete Tutarı Hesaplama:
- Kullanıcı ürün eklemeyi bi@rdiğinde, sepe@n toplam tutarı aşağıdaki man_ğa göre hesaplanacak_r:
- Sepeee eklenme sırasına göre ilk ürün fiya_ ikinci üründen fazla ise ilk üründen ikinci ürünün birim
maliye@ kadar indirim yapılır. Bu man_k sepe@n tüm ürünleri dikkate alınarak hesaplanacak_r.