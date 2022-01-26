- Ef CodeFirst için temel düzey modeller oluşturuldu.
- NotTablosu ve EgitimYoklamalari tablolarında egitimId ve ogrenciId tekrarlamasının önüne geçmek amacıyla ;
  - Bu iki satır yerine EgitimOgrencileri id satırı kullanılacak. Bu sayede her eğitim-öğrenci ilişkisi için kontroller kolaylaşacak ve veri tekrarının önüne geçilecek
  - Aynı şekilde stored procedure, view, trigger bölümlerinde gerekli düzenlemeler yapılacaktır
- Ödev için taslak oluşturulmuştur, ara dersten sonra gerekli araştırmalar tamamlanıp ödev son haline getirilecektir.
- Çalışan düzeyde en basit yapı oluşturulmaya çalışılmıştır.
- Araştırılacak konular : sql naming conventions, using error messages with stored procedures, more readable codes on sql

![Schema](schema.png)

# 3. Hafta Ödev
Veritabanı 
1. Patikadev yapısını düşünerek bir db oluşturun
  - eğitimler, öğrenciler,katılımcılar,eğitmenler,asistanlar, eğitimde öğrencilerin yoklamalarının ve başarı durumlarının tutulduğu tablolar olacaktır.
  - veritipleri ve ilişkiler belirtilmelidir.
2. trigger yazın
  - öğrenci yoklaması girildiğinde. yoklama durumuna göre başarı durumunu hafta bazlı olarak güncelleyin.(Örn: eğitim 7 hafta olsun. ilk iki hafta derslere katıldı ise başarı oranı 2/7 nin % olarak karşılı olmalı.)
3. stored procedure yazın
  - öğrencileri eğitimlere ekleyen bir procedure olacak. öğrenci belirtilen eğitim tarihinde herhangi başka bir eğitime kayıtlı olmamalıdır.
4. view yazın
  - eğitim bazlı öğrencileri listeleyin(gruplu olarak)

# Bonus
- Aynı yapıyı ef code first olarak sadece model bazında oluşturun
