CREATE procedure EgitimeKatil(@egitimId int, @ogrenciId int) 
As
Begin
DECLARE @baslangic smalldatetime, @bitis smalldatetime
--kayýt yapýlacak eðitime ait tarihleri çekiyoruz.
SELECT @baslangic = baslangictarihi, @bitis = bitistarihi FROM EgitimTarihleri WHERE egitimId=@egitimId

--öðrencinin kayýtlý olduðu eðitimler ile karþýlaþtýracaðýmýzda eðitimlerin çakýþmasý için 3 ihtimal vardýr
-- yeni eðitimin baþlangýç tarihi, mevcut bir eðitimin tarihleri arasýna denk geliyorsa veya
-- yeni eðitimin bitiþ tarihi, mevcut bir eðitimin tarihleri arasýna denk geliyorsa veya
-- yeni eðitim mevcut eðitimin tarihlerini tamamen kapsýyorsa

IF EXISTS(SELECT * FROM EgitimOgrencileri eo
					JOIN EgitimTarihleri t ON (eo.egitimId = t.egitimId)
					WHERE eo.ogrenciId = @ogrenciId AND ((@baslangic BETWEEN baslangictarihi AND bitistarihi)
														OR (@bitis BETWEEN baslangictarihi AND bitistarihi)
												OR  (@baslangic < baslangictarihi AND @bitis > baslangictarihi)))
SELECT ('Bu tarihler arasýnda öðrenci zaten bir eðitime kayýtlýdýr!');
-- katýlma saðlanacak eðitim, kontejan sayýsýna ulaþýlmýþsa kayýt yapýlmayacaktýr.
ELSE IF((select COUNT(*) from EgitimOgrencileri WHERE egitimId=@egitimId) >= (select kontejan from egitimler WHERE id=@egitimId))
SELECT ('Bu eðitim için katýlým kontejaný dolmuþtur!');
ELSE
	INSERT INTO EgitimOgrencileri VALUES (@egitimId,@ogrenciId)  
End
