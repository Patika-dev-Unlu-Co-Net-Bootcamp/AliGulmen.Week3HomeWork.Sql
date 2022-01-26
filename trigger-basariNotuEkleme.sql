CREATE TRIGGER basariNotuEkleme ON EgitimYoklamalari
INSTEAD OF INSERT 
--insert i�leminin yerine bir i�lem ger�ekle�tirece�iz, 
--bunu tercih etme nedenimiz e�er ge�erli bir tarih aral��� girilmediyse hata vererek kay�t i�lemini ger�ekle�tirmeyece�iz
AS
BEGIN
	
	--yeni eklenen tablodan kayd� girilen ��renciyi �ekiyoruz
	DECLARE @ogrenciId int, @egitimId int , @tarih smalldatetime, @katilim bit
	SELECT @ogrenciId = ogrenciId, @egitimId = egitimId, @tarih = tarih, @katilim = katilim FROM inserted    
	
	--eklenecek puan� hesaplayabilmek ad�na derse ait hafta say�s�n�, 
	--girilen tarihin ge�erli olup olmad���n� kontrol edebilmek ad�na ba�lang�� ve biti� tarihlerini �ekiyoruz
	DECLARE @haftaSayisi int, @baslangic smalldatetime, @bitis smalldatetime, @ogrenciNotu smallint
	SELECT @haftaSayisi = haftaSayisi FROM Egitimler WHERE id = @egitimId
	SELECT @baslangic = baslangictarihi, @bitis = bitistarihi FROM EgitimTarihleri WHERE egitimId = @egitimId 
	
	IF(@tarih NOT BETWEEN @baslangic AND @bitis)
		BEGIN 
			RAISERROR('Girilen tarih aral��� bu derse ait de�il',1,1)  --girilen tarihin ge�erli olup olmad���n� kontrol ediyoruz
			ROLLBACK TRANSACTION -- e�er tarih ge�erli de�ilse yap�lan i�lemleri geri al�yoruz
		END
		--derse kat�l�m sa�land�ysa ��renci puan�na gerekli puan hesaplan�p eklenecektir
		--e�er bu ��renci i�in ilk defa derse ait kay�t giriliyorsa yeni kay�t ekleyece�iz
	ELSE IF(@katilim=1)
		BEGIN
			
			

			IF EXISTS(SELECT * FROM NotTablosu WHERE egitimId= @egitimId AND ogrenciId=@ogrenciId)
			BEGIN
				SELECT @ogrenciNotu = ogrenciNotu FROM NotTablosu WHERE egitimId = @egitimId AND ogrenciId = @ogrenciId
				Set @ogrenciNotu = @ogrenciNotu + ROUND(100/@haftaSayisi,0)
				IF(@ogrenciNotu>100) Set @ogrenciNotu=100
				UPDATE NotTablosu SET ogrenciNotu=@ogrenciNotu WHERE egitimId=@egitimId AND ogrenciId=@ogrenciId
			END
			ELSE
			BEGIN
				INSERT INTO NotTablosu VALUES(@egitimId, @ogrenciId, ROUND(100/@haftaSayisi,0)) 
			END
		
		END
		--e�er ��renci derse gelmediyse puan eklenmeyecek ancak ona ait bir kay�t yoksa 0 puanla bir kay�t a��yoruz
	ELSE IF(@katilim=0)
		BEGIN
				IF NOT EXISTS(SELECT * FROM NotTablosu WHERE egitimId= @egitimId AND ogrenciId=@ogrenciId)
				INSERT INTO NotTablosu VALUES(@egitimId, @ogrenciId, 0) 
		END
		--ve t�m i�lemleri tamamlad�ktan sonra art�k yoklama kayd�n� ger�ekle�tirebiliriz
	INSERT INTO EgitimYoklamalari VALUES (@ogrenciId, @egitimId, @tarih, @katilim) 
END
