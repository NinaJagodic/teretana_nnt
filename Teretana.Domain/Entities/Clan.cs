using System;
using System.Collections.Generic;
using System.Text;

namespace Teretana.Domain.Entities
{
    public class Clan
    {
        public int Id { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DatumUclanjenja { get; set; }
        public ICollection<Uplata> Uplate { get; set; } = new List<Uplata>();
        public ICollection<PrijavaNaTrening> Prijave { get; set; } = new List<PrijavaNaTrening>();
    }
}
