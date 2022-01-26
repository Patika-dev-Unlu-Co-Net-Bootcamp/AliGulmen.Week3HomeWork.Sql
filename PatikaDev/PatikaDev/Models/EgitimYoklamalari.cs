using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaDev.Models
{
    public class EgitimYoklamalari
    {
        public int Id { get; set; }
        public int EgitimId { get; set; }
        public int OgrenciId { get; set; }
        public DateTime Tarih { get; set; }
        public bool Katilim { get; set; }

    }
}
