using System;
using System.Collections.Generic;
using System.Text;

namespace Teretana.Domain.Entities
{
    public class Uplata
    {
        public int Id { get; set; }
        public int ClanId { get; set; }
        public Clan Clan { get; set; } = null!;
        public DateTime Datum { get; set; }
        public StatusUplate Status { get; set; }
        public decimal Iznos { get; set; }
    }
}
