using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaDev.Models
{
    public class EgitimTarihleri
    {
        public int Id { get; set; }
        public int EgitimId { get; set; }
        public Egitim Egitim { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
       

    }
}
