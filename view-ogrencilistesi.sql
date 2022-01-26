CREATE VIEW OgrenciListesi AS                 
SELECT 								
	e.egitimadi as 'EgitimAdi',
	CONCAT(o.isim,' ' , o.soyisim) as 'Ogrenci'
FROM EgitimOgrencileri eo
JOIN ogrenciler o ON (o.id = eo.ogrenciId)
JOIN egitimler e ON (e.id = eo.egitimId)
ORDER BY e.egitimAdi, o.isim offset 0 rows 
--offset 0 rows used because of 'ORDER BY' clause is invalid in views without using some expression like it