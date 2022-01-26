CREATE procedure EgitimeKatil(@egitimId int, @ogrenciId int) 
As
Begin
DECLARE @baslangic smalldatetime, @bitis smalldatetime
--kay�t yap�lacak e�itime ait tarihleri �ekiyoruz.
SELECT @baslangic = baslangictarihi, @bitis = bitistarihi FROM EgitimTarihleri WHERE egitimId=@egitimId

--��rencinin kay�tl� oldu�u e�itimler ile kar��la�t�raca��m�zda e�itimlerin �ak��mas� i�in 3 ihtimal vard�r
-- yeni e�itimin ba�lang�� tarihi, mevcut bir e�itimin tarihleri aras�na denk geliyorsa veya
-- yeni e�itimin biti� tarihi, mevcut bir e�itimin tarihleri aras�na denk geliyorsa veya
-- yeni e�itim mevcut e�itimin tarihlerini tamamen kaps�yorsa

IF EXISTS(SELECT * FROM EgitimOgrencileri eo
					JOIN EgitimTarihleri t ON (eo.egitimId = t.egitimId)
					WHERE eo.ogrenciId = @ogrenciId AND ((@baslangic BETWEEN baslangictarihi AND bitistarihi)
														OR (@bitis BETWEEN baslangictarihi AND bitistarihi)
												OR  (@baslangic < baslangictarihi AND @bitis > baslangictarihi)))
SELECT ('Bu tarihler aras�nda ��renci zaten bir e�itime kay�tl�d�r!');
-- kat�lma sa�lanacak e�itim, kontejan say�s�na ula��lm��sa kay�t yap�lmayacakt�r.
ELSE IF((select COUNT(*) from EgitimOgrencileri WHERE egitimId=@egitimId) >= (select kontejan from egitimler WHERE id=@egitimId))
SELECT ('Bu e�itim i�in kat�l�m kontejan� dolmu�tur!');
ELSE
	INSERT INTO EgitimOgrencileri VALUES (@egitimId,@ogrenciId)  
End
