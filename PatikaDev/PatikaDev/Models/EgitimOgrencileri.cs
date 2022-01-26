namespace PatikaDev.Models
{
    public class EgitimOgrencileri
    {
        /*
         * Her ne kadar bu tablo Entity Framework tarafından otomatik oluşturulsa da,
         * NotTablosu ve EgitimYoklamalari tablolarında kullanılabilmesi için manual olarak tanımlanmıştır.
         * Bunun nedeni veri tekrarnın önüne geçebilmek, yapılan kontrolleri azaltmak, ayrıca her ne kadar tutarlı veri olsa da
         * BELLI DERSLERI ALMAMIS OGRENCILER ICIN KAYIT GIRILMESININ ONUNE GECEBILMEKTIR
         * Bu nedenle bu tablo aktif olarak kullanılacaktır.
         */
        public int Id { get; set; }
        public int EgitimId { get; set; }
        public int OgrenciId { get; set; }
    }
}
