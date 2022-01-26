using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaDev.Models
{
    public class Egitim
    {
        public int Id { get; set; }
        public string EgitimAdi { get; set; }

        public int EgitmenId { get; set; }
        public Egitmen Egitmen { get; set; }

        public byte BasariNotu { get; set; }
        public Int16 Kontejan { get; set; }

        public List<Asistan> Asistanlar { get; set; }
        public List<Katilimci> Katilimcilar { get; set; }
        //zaten oluşturuyoruz  public List<Ogrenci> Ogrenciler { get; set; }
        public EgitimTarihleri EgitimTarihi { get; set; }

    }

}
