using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaDev.Models
{
    public class NotTablosu
    {
        public int Id { get; set; }
        public int EgitimId { get; set; }
        public int OgrenciId { get; set; }
        public byte OgrenciNotu { get; set; }
    }
}
