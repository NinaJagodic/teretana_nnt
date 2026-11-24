using System;
using System.Collections.Generic;
using System.Text;

namespace Teretana.Domain.Entities
{
    public class PrijavaNaTrening
    {
        public int ClanId { get; set; }
        public Clan Clan { get; set; } = null!;
        public int TreningId { get; set; }
        public Trening Trening { get; set; } = null!;
        public DateTime DatumPrijave { get; set; }
    }
}
