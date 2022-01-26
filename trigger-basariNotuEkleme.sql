CREATE TRIGGER basariNotuEkleme ON EgitimYoklamalari
INSTEAD OF INSERT 
--insert iþleminin yerine bir iþlem gerçekleþtireceðiz, 
--bunu tercih etme nedenimiz eðer geçerli bir tarih aralýðý girilmediyse hata vererek kayýt iþlemini gerçekleþtirmeyeceðiz
AS
BEGIN
	
	--yeni eklenen tablodan kaydý girilen öðrenciyi çekiyoruz
	DECLARE @ogrenciId int, @egitimId int , @tarih smalldatetime, @katilim bit
	SELECT @ogrenciId = ogrenciId, @egitimId = egitimId, @tarih = tarih, @katilim = katilim FROM inserted    
	
	--eklenecek puaný hesaplayabilmek adýna derse ait hafta sayýsýný, 
	--girilen tarihin geçerli olup olmadýðýný kontrol edebilmek adýna baþlangýç ve bitiþ tarihlerini çekiyoruz
	DECLARE @haftaSayisi int, @baslangic smalldatetime, @bitis smalldatetime, @ogrenciNotu smallint
	SELECT @haftaSayisi = haftaSayisi FROM Egitimler WHERE id = @egitimId
	SELECT @baslangic = baslangictarihi, @bitis = bitistarihi FROM EgitimTarihleri WHERE egitimId = @egitimId 
	
	IF(@tarih NOT BETWEEN @baslangic AND @bitis)
		BEGIN 
			RAISERROR('Girilen tarih aralýðý bu derse ait deðil',1,1)  --girilen tarihin geçerli olup olmadýðýný kontrol ediyoruz
			ROLLBACK TRANSACTION -- eðer tarih geçerli deðilse yapýlan iþlemleri geri alýyoruz
		END
		--derse katýlým saðlandýysa öðrenci puanýna gerekli puan hesaplanýp eklenecektir
		--eðer bu öðrenci için ilk defa derse ait kayýt giriliyorsa yeni kayýt ekleyeceðiz
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
		--eðer öðrenci derse gelmediyse puan eklenmeyecek ancak ona ait bir kayýt yoksa 0 puanla bir kayýt açýyoruz
	ELSE IF(@katilim=0)
		BEGIN
				IF NOT EXISTS(SELECT * FROM NotTablosu WHERE egitimId= @egitimId AND ogrenciId=@ogrenciId)
				INSERT INTO NotTablosu VALUES(@egitimId, @ogrenciId, 0) 
		END
		--ve tüm iþlemleri tamamladýktan sonra artýk yoklama kaydýný gerçekleþtirebiliriz
	INSERT INTO EgitimYoklamalari VALUES (@ogrenciId, @egitimId, @tarih, @katilim) 
END
